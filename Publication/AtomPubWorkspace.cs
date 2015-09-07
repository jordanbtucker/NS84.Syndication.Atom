using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  [DebuggerDisplay("Title = {Title}")]
  public class AtomPubWorkspace : AtomPubNodeContainerNode
  {
    public AtomPubWorkspace(AtomTitle title)
    {
      if(title == null) throw new ArgumentNullException("title");
      this.Title = title;
    }

    protected AtomPubWorkspace(XElement element) : base(element) { }

    public AtomTitle Title
    {
      get { return this.Element.Element(AtomFeed.AtomNamespace + "title"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        this.SetSingleElement(AtomFeed.AtomNamespace + "title", value);
      }
    }

    public IEnumerable<AtomPubCollection> Collections
    {
      get { return this.Element.Elements(AtomPubNamespace + "collection").Select(e => (AtomPubCollection)e); }
    }

    protected override XName ElementName
    {
      get { return AtomPubNamespace + "workspace"; }
    }

    public override IEnumerable<XElement> ExtElements()
    {
      return base.ExtElements().Where(e => e.Name != AtomFeed.AtomNamespace + "title");
    }

    protected override bool CanAddNode(AtomPubNode node)
    {
      return node is AtomPubCollection;
    }

    protected override bool CanRemoveNode(AtomPubNode node)
    {
      return true;
    }

    protected override bool CanAddExtElement(XElement element)
    {
      return element.Name != AtomFeed.AtomNamespace + "title";
    }

    protected override bool CanRemoveExtElement(XElement element)
    {
      return element.Name != AtomFeed.AtomNamespace + "title";
    }

    public static implicit operator AtomPubWorkspace(XElement element)
    {
      return element == null ? null : new AtomPubWorkspace(element);
    }
  }
}
