using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace NS84.Syndication.Atom.Publication
{
  /// <summary>Represents and Atom Publishing Workspace.</summary>
  [DebuggerDisplay("Title = {Title}")]
  public class AtomPubWorkspace : AtomPubNodeContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubWorkspace"/> class with the specified title.</summary>
    /// <param name="title">A <see cref="string"/> representing the title of the workspace.</param>
    public AtomPubWorkspace(AtomTitle title)
    {
      if(title == null) throw new ArgumentNullException("title");
      this.Title = title;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomPubWorkspace"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubWorkspace(XElement element) : base(element) { }

    /// <summary>Gets or sets the title of this workspace.</summary>
    /// <value>A <see cref="string"/> representing the title of this workspace.</value>
    public AtomTitle Title
    {
      get { return this.Element.Element(AtomFeed.AtomNamespace + "title"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        this.SetSingleElement(AtomFeed.AtomNamespace + "title", value);
      }
    }

    /// <summary>Gets the collections in this workspace.</summary>
    /// <value>An <see cref="IEnumerable{T}"/> of <see cref="AtomPubCollection"/> representing the collection in this workspace.</value>
    public IEnumerable<AtomPubCollection> Collections
    {
      get { return this.Element.Elements(AtomPubNamespace + "collection").Select(e => (AtomPubCollection)e); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomPubWorkspace"/>, this value is <see cref="AtomPubService.AtomPubNamespace"/> + "workspace".</value>
    protected override XName ElementName
    {
      get { return AtomPubNamespace + "workspace"; }
    }

    /// <summary>Returns the extension elements in this node.</summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="XElement"/> representing the extension elements in this node.</returns>
    public override IEnumerable<XElement> ExtElements()
    {
      return base.ExtElements().Where(e => e.Name != AtomFeed.AtomNamespace + "title");
    }

    /// <summary>Returns a value indicating whether the specified <see cref="AtomPubNode"/> can be added.</summary>
    /// <param name="node">The <see cref="AtomPubNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomPubNode"/> can be added; otherwise, false.</returns>
    protected override bool CanAddNode(AtomPubNode node)
    {
      return node is AtomPubCollection;
    }

    /// <summary>Returns a value indicating whether the specified <see cref="AtomPubNode"/> can be removed.</summary>
    /// <param name="node">The <see cref="AtomPubNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomPubNode"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveNode(AtomPubNode node)
    {
      return true;
    }

    /// <summary>Returns a value indicating whether the specified <see cref="XElement"/> can be added.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be added; otherwise, false.</returns>
    protected override bool CanAddExtElement(XElement element)
    {
      return element.Name != AtomFeed.AtomNamespace + "title";
    }

    /// <summary>Returns a value indicating whether the specified <see cref="XElement"/> can be removed.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveExtElement(XElement element)
    {
      return element.Name != AtomFeed.AtomNamespace + "title";
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubWorkspace"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubWorkspace"/>.</param>
    /// <returns>An <see cref="AtomPubWorkspace"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubWorkspace(XElement element)
    {
      return element == null ? null : new AtomPubWorkspace(element);
    }
  }
}
