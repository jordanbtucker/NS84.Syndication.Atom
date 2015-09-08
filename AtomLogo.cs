using System;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>Represents the logo of an Atom feed or source.</summary>
  public class AtomLogo : AtomUriNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomLogo"/> class with the specified URI.</summary>
    /// <param name="uri">A <see cref="String"/> representing the URI.</param>
    public AtomLogo(string uri) : base(uri) { }

    /// <summary>Initializes a new instance of the <see cref="AtomLogo"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomLogo(XElement element) : base(element) { }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomLogo"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "logo".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "logo"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomLogo"/>.</summary>
    /// <param name="uri">A <see cref="string"/> to convert to an <see cref="AtomLogo"/>.</param>
    /// <returns>An <see cref="AtomLogo"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomLogo(string uri)
    {
      return uri == null ? null : new AtomLogo(uri);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomLogo"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomLogo"/>.</param>
    /// <returns>An <see cref="AtomLogo"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomLogo(XElement element)
    {
      return element == null ? null : new AtomLogo(element);
    }
  }
}
