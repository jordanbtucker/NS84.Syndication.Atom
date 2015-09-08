using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  /// <summary>Represents a media type that can be posted to an Atom Publishing Collection.</summary>
  public class AtomPubAccept : AtomPubNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubAccept"/> class.</summary>
    public AtomPubAccept() : this("") { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubAccept"/> class with the specified text.</summary>
    /// <param name="text">A <see cref="string"/> representing a media type that can be posted to an Atom Publishing Collection.</param>
    public AtomPubAccept(string text)
    {
      this.Text = text ?? "";
    }

    /// <summary>Initializes a new instance of the <see cref="AtomPubAccept"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubAccept(XElement element) : base(element) { }

    /// <summary>Gets or sets a media type that can be posted to an Atom Publishing Collection.</summary>
    /// <value>A <see cref="string"/> representing a media type that can be posted to an Atom Publishing Collection.</value>
    public string Text
    {
      get { return (string)this.Element; }
      set { this.Element.SetValue(value ?? ""); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomPubAccept"/>, this value is <see cref="AtomPubService.AtomPubNamespace"/> + "accept".</value>
    protected override XName ElementName
    {
      get { return AtomPubNamespace + "accept"; }
    }

    /// <summary>Returns a <see cref="string"/> representing the text of this node.</summary>
    /// <returns>A <see cref="string"/> representing the text of this node.</returns>
    public override string ToString()
    {
      return this.Text;
    }

    /// <summary>Converts an <see cref="AtomPubAccept"/> to a <see cref="string"/>.</summary>
    /// <param name="node">An <see cref="AtomPubAccept"/> to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> converted from the specified <see cref="AtomPubAccept"/>.</returns>
    public static implicit operator string(AtomPubAccept node)
    {
      return node == null ? null : node.Text;
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomPubAccept"/>.</summary>
    /// <param name="name">A <see cref="string"/> to convert to an <see cref="AtomPubAccept"/>.</param>
    /// <returns>An <see cref="AtomPubAccept"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomPubAccept(string text)
    {
      return new AtomPubAccept(text);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubAccept"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubAccept"/>.</param>
    /// <returns>An <see cref="AtomPubAccept"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubAccept(XElement element)
    {
      return element == null ? null : new AtomPubAccept(element);
    }
  }
}
