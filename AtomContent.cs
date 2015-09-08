using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>An abstract base class that represents the content of an Atom entry.</summary>
  [DebuggerDisplay("Type = {Type}")]
  public abstract class AtomContent : AtomNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomContent"/> class.</summary>
    protected AtomContent() { }

    /// <summary>Initializes a new instance of the <see cref="AtomContent"/> class with the specified type.</summary>
    /// <param name="type">A <see cref="string"/> representing the type of content.</param>
    protected AtomContent(string type)
    {
      this.Type = type;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomContent"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomContent(XElement element) : base(element) { }

    /// <summary>Gets or sets the type of this content.</summary>
    /// <value>A <see cref="string"/> representing the type of this content.</value>
    public virtual string Type
    {
      get { return (string)this.Element.Attribute("type"); }
      set { this.Element.SetAttributeValue("type", value); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomContent"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "content".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "content"; }
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomContent"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomContent"/>.</param>
    /// <returns>An <see cref="AtomContent"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomContent(XElement element)
    {
      if(element == null) return null;
      if(element.Attribute("src") == null) return (AtomInlineContent)element;
      return (AtomOutOfLineContent)element;
    }
  }
}
