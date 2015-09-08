using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>Represents an Atom Feed Document.</summary>
  public class AtomFeed : AtomSource
  {
    /// <summary>Represents the Atom namespace (http://www.w3.org/2005/Atom). This field is read-only.</summary>
    public new static readonly XNamespace AtomNamespace = AtomNode.AtomNamespace;

    /// <summary>Initializes a new instance of the <see cref="AtomFeed"/> class with an ID, title, and date and time when the feed was last updated.</summary>
    /// <param name="id">An <see cref="AtomId"/> representing the ID of the feed.</param>
    /// <param name="title">An <see cref="AtomTitle"/> representing the title of the feed.</param>
    /// <param name="updated">An <see cref="AtomUpdated"/> representing the date and time when the feed was last updated.</param>
    /// <exception cref="ArgumentNullException"><paramref name="id"/>, <paramref name="title"/>, or <paramref name="updated"/> is null.</exception>
    public AtomFeed(AtomId id, AtomTitle title, AtomUpdated updated)
      : base(id, title, updated)
    {
      if(id == null) throw new ArgumentNullException("id");
      if(title == null) throw new ArgumentNullException("title");
      if(updated == null) throw new ArgumentNullException("updated");
      base.Generator = new AtomGenerator();
    }

    /// <summary>Initializes a new instance of the <see cref="AtomFeed"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the feed from.</param>
    protected AtomFeed(XElement element) : base(element) { }

    /// <summary>Loads an <see cref="AtomFeed"/> from a file.</summary>
    /// <param name="uri">A <see cref="string"/> representing the URI of the file to load the document from.</param>
    /// <returns>An <see cref="AtomFeed"/> loaded from the specified file.</returns>
    public static AtomFeed Load(string uri)
    {
      return (AtomFeed)XElement.Load(uri);
    }

    /// <summary>Loads an <see cref="AtomFeed"/> from a <see cref="Stream"/>.</summary>
    /// <param name="stream">A <see cref="Stream"/> to load the document from.</param>
    /// <returns>An <see cref="AtomFeed"/> loaded from the specified <see cref="Stream"/>.</returns>
    public static AtomFeed Load(Stream stream)
    {
      return Load(new StreamReader(stream));
    }

    /// <summary>Loads an <see cref="AtomFeed"/> from a <see cref="TextReader"/>.</summary>
    /// <param name="reader">A <see cref="TextReader"/> to load the document from.</param>
    /// <returns>An <see cref="AtomFeed"/> loaded from the specified <see cref="TextReader"/>.</returns>
    public static AtomFeed Load(TextReader reader)
    {
      return (AtomFeed)XElement.Load(reader);
    }

    /// <summary>Loads an <see cref="AtomFeed"/> from an <see cref="XmlReader"/>.</summary>
    /// <param name="reader">An <see cref="XmlReader"/> to load the document from.</param>
    /// <returns>An <see cref="AtomFeed"/> loaded from the specified <see cref="XmlReader"/>.</returns>
    public static AtomFeed Load(XmlReader reader)
    {
      return (AtomFeed)XElement.Load(reader);
    }

    /// <summary>Loads an <see cref="AtomFeed"/> from XML.</summary>
    /// <param name="xml">A <see cref="string"/> representing XML to load the document from.</param>
    /// <returns>An <see cref="AtomFeed"/> loaded from the specified XML.</returns>
    public static AtomFeed LoadXml(string xml)
    {
      return (AtomFeed)XElement.Parse(xml);
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

    /// <summary>Gets or sets the ID of this feed.</summary>
    /// <value>An <see cref="AtomId"/> representing the ID of this feed.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    public override AtomId Id
    {
      get { return base.Id; }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        base.Id = value;
      }
    }

    /// <summary>Gets or sets the title of this feed.</summary>
    /// <value>An <see cref="AtomTitle"/> representing the title of this feed.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    public override AtomTitle Title
    {
      get { return base.Title; }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        base.Title = value;
      }
    }

    /// <summary>Gets or sets the date and time when this feed was last updated.</summary>
    /// <value>An <see cref="AtomUpdated"/> representing the date and time when this feed was last updated.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    public override AtomUpdated Updated
    {
      get { return base.Updated; }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        base.Updated = value;
      }
    }

    /// <summary>Gets the entries in this feed.</summary>
    /// <value>An <see cref="IEnumerable{T}"/> of <see cref="AtomEntry"/> representing the entries in this feed.</value>
    public IEnumerable<AtomEntry> Entries
    {
      get { return this.Element.Elements(AtomNamespace + "entry").Select(e => (AtomEntry)e); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomFeed"/>, this value is <see cref="AtomNamespace"/> + "feed".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "feed"; }
    }

    /// <summary>Returns a value indicating whether the specified <see cref="AtomNode"/> can be added.</summary>
    /// <param name="node">The <see cref="AtomNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomNode"/> can be added; otherwise, false.</returns>
    protected override bool CanAddNode(AtomNode node)
    {
      return base.CanAddNode(node) || node is AtomEntry;
    }

    /// <summary>Returns a value indicating whether the specified <see cref="AtomNode"/> can be removed.</summary>
    /// <param name="node">The <see cref="AtomNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomNode"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveNode(AtomNode node)
    {
      return (node is AtomId || node is AtomTitle || node is AtomUpdated) == false;
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomFeed"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomFeed"/>.</param>
    /// <returns>An <see cref="AtomFeed"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomFeed(XElement element)
    {
      return element == null ? null : new AtomFeed(element);
    }
  }
}
