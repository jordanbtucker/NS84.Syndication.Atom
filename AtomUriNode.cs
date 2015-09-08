using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>An abstract base class that represents a URI based Atom node.</summary>
  public abstract class AtomUriNode : AtomNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomUriNode"/> class with the specified URI.</summary>
    /// <param name="uri">A <see cref="String"/> representing the URI.</param>
    protected AtomUriNode(string uri)
    {
      this.Uri = uri;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomUriNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomUriNode(XElement element) : base(element) { }

    /// <summary>Gets or sets the URI of this node.</summary>
    /// <value>A <see cref="string"/> representing the URI of this node.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
    public string Uri
    {
      get { return (string)this.Element; }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.Element.SetValue(value);
      }
    }

    /// <summary>Returns a <see cref="string"/> representing the URI of this node.</summary>
    /// <returns>A <see cref="string"/> representing the URI of this node.</returns>
    public override string ToString()
    {
      return this.Uri;
    }

    /// <summary>Converts an <see cref="AtomUriNode"/> to a <see cref="string"/>.</summary>
    /// <param name="node">An <see cref="AtomUriNode"/> to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> converted from the specified <see cref="AtomUriNode"/>.</returns>
    public static implicit operator string(AtomUriNode node)
    {
      return node == null ? null : node.Uri;
    }
  }
}
