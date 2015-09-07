using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the icon of an Atom feed or source.</summary>
  public class AtomIcon : AtomUriNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomIcon"/> class with the specified URI.</summary>
    /// <param name="uri">A <see cref="String"/> representing the URI.</param>
    public AtomIcon(string uri) : base(uri) { }

    /// <summary>Initializes a new instance of the <see cref="AtomIcon"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomIcon(XElement element) : base(element) { }

    /// <summary>Gets an <see cref="XName"/> representing the name of the underlying element.</summary>
    /// <returns>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomIcon"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "icon".</returns>
    protected override XName ElementName
    {
      get { return AtomNamespace + "icon"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomIcon"/>.</summary>
    /// <param name="uri">A <see cref="string"/> to convert to an <see cref="AtomIcon"/>.</param>
    /// <returns>An <see cref="AtomIcon"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomIcon(string uri)
    {
      return uri == null ? null : new AtomIcon(uri);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomIcon"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomIcon"/>.</param>
    /// <returns>An <see cref="AtomIcon"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomIcon(XElement element)
    {
      return element == null ? null : new AtomIcon(element);
    }
  }
}
