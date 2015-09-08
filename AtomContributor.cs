using System;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>Represents a contributor of an Atom feed or entry.</summary>
  public class AtomContributor : AtomPersonNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomContributor"/> class with the specified name.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    public AtomContributor(string name) : base(name) { }

    /// <summary>Initializes a new instance of the <see cref="AtomContributor"/> class with the specified name and email address.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    /// <param name="email">A <see cref="string"/> representing the email address of the person.</param>
    public AtomContributor(string name, string email) : base(name, email) { }

    /// <summary>Initializes a new instance of the <see cref="AtomContributor"/> class with the specified name, email address, and URI.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    /// <param name="email">A <see cref="string"/> representing the email address of the person.</param>
    /// <param name="uri">A <see cref="string"/> representing the URI of the person.</param>
    public AtomContributor(string name, string email, string uri) : base(name, email, uri) { }

    /// <summary>Initializes a new instance of the <see cref="AtomContributor"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomContributor(XElement element) : base(element) { }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomContributor"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "contributor".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "contributor"; }
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomContributor"/>.</summary>
    /// <param name="name">A <see cref="string"/> to convert to an <see cref="AtomContributor"/>.</param>
    /// <returns>An <see cref="AtomContributor"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomContributor(string name)
    {
      return name == null ? null : new AtomContributor(name);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomContributor"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomContributor"/>.</param>
    /// <returns>An <see cref="AtomContributor"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomContributor(XElement element)
    {
      return element == null ? null : new AtomContributor(element);
    }
  }
}
