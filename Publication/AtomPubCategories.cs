using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NS84.Syndication.Atom.Publication
{
  /// <summary>Represents an Atom Publishing Category Document or the categories that can be applied to the members of an Atom Publishing Collection.</summary>
  public abstract class AtomPubCategories : AtomPubExtensionContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubCategories"/> class.</summary>
    protected AtomPubCategories() { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubCategories"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubCategories(XElement element) : base(element) { }

    /// <summary>Loads an <see cref="AtomPubInlineCategories"/> from a file.</summary>
    /// <param name="uri">A <see cref="string"/> representing the URI of the file to load the document from.</param>
    /// <returns>An <see cref="AtomPubInlineCategories"/> loaded from the specified file.</returns>
    public static AtomPubInlineCategories Load(string uri)
    {
      return (AtomPubInlineCategories)XElement.Load(uri);
    }

    /// <summary>Loads an <see cref="AtomPubInlineCategories"/> from a <see cref="Stream"/>.</summary>
    /// <param name="stream">A <see cref="Stream"/> to load the document from.</param>
    /// <returns>An <see cref="AtomPubInlineCategories"/> loaded from the specified <see cref="Stream"/>.</returns>
    public static AtomPubInlineCategories Load(Stream stream)
    {
      return Load(new StreamReader(stream));
    }

    /// <summary>Loads an <see cref="AtomPubInlineCategories"/> from a <see cref="TextReader"/>.</summary>
    /// <param name="reader">A <see cref="TextReader"/> to load the document from.</param>
    /// <returns>An <see cref="AtomPubInlineCategories"/> loaded from the specified <see cref="TextReader"/>.</returns>
    public static AtomPubInlineCategories Load(TextReader reader)
    {
      return (AtomPubInlineCategories)XElement.Load(reader);
    }

    /// <summary>Loads an <see cref="AtomPubInlineCategories"/> from an <see cref="XmlReader"/>.</summary>
    /// <param name="reader">An <see cref="XmlReader"/> to load the document from.</param>
    /// <returns>An <see cref="AtomPubInlineCategories"/> loaded from the specified <see cref="XmlReader"/>.</returns>
    public static AtomPubInlineCategories Load(XmlReader reader)
    {
      return (AtomPubInlineCategories)XElement.Load(reader);
    }

    /// <summary>Loads an <see cref="AtomPubInlineCategories"/> from XML.</summary>
    /// <param name="xml">A <see cref="string"/> representing XML to load the document from.</param>
    /// <returns>An <see cref="AtomPubInlineCategories"/> loaded from the specified XML.</returns>
    public static AtomPubInlineCategories LoadXml(string xml)
    {
      return (AtomPubInlineCategories)XElement.Parse(xml);
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomPubInlineCategories"/>, this value is <see cref="AtomPubService.AtomPubNamespace"/> + "categories".</value>
    protected override XName ElementName
    {
      get { return AtomPubNamespace + "categories"; }
    }

    /// <summary>Returns a value indicating whether the specified <see cref="XElement"/> can be added.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be added; otherwise, false.</returns>
    protected override bool CanAddExtElement(XElement element)
    {
      return element.Name != AtomFeed.AtomNamespace + "category";
    }

    /// <summary>Returns a value indicating whether the specified <see cref="XElement"/> can be removed.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveExtElement(XElement element)
    {
      return element.Name != AtomFeed.AtomNamespace + "category";
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubCategories"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubCategories"/>.</param>
    /// <returns>An <see cref="AtomPubCategories"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubCategories(XElement element)
    {
      if(element == null) return null;
      if(element.Attribute("href") == null) return (AtomPubInlineCategories)element;
      return (AtomPubOutOfLineCategories)element;
    }
  }
}
