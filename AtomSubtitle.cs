using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the subtitle of an Atom feed or source.</summary>
  public class AtomSubtitle : AtomTextNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomSubtitle"/> class with the specified text.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    public AtomSubtitle(string text) : base(text) { }

    /// <summary>Initializes a new instance of the <see cref="AtomSubtitle"/> class with the specified text and type.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    /// <param name="type">An <see cref="AtomTextType"/> representing the type of text.</param>
    public AtomSubtitle(string text, AtomTextType type) : base(text, type) { }

    /// <summary>Initializes a new instance of the <see cref="AtomSubtitle"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomSubtitle(XElement element) : base(element) { }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomSubtitle"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "subtitle".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "subtitle"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomSubtitle"/>.</summary>
    /// <param name="text">A <see cref="string"/> to convert to an <see cref="AtomSubtitle"/>.</param>
    /// <returns>An <see cref="AtomSubtitle"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomSubtitle(string text)
    {
      return text == null ? null : new AtomSubtitle(text);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomSubtitle"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomSubtitle"/>.</param>
    /// <returns>An <see cref="AtomSubtitle"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomSubtitle(XElement element)
    {
      return element == null ? null : new AtomSubtitle(element);
    }
  }
}
