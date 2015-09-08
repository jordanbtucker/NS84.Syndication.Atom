using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  /// <summary>Represents and Atom Publishing Collection.</summary>
  [DebuggerDisplay("Title = {Title}, Href = {Href}")]
  public class AtomPubCollection : AtomPubNodeContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubCollection"/> class with the specified title and href.</summary>
    /// <param name="title">A <see cref="string"/> representing the title of the collection.</param>
    /// <param name="href">A <see cref="string"/> representing the href of the collection.</param>
    /// <exception cref="ArgumentNullException"><paramref name="title"/> or <paramref name="href"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="href"/> is an empty <see cref="string"/>.</exception>
    public AtomPubCollection(AtomTitle title, string href)
    {
      if(title == null) throw new ArgumentNullException("title");
      if(href == null) throw new ArgumentNullException("href");
      if(href == "") throw new ArgumentException(Errors.EmptyString, "href");
      this.Title = title;
      this.Href = href;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomPubCollection"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubCollection(XElement element) : base(element) { }

    /// <summary>Gets or sets the title of this collection.</summary>
    /// <value>A <see cref="string"/> representing the title of this collection.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    public AtomTitle Title
    {
      get { return this.Element.Element(AtomFeed.AtomNamespace + "title"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        this.SetSingleElement(AtomFeed.AtomNamespace + "title", value);
      }
    }

    /// <summary>Gets or sets the href of this collection.</summary>
    /// <value>A <see cref="string"/> representing the href of this collection.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
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

    /// <summary>Gets the media types that can be posted to this collection.</summary>
    /// <value>An <see cref="IEnumerable{T}"/> of <see cref="AtomPubAccept"/> representing the media types that can be posted to this collection.</value>
    public IEnumerable<AtomPubAccept> Accepts
    {
      get { return this.Element.Elements(AtomPubNamespace + "accept").Select(e => (AtomPubAccept)e); }
    }

    /// <summary>Gets the categories that can be applied to the members of this collection.</summary>
    /// <value>An <see cref="IEnumerable{T}"/> of <see cref="AtomPubCategories"/> representing the categories that can be applied to the members of this collection.</value>
    public IEnumerable<AtomPubCategories> Categories
    {
      get { return this.Element.Elements(AtomPubNamespace + "categories").Select(e => (AtomPubCategories)e); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomPubCollection"/>, this value is <see cref="AtomPubService.AtomPubNamespace"/> + "collection".</value>
    protected override XName ElementName
    {
      get { return AtomPubNamespace + "collection"; }
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
      return node is AtomPubAccept || node is AtomPubCategories;
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

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubCollection"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubCollection"/>.</param>
    /// <returns>An <see cref="AtomPubCollection"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubCollection(XElement element)
    {
      return element == null ? null : new AtomPubCollection(element);
    }
  }
}
