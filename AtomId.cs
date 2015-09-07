using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the ID of an Atom feed or entry.</summary>
  public class AtomId : AtomUriNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomId"/> class with the specified URI.</summary>
    /// <param name="uri">A <see cref="String"/> representing the URI.</param>
    public AtomId(string uri) : base(uri) { }

    /// <summary>Initializes a new instance of the <see cref="AtomId"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomId(XElement element) : base(element) { }

    /// <summary>Gets an <see cref="XName"/> representing the name of the underlying element.</summary>
    /// <returns>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomId"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "id".</returns>
    protected override XName ElementName
    {
      get { return AtomNamespace + "id"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomId"/>.</summary>
    /// <param name="uri">A <see cref="string"/> to convert to an <see cref="AtomId"/>.</param>
    /// <returns>An <see cref="AtomId"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomId(string uri)
    {
      return uri == null ? null : new AtomId(uri);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomId"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomId"/>.</param>
    /// <returns>An <see cref="AtomId"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomId(XElement element)
    {
      return element == null ? null : new AtomId(element);
    }
  }
}
