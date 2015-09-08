using System;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>Represents an author of an Atom feed or entry.</summary>
  public class AtomAuthor : AtomPersonNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomAuthor"/> class with the specified name.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    public AtomAuthor(string name) : base(name) { }

    /// <summary>Initializes a new instance of the <see cref="AtomAuthor"/> class with the specified name and email address.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    /// <param name="email">A <see cref="string"/> representing the email address of the person.</param>
    public AtomAuthor(string name, string email) : base(name, email) { }

    /// <summary>Initializes a new instance of the <see cref="AtomAuthor"/> class with the specified name, email address, and URI.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    /// <param name="email">A <see cref="string"/> representing the email address of the person.</param>
    /// <param name="uri">A <see cref="string"/> representing the URI of the person.</param>
    public AtomAuthor(string name, string email, string uri) : base(name, email, uri) { }

    /// <summary>Initializes a new instance of the <see cref="AtomAuthor"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomAuthor(XElement element) : base(element) { }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomAuthor"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "author".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "author"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomAuthor"/>.</summary>
    /// <param name="name">A <see cref="string"/> to convert to an <see cref="AtomAuthor"/>.</param>
    /// <returns>An <see cref="AtomAuthor"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomAuthor(string name)
    {
      return name == null ? null : new AtomAuthor(name);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomAuthor"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomAuthor"/>.</param>
    /// <returns>An <see cref="AtomAuthor"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomAuthor(XElement element)
    {
      return element == null ? null : new AtomAuthor(element);
    }
  }
}
