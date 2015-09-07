using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  [DebuggerDisplay("Title = {Title}, Href = {Href}")]
  public class AtomPubCollection : AtomPubNodeContainerNode
  {
    public AtomPubCollection(AtomTitle title, string href)
    {
      if(title == null) throw new ArgumentNullException("title");
      if(href == null) throw new ArgumentNullException("href");
      if(href == "") throw new ArgumentException(Errors.EmptyString, "href");
      this.Title = title;
      this.Href = href;
    }

    protected AtomPubCollection(XElement element) : base(element) { }

    public AtomTitle Title
    {
      get { return this.Element.Element(AtomFeed.AtomNamespace + "title"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        this.SetSingleElement(AtomFeed.AtomNamespace + "title", value);
      }
    }

    public string Href
    {
      get { return (string)this.Element.Attribute("href"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.Element.SetAttributeValue("href", value);
      }
    }

    public IEnumerable<AtomPubAccept> Accepts
    {
      get { return this.Element.Elements(AtomPubNamespace + "accept").Select(e => (AtomPubAccept)e); }
    }

    public IEnumerable<AtomPubCategories> Categories
    {
      get { return this.Element.Elements(AtomPubNamespace + "categories").Select(e => (AtomPubCategories)e); }
    }

    protected override XName ElementName
    {
      get { return AtomPubNamespace + "collection"; }
    }

    public override IEnumerable<XElement> ExtElements()
    {
      return base.ExtElements().Where(e => e.Name != AtomFeed.AtomNamespace + "title");
    }

    protected override bool CanAddNode(AtomPubNode node)
    {
      return node is AtomPubAccept || node is AtomPubCategories;
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

    public static implicit operator AtomPubCollection(XElement element)
    {
      return element == null ? null : new AtomPubCollection(element);
    }
  }
}
