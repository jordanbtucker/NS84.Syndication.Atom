using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the title of an Atom feed or entry.</summary>
  public class AtomTitle : AtomTextNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomTitle"/> class with the specified text.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    public AtomTitle(string text) : base(text) { }

    /// <summary>Initializes a new instance of the <see cref="AtomTitle"/> class with the specified text and type.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    /// <param name="type">An <see cref="AtomTextType"/> representing the type of text.</param>
    public AtomTitle(string text, AtomTextType type) : base(text, type) { }

    /// <summary>Initializes a new instance of the <see cref="AtomTitle"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomTitle(XElement element) : base(element) { }

    /// <summary>Gets an <see cref="XName"/> representing the name of the underlying element.</summary>
    /// <returns>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomTitle"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "title".</returns>
    protected override XName ElementName
    {
      get { return AtomNamespace + "title"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomTitle"/>.</summary>
    /// <param name="text">A <see cref="string"/> to convert to an <see cref="AtomTitle"/>.</param>
    /// <returns>An <see cref="AtomTitle"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomTitle(string text)
    {
      return text == null ? null : new AtomTitle(text);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomTitle"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomTitle"/>.</param>
    /// <returns>An <see cref="AtomTitle"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomTitle(XElement element)
    {
      return element == null ? null : new AtomTitle(element);
    }
  }
}
