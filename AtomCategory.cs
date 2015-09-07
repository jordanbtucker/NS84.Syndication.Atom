using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents a category of an Atom feed or entry.</summary>
  public class AtomCategory : AtomUndefinedContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomCategory"/> class with the specified term.</summary>
    /// <param name="term">A <see cref="string"/> representing the term.</param>
    public AtomCategory(string term) : this(term, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomCategory"/> class with the specified term and label.</summary>
    /// <param name="term">A <see cref="string"/> representing the term.</param>
    /// <param name="label">A <see cref="string"/> representing the label.</param>
    public AtomCategory(string term, string label) : this(term, label, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomCategory"/> class with the specified term, label, and scheme.</summary>
    /// <param name="term">A <see cref="string"/> representing the term.</param>
    /// <param name="label">A <see cref="string"/> representing the label.</param>
    /// <param name="scheme">A <see cref="string"/> representing the scheme.</param>
    public AtomCategory(string term, string label, string scheme)
    {
      if(term == null) throw new ArgumentNullException("term");
      if(term == "") throw new ArgumentException(Errors.EmptyString, "term");
      this.Term = term;
      this.Label = label;
      this.Scheme = scheme;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomCategory"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomCategory(XElement element) : base(element) { }

    /// <summary>Gets or sets the term of the category.</summary>
    /// <returns>A <see cref="string"/> representing the term of the category.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
    public string Term
    {
      get { return (string)this.Element.Attribute("term"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.Element.SetAttributeValue("term", value);
      }
    }

    /// <summary>Gets or sets the label of the category.</summary>
    /// <returns>A <see cref="string"/> representing the label of the category.</returns>
    public string Label
    {
      get { return (string)this.Element.Attribute("label"); }
      set { this.Element.SetAttributeValue("label", value); }
    }

    /// <summary>Gets or sets the scheme of the category.</summary>
    /// <returns>A <see cref="string"/> representing the scheme of the category.</returns>
    public string Scheme
    {
      get { return (string)this.Element.Attribute("scheme"); }
      set { this.Element.SetAttributeValue("scheme", value); }
    }

    /// <summary>Gets an <see cref="XName"/> representing the name of the underlying element.</summary>
    /// <returns>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomCategory"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "category".</returns>
    protected override XName ElementName
    {
      get { return AtomNamespace + "category"; }
    }

    /// <summary>Returns a <see cref="string"/> representing the term of the category.</summary>
    /// <returns>A <see cref="string"/> representing the term of the category.</returns>
    public override string ToString()
    {
      return this.Term;
    }

    /// <summary>Converts an <see cref="AtomCategory"/> to a <see cref="string"/>.</summary>
    /// <param name="node">An <see cref="AtomCategory"/> to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> converted from the specified <see cref="AtomCategory"/>.</returns>
    public static implicit operator string(AtomCategory node)
    {
      return node == null ? null : node.Term;
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomCategory"/>.</summary>
    /// <param name="term">A <see cref="string"/> to convert to an <see cref="AtomCategory"/>.</param>
    /// <returns>An <see cref="AtomCategory"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomCategory(string term)
    {
      return term == null ? null : new AtomCategory(term);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomCategory"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomCategory"/>.</param>
    /// <returns>An <see cref="AtomCategory"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomCategory(XElement element)
    {
      return element == null ? null : new AtomCategory(element);
    }
  }
}
