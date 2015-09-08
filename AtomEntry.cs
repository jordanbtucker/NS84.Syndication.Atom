using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using NerdSince1984.Syndication.Atom.Publication;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents an Atom Entry Document or an entry in an Atom Feed Document.</summary>
  public class AtomEntry : AtomEntryNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomEntry"/> class with an ID, title, and date and time when the entry was last updated.</summary>
    /// <param name="id">An <see cref="AtomId"/> representing the ID of the entry.</param>
    /// <param name="title">An <see cref="AtomTitle"/> representing the title of the entry.</param>
    /// <param name="updated">An <see cref="AtomUpdated"/> representing the date and time when the entry was last updated.</param>
    /// <exception cref="ArgumentNullException"><paramref name="id"/>, <paramref name="title"/>, or <paramref name="updated"/> is null.</exception>
    public AtomEntry(AtomId id, AtomTitle title, AtomUpdated updated)
      : base(id, title, updated)
    {
      if(id == null) throw new ArgumentNullException("id");
      if(title == null) throw new ArgumentNullException("title");
      if(updated == null) throw new ArgumentNullException("updated");
    }

    /// <summary>Initializes a new instance of the <see cref="AtomEntry"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the entry from.</param>
    protected AtomEntry(XElement element) : base(element) { }

    /// <summary>Loads an <see cref="AtomEntry"/> from a file.</summary>
    /// <param name="uri">A <see cref="string"/> representing the URI of the file to load the document from.</param>
    /// <returns>An <see cref="AtomEntry"/> loaded from the specified file.</returns>
    public static AtomEntry Load(string uri)
    {
      return (AtomEntry)XElement.Load(uri);
    }

    /// <summary>Loads an <see cref="AtomEntry"/> from a <see cref="Stream"/>.</summary>
    /// <param name="stream">A <see cref="Stream"/> to load the document from.</param>
    /// <returns>An <see cref="AtomEntry"/> loaded from the specified <see cref="Stream"/>.</returns>
    public static AtomEntry Load(Stream stream)
    {
      return Load(new StreamReader(stream));
    }

    /// <summary>Loads an <see cref="AtomEntry"/> from a <see cref="TextReader"/>.</summary>
    /// <param name="reader">A <see cref="TextReader"/> to load the document from.</param>
    /// <returns>An <see cref="AtomEntry"/> loaded from the specified <see cref="TextReader"/>.</returns>
    public static AtomEntry Load(TextReader reader)
    {
      return (AtomEntry)XElement.Load(reader);
    }

    /// <summary>Loads an <see cref="AtomEntry"/> from an <see cref="XmlReader"/>.</summary>
    /// <param name="reader">An <see cref="XmlReader"/> to load the document from.</param>
    /// <returns>An <see cref="AtomEntry"/> loaded from the specified <see cref="XmlReader"/>.</returns>
    public static AtomEntry Load(XmlReader reader)
    {
      return (AtomEntry)XElement.Load(reader);
    }

    /// <summary>Loads an <see cref="AtomEntry"/> from XML.</summary>
    /// <param name="xml">A <see cref="string"/> representing XML to load the document from.</param>
    /// <returns>An <see cref="AtomEntry"/> loaded from the specified XML.</returns>
    public static AtomEntry LoadXml(string xml)
    {
      return (AtomEntry)XElement.Parse(xml);
    }

    /// <summary>Saves this document to a file.</summary>
    /// <param name="path">A <see cref="string"/> representing the path of the file to save this document to.</param>
    public virtual void Save(string path)
    {
      ((XElement)this).Save(path);
    }

    /// <summary>Saves this document to a <see cref="Stream"/>.</summary>
    /// <param name="stream">A <see cref="Stream"/> to save this document to.</param>
    public virtual void Save(Stream stream)
    {
      this.Save(new StreamWriter(stream));
    }

    /// <summary>Saves this document to a <see cref="TextWriter"/>.</summary>
    /// <param name="writer">A <see cref="TextWriter"/> to save this document to.</param>
    public virtual void Save(TextWriter writer)
    {
      ((XElement)this).Save(writer);
    }

    /// <summary>Saves this document to an <see cref="XmlWriter"/>.</summary>
    /// <param name="writer">An <see cref="XmlWriter"/> to save this document to.</param>
    public virtual void Save(XmlWriter writer)
    {
      ((XElement)this).Save(writer);
    }

    /// <summary>Gets or sets the ID of this entry.</summary>
    /// <value>An <see cref="AtomId"/> representing the ID of this entry.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    public override AtomId Id
    {
      get { return this.Element.Element(AtomNamespace + "id"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        this.SetSingleElement(AtomNamespace + "id", value);
      }
    }

    /// <summary>Gets or sets the title of this entry.</summary>
    /// <value>An <see cref="AtomTitle"/> representing the title of this entry.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    public override AtomTitle Title
    {
      get { return this.Element.Element(AtomNamespace + "title"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        this.SetSingleElement(AtomNamespace + "title", value);
      }
    }

    /// <summary>Gets or sets the date and time when this entry was last updated.</summary>
    /// <value>An <see cref="AtomUpdated"/> representing the date and time when this entry was last updated.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    public override AtomUpdated Updated
    {
      get { return this.Element.Element(AtomNamespace + "updated"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        this.SetSingleElement(AtomNamespace + "updated", value);
      }
    }

    /// <summary>Gets or sets the content of this entry.</summary>
    /// <value>An <see cref="AtomContent"/> representing the content of this entry.</value>
    public virtual AtomContent Content
    {
      get { return (AtomContent)this.Element.Element(AtomNamespace + "content"); }
      set { this.SetSingleElement(AtomNamespace + "content", value); }
    }

    /// <summary>Gets or sets the date and time when this entry was published.</summary>
    /// <value>An <see cref="AtomPublished"/> representing the date and time when this entry was published.</value>
    public virtual AtomPublished Published
    {
      get { return this.Element.Element(AtomNamespace + "published"); }
      set { this.SetSingleElement(AtomNamespace + "published", value); }
    }

    /// <summary>Gets or sets the source of this entry.</summary>
    /// <value>An <see cref="AtomSource"/> representing the source of this entry.</value>
    public virtual AtomSource Source
    {
      get { return this.Element.Element(AtomNamespace + "source"); }
      set { this.SetSingleElement(AtomNamespace + "source", value); }
    }

    /// <summary>Gets or sets the summary of this entry.</summary>
    /// <value>An <see cref="AtomSummary"/> representing the summary of this entry.</value>
    public virtual AtomSummary Summary
    {
      get { return this.Element.Element(AtomNamespace + "summary"); }
      set { this.SetSingleElement(AtomNamespace + "summary", value); }
    }

    /// <summary>Gets or sets the date and time when this entry was last edited.</summary>
    /// <value>An <see cref="AtomPubEdited"/> representing the date and time when this entry was last edited.</value>
    public virtual AtomPubEdited Edited
    {
      get { return this.Element.Element(AtomPubService.AtomPubNamespace + "edited"); }
      set { this.SetSingleElement(AtomPubService.AtomPubNamespace + "edited", value); }
    }

    /// <summary>Gets or sets the control properties of this entry.</summary>
    /// <value>An <see cref="AtomPubControl"/> representing the control properties of this entry.</value>
    public virtual AtomPubControl Control
    {
      get { return this.Element.Element(AtomPubService.AtomPubNamespace + "control"); }
      set { this.SetSingleElement(AtomPubService.AtomPubNamespace + "control", value); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomEntry"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "entry".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "entry"; }
    }

    /// <summary>Returns a value indicating whether the specified <see cref="AtomNode"/> can be removed.</summary>
    /// <param name="node">The <see cref="AtomNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomNode"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveNode(AtomNode node)
    {
      return (node is AtomId || node is AtomTitle || node is AtomUpdated) == false;
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomEntry"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomEntry"/>.</param>
    /// <returns>An <see cref="AtomEntry"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomEntry(XElement element)
    {
      return element == null ? null : new AtomEntry(element);
    }
  }
}
