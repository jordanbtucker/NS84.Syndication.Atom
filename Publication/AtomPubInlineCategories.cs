using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  /// <summary>Represents an Atom Publishing Category Document or the categories that can be applied to the members of an Atom Publishing Collection.</summary>
  public class AtomPubInlineCategories : AtomPubCategories
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubInlineCategories"/> class.</summary>
    public AtomPubInlineCategories() : this(null, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubInlineCategories"/> class with a specified value indicating whether the categories are fixed.</summary>
    /// <param name="@fixed">A value indicating whether the categories are fixed.</param>
    public AtomPubInlineCategories(bool? @fixed) : this(@fixed, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubInlineCategories"/> class with the specified scheme.</summary>
    /// <param name="scheme">A <see cref="string"/> representing the scheme.</param>
    public AtomPubInlineCategories(string scheme) : this(null, scheme) { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubInlineCategories"/> class with a specified value indicating whether the categories are fixed and the specified scheme.</summary>
    /// <param name="@fixed">A value indicating whether the categories are fixed.</param>
    /// <param name="scheme">A <see cref="string"/> representing the scheme.</param>
    public AtomPubInlineCategories(bool? @fixed, string scheme)
    {
      this.Fixed = @fixed;
      this.Scheme = scheme;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomPubInlineCategories"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubInlineCategories(XElement element) : base(element) { }

    /// <summary>Gets or sets a value indicating whether the categories are fixed.</summary>
    /// <value>True if the categories and fixed; otherwise, false.</value>
    public bool? Fixed
    {
      get
      {
        string @fixed = (string)this.Element.Attribute("fixed");
        return @fixed == null ? (bool?)null : @fixed == "yes";
      }

      set { this.Element.SetAttributeValue("fixed", value.HasValue ? value.Value ? "yes" : "no" : null); }
    }

    /// <summary>Gets or sets the scheme.</summary>
    /// <value>A <see cref="string"/> representing the scheme.</value>
    public string Scheme
    {
      get { return (string)this.Element.Attribute("scheme"); }
      set { this.Element.SetAttributeValue("scheme", value); }
    }

    /// <summary>Gets the categories that can be applied to the members of an Atom Publishing Collection.</summary>
    /// <value>An <see cref="IEnumerable{T}"/> of <see cref="AtomCategory"/> representing the categories that can be applied to the members of an Atom Publishing Collection.</value>
    public IEnumerable<AtomCategory> Categories
    {
      get { return this.Element.Elements(AtomFeed.AtomNamespace + "category").Select(e => (AtomCategory)e); }
    }

    /// <summary>Adds a category that can be applied to the members of an Atom Publishing Collection.</summary>
    /// <param name="category">An <see cref="AtomCategory"/> representing a category that can be applied to the members of an Atom Publishing Collection.</param>
    public void Add(AtomCategory category)
    {
      if(category == null) throw new ArgumentNullException("category");
      this.Element.Add((XElement)category);
    }

    /// <summary>Removes a category.</summary>
    /// <param name="category">The <see cref="AtomCategory"/> to remove.</param>
    public void Remove(AtomCategory category)
    {
      if(category == null) throw new ArgumentNullException("category");
      XElement element = (XElement)category;
      if(element.Parent == this.Element)
        element.Remove();
    }

    /// <summary>Returns the extension elements in this node.</summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="XElement"/> representing the extension elements in this node.</returns>
    public override IEnumerable<XElement> ExtElements()
    {
      return this.Element.Elements().Where(e => e.Name != AtomFeed.AtomNamespace + "category");
    }

    /// <summary>Saves this document to a file.</summary>
    /// <param name="path">A <see cref="string"/> representing the path of the file to save this document to.</param>
    public void Save(string path)
    {
      ((XElement)this).Save(path);
    }

    /// <summary>Saves this document to a <see cref="Stream"/>.</summary>
    /// <param name="stream">A <see cref="Stream"/> to save this document to.</param>
    public void Save(Stream stream)
    {
      this.Save(new StreamWriter(stream));
    }

    /// <summary>Saves this document to a <see cref="TextWriter"/>.</summary>
    /// <param name="writer">A <see cref="TextWriter"/> to save this document to.</param>
    public void Save(TextWriter writer)
    {
      ((XElement)this).Save(writer);
    }

    /// <summary>Saves this document to an <see cref="XmlWriter"/>.</summary>
    /// <param name="writer">An <see cref="XmlWriter"/> to save this document to.</param>
    public void Save(XmlWriter writer)
    {
      ((XElement)this).Save(writer);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubInlineCategories"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubInlineCategories"/>.</param>
    /// <returns>An <see cref="AtomPubInlineCategories"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubInlineCategories(XElement element)
    {
      return element == null ? null : new AtomPubInlineCategories(element);
    }
  }
}
