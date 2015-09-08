using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>An abstract base class that represents a person based Atom node.</summary>
  [DebuggerDisplay("Name = {Name}, Email = {Email}, Uri = {Uri}")]
  public abstract class AtomPersonNode : AtomExtensionContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPersonNode"/> class with the specified name.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    protected AtomPersonNode(string name) : this(name, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomPersonNode"/> class with the specified name and email address.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    /// <param name="email">A <see cref="string"/> representing the email address of the person.</param>
    protected AtomPersonNode(string name, string email) : this(name, email, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomPersonNode"/> class with the specified name, email address, and URI.</summary>
    /// <param name="name">A <see cref="string"/> representing the name of the person.</param>
    /// <param name="email">A <see cref="string"/> representing the email address of the person.</param>
    /// <param name="uri">A <see cref="string"/> representing the URI of the person.</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> is an empty <see cref="string"/>.</exception>
    protected AtomPersonNode(string name, string email, string uri)
    {
      if(name == null) throw new ArgumentNullException("name");
      if(name == "") throw new ArgumentException(Errors.EmptyString, "name");
      this.Name = name;
      this.Email = email;
      this.Uri = uri;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomPersonNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPersonNode(XElement element) : base(element) { }

    /// <summary>Gets or sets the name of the person.</summary>
    /// <value>A <see cref="string"/> representing the name of the person.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
    public string Name
    {
      get { return (string)this.Element.Element(AtomNamespace + "name"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.Element.SetElementValue(AtomNamespace + "name", value);
      }
    }

    /// <summary>Gets or sets the email address of the person.</summary>
    /// <value>A <see cref="string"/> representing the email address of the person.</value>
    public string Email
    {
      get { return (string)this.Element.Element(AtomNamespace + "email"); }
      set { this.Element.SetElementValue(AtomNamespace + "email", value); }
    }

    /// <summary>Gets or sets the URI of the person.</summary>
    /// <value>A <see cref="string"/> representing the URI of the person.</value>
    public string Uri
    {
      get { return (string)this.Element.Element(AtomNamespace + "uri"); }
      set { this.Element.SetElementValue(AtomNamespace + "uri", value); }
    }

    /// <summary>Returns a <see cref="string"/> representing the name of the person.</summary>
    /// <returns>A <see cref="string"/> representing the name of the person.</returns>
    public override string ToString()
    {
      return this.Name;
    }

    /// <summary>Converts an <see cref="AtomPersonNode"/> to a <see cref="string"/>.</summary>
    /// <param name="node">An <see cref="AtomPersonNode"/> to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> converted from the specified <see cref="AtomPersonNode"/>.</returns>
    public static implicit operator string(AtomPersonNode node)
    {
      return node == null ? null : node.Name;
    }
  }
}
