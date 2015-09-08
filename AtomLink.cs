using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents a link in an Atom feed or entry.</summary>
  public class AtomLink : AtomUndefinedContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomLink"/> class with the specified href.</summary>
    /// <param name="href">A <see cref="string"/> representing the href.</param>
    public AtomLink(string href) : this(href, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomLink"/> class with the specified href and rel.</summary>
    /// <param name="href">A <see cref="string"/> representing the href.</param>
    /// <param name="rel">A <see cref="string"/> representing the rel.</param>
    public AtomLink(string href, string rel) : this(href, rel, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomLink"/> class with the specified href, rel, and type.</summary>
    /// <param name="href">A <see cref="string"/> representing the href.</param>
    /// <param name="rel">A <see cref="string"/> representing the rel.</param>
    /// <param name="type">A <see cref="string"/> representing the type.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
    public AtomLink(string href, string rel, string type)
    {
      if(href == null) throw new ArgumentNullException("href");
      if(href == "") throw new ArgumentException(Errors.EmptyString, "href");
      this.Href = href;
      this.Rel = rel;
      this.Type = type;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomLink"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomLink(XElement element) : base(element) { }

    /// <summary>Gets or sets the href of the link.</summary>
    /// <value>A <see cref="string"/> representing the href of the link.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
    public virtual string Href
    {
      get { return (string)this.Element.Attribute("href"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.Element.SetAttributeValue("href", value);
      }
    }

    /// <summary>Gets or sets the rel of the link.</summary>
    /// <value>A <see cref="string"/> representing the rel of the link.</value>
    public virtual string Rel
    {
      get { return (string)this.Element.Attribute("rel"); }
      set { this.Element.SetAttributeValue("rel", value); }
    }

    /// <summary>Gets or sets the type of the link.</summary>
    /// <value>A <see cref="string"/> representing the type of the link.</value>
    public virtual string Type
    {
      get { return (string)this.Element.Attribute("type"); }
      set { this.Element.SetAttributeValue("type", value); }
    }

    /// <summary>Gets or sets the href language of the link.</summary>
    /// <value>A <see cref="string"/> representing the href language of the link.</value>
    public virtual string HrefLanguage
    {
      get { return (string)this.Element.Attribute("hreflang"); }
      set { this.Element.SetAttributeValue("hreflang", value); }
    }

    /// <summary>Gets or sets the title of the link.</summary>
    /// <value>A <see cref="string"/> representing the title of the link.</value>
    public virtual string Title
    {
      get { return (string)this.Element.Attribute("title"); }
      set { this.Element.SetAttributeValue("title", value); }
    }

    /// <summary>Gets or sets the length of the content represented by the link.</summary>
    /// <value>A <see cref="string"/> representing the length of the content represented by the link.</value>
    public virtual string Length
    {
      get { return (string)this.Element.Attribute("length"); }
      set { this.Element.SetAttributeValue("length", value); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomLink"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "link".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "link"; }
    }

    /// <summary>Returns a <see cref="string"/> representing the href of the link.</summary>
    /// <returns>A <see cref="string"/> representing the href of the link.</returns>
    public override string ToString()
    {
      return this.Href;
    }

    /// <summary>Converts an <see cref="AtomLink"/> to a <see cref="string"/>.</summary>
    /// <param name="node">An <see cref="AtomLink"/> to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> converted from the specified <see cref="AtomLink"/>.</returns>
    public static implicit operator string(AtomLink node)
    {
      return node == null ? null : node.Href;
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomLink"/>.</summary>
    /// <param name="term">A <see cref="string"/> to convert to an <see cref="AtomLink"/>.</param>
    /// <returns>An <see cref="AtomLink"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomLink(string href)
    {
      return href == null ? null : new AtomLink(href);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomLink"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomLink"/>.</param>
    /// <returns>An <see cref="AtomLink"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomLink(XElement element)
    {
      return element == null ? null : new AtomLink(element);
    }
  }
}
