using System;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>Represents the copyright information about an Atom feed or entry.</summary>
  public class AtomRights : AtomTextNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomRights"/> class with the specified text.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    public AtomRights(string text) : base(text) { }

    /// <summary>Initializes a new instance of the <see cref="AtomRights"/> class with the specified text and type.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    /// <param name="type">An <see cref="AtomTextType"/> representing the type of text.</param>
    public AtomRights(string text, AtomTextType type) : base(text, type) { }

    /// <summary>Initializes a new instance of the <see cref="AtomRights"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomRights(XElement element) : base(element) { }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomRights"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "rights".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "rights"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomRights"/>.</summary>
    /// <param name="text">A <see cref="string"/> to convert to an <see cref="AtomRights"/>.</param>
    /// <returns>An <see cref="AtomRights"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomRights(string text)
    {
      return text == null ? null : new AtomRights(text);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomRights"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomRights"/>.</param>
    /// <returns>An <see cref="AtomRights"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomRights(XElement element)
    {
      return element == null ? null : new AtomRights(element);
    }
  }
}
