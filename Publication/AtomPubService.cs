using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public class AtomPubService : AtomPubNodeContainerNode
  {
    public new static readonly XNamespace AtomPubNamespace = AtomPubNode.AtomPubNamespace;

    public AtomPubService() { }

    protected AtomPubService(XElement element) : base(element) { }

    public static AtomPubService Load(string uri)
    {
      return (AtomPubService)XElement.Load(uri);
    }

    public static AtomPubService Load(Stream stream)
    {
      return Load(new StreamReader(stream));
    }

    public static AtomPubService Load(TextReader reader)
    {
      return (AtomPubService)XElement.Load(reader);
    }

    public static AtomPubService Load(XmlReader reader)
    {
      return (AtomPubService)XElement.Load(reader);
    }

    public static AtomPubService LoadXml(string xml)
    {
      return (AtomPubService)XElement.Parse(xml);
    }

    public void Save(string path)
    {
      ((XElement)this).Save(path);
    }

    public void Save(Stream stream)
    {
      this.Save(new StreamWriter(stream));
    }

    public void Save(TextWriter writer)
    {
      ((XElement)this).Save(writer);
    }

    public void Save(XmlWriter writer)
    {
      ((XElement)this).Save(writer);
    }

    public IEnumerable<AtomPubWorkspace> Workspaces
    {
      get { return this.Element.Elements(AtomPubNamespace + "workspace").Select(e => (AtomPubWorkspace)e); }
    }

    protected override XName ElementName
    {
      get { return AtomPubNamespace + "service"; }
    }

    protected override bool CanAddNode(AtomPubNode node)
    {
      return node is AtomPubWorkspace;
    }

    protected override bool CanRemoveNode(AtomPubNode node)
    {
      return true;
    }

    protected override bool CanAddExtElement(XElement element)
    {
      return true;
    }

    protected override bool CanRemoveExtElement(XElement element)
    {
      return true;
    }

    public static implicit operator AtomPubService(XElement element)
    {
      return element == null ? null : new AtomPubService(element);
    }
  }
}
