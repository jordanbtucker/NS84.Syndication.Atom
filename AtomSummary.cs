using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the summary of an Atom feed or entry.</summary>
  public class AtomSummary : AtomTextNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomSummary"/> class with the specified text.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    public AtomSummary(string text) : base(text) { }

    /// <summary>Initializes a new instance of the <see cref="AtomSummary"/> class with the specified text and type.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    /// <param name="type">An <see cref="AtomTextType"/> representing the type of text.</param>
    public AtomSummary(string text, AtomTextType type) : base(text, type) { }

    /// <summary>Initializes a new instance of the <see cref="AtomSummary"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomSummary(XElement element) : base(element) { }

    /// <summary>Gets an <see cref="XName"/> representing the name of the underlying element.</summary>
    /// <returns>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomSummary"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "summary".</returns>
    protected override XName ElementName
    {
      get { return AtomNamespace + "summary"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomSummary"/>.</summary>
    /// <param name="text">A <see cref="string"/> to convert to an <see cref="AtomSummary"/>.</param>
    /// <returns>An <see cref="AtomSummary"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomSummary(string text)
    {
      return text == null ? null : new AtomSummary(text);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomSummary"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomSummary"/>.</param>
    /// <returns>An <see cref="AtomSummary"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomSummary(XElement element)
    {
      return element == null ? null : new AtomSummary(element);
    }
  }
}
