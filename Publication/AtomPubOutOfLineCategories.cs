using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  /// <summary>Represents a location to an Atom Publishing Category Document.</summary>
  [DebuggerDisplay("Href = {Href}")]
  public class AtomPubOutOfLineCategories : AtomPubCategories
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubInlineCategories"/> class with the specified href.</summary>
    /// <param name="href">A <see cref="string"/> representing the location to an Atom Publishing Category Document.</param>
    public AtomPubOutOfLineCategories(string href)
    {
      this.Href = href;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomPubOutOfLineCategories"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubOutOfLineCategories(XElement element) : base(element) { }

    /// <summary>Gets or sets the location to an Atom Publishing Category Document.</summary>
    /// <value>A <see cref="string"/> representing the location to an Atom Publishing Category Document.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
    public string Href
    {
      get { return (string)this.Element.Attribute("href"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.Element.SetAttributeValue("href", value);
      }
    }

    /// <summary>Loads an <see cref="AtomPubInlineCategories"/> from the location represented by this node.</summary>
    /// <returns>An <see cref="AtomPubInlineCategories"/> loaded from the location represented by <see cref="Href"/>.</returns>
    public AtomPubInlineCategories Load()
    {
      return AtomPubCategories.Load(this.Href);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubOutOfLineCategories"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubOutOfLineCategories"/>.</param>
    /// <returns>An <see cref="AtomPubOutOfLineCategories"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubOutOfLineCategories(XElement element)
    {
      return element == null ? null : new AtomPubOutOfLineCategories(element);
    }
  }
}
