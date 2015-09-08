using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NS84.Syndication.Atom.Publication
{
  /// <summary>Represents an Atom Publishing Service Document.</summary>
  public class AtomPubService : AtomPubNodeContainerNode
  {
    /// <summary>Represents the Atom Publishing namespace (http://www.w3.org/2007/app). This field is read-only.</summary>
    public new static readonly XNamespace AtomPubNamespace = AtomPubNode.AtomPubNamespace;

    /// <summary>Initializes a new instance of the <see cref="AtomPubService"/> class.</summary>
    public AtomPubService() { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubService"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubService(XElement element) : base(element) { }

    /// <summary>Loads an <see cref="AtomPubService"/> from a file.</summary>
    /// <param name="uri">A <see cref="string"/> representing the URI of the file to load the document from.</param>
    /// <returns>An <see cref="AtomPubService"/> loaded from the specified file.</returns>
    public static AtomPubService Load(string uri)
    {
      return (AtomPubService)XElement.Load(uri);
    }

    /// <summary>Loads an <see cref="AtomPubService"/> from a <see cref="Stream"/>.</summary>
    /// <param name="stream">A <see cref="Stream"/> to load the document from.</param>
    /// <returns>An <see cref="AtomPubService"/> loaded from the specified <see cref="Stream"/>.</returns>
    public static AtomPubService Load(Stream stream)
    {
      return Load(new StreamReader(stream));
    }

    /// <summary>Loads an <see cref="AtomPubService"/> from a <see cref="TextReader"/>.</summary>
    /// <param name="reader">A <see cref="TextReader"/> to load the document from.</param>
    /// <returns>An <see cref="AtomPubService"/> loaded from the specified <see cref="TextReader"/>.</returns>
    public static AtomPubService Load(TextReader reader)
    {
      return (AtomPubService)XElement.Load(reader);
    }

    /// <summary>Loads an <see cref="AtomPubService"/> from an <see cref="XmlReader"/>.</summary>
    /// <param name="reader">An <see cref="XmlReader"/> to load the document from.</param>
    /// <returns>An <see cref="AtomPubService"/> loaded from the specified <see cref="XmlReader"/>.</returns>
    public static AtomPubService Load(XmlReader reader)
    {
      return (AtomPubService)XElement.Load(reader);
    }

    /// <summary>Loads an <see cref="AtomPubService"/> from XML.</summary>
    /// <param name="xml">A <see cref="string"/> representing XML to load the document from.</param>
    /// <returns>An <see cref="AtomPubService"/> loaded from the specified XML.</returns>
    public static AtomPubService LoadXml(string xml)
    {
      return (AtomPubService)XElement.Parse(xml);
    }

    /// <summary>Saves this document to a <see cref="Stream"/>.</summary>
    /// <param name="stream">A <see cref="Stream"/> to save this document to.</param>
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

    /// <summary>Gets the workspaces provided by this service.</summary>
    /// <value>An <see cref="IEnumerable{T}"/> of <see cref="AtomPubWorkspace"/> representing the workspaces provided by this service.</value>
    public IEnumerable<AtomPubWorkspace> Workspaces
    {
      get { return this.Element.Elements(AtomPubNamespace + "workspace").Select(e => (AtomPubWorkspace)e); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomPubService"/>, this value is <see cref="AtomPubNamespace"/> + "service".</value>
    protected override XName ElementName
    {
      get { return AtomPubNamespace + "service"; }
    }

    /// <summary>Returns a value indicating whether the specified <see cref="AtomPubNode"/> can be added.</summary>
    /// <param name="node">The <see cref="AtomPubNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomPubNode"/> can be added; otherwise, false.</returns>
    protected override bool CanAddNode(AtomPubNode node)
    {
      return node is AtomPubWorkspace;
    }

    /// <summary>Returns a value indicating whether the specified <see cref="AtomPubNode"/> can be removed.</summary>
    /// <param name="node">The <see cref="AtomPubNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomPubNode"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveNode(AtomPubNode node)
    {
      return true;
    }

    /// <summary>Returns a value indicating whether the specified <see cref="XElement"/> can be added.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be added; otherwise, false.</returns>
    protected override bool CanAddExtElement(XElement element)
    {
      return true;
    }

    /// <summary>Returns a value indicating whether the specified <see cref="XElement"/> can be removed.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveExtElement(XElement element)
    {
      return true;
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubService"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubService"/>.</param>
    /// <returns>An <see cref="AtomPubService"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubService(XElement element)
    {
      return element == null ? null : new AtomPubService(element);
    }
  }
}
