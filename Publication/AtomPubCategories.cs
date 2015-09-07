using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public abstract class AtomPubCategories : AtomPubExtensionContainerNode
  {
    protected AtomPubCategories() { }

    protected AtomPubCategories(XElement element) : base(element) { }

    public static AtomPubInlineCategories Load(string uri)
    {
      return (AtomPubInlineCategories)XElement.Load(uri);
    }

    public static AtomPubInlineCategories Load(Stream stream)
    {
      return Load(new StreamReader(stream));
    }

    public static AtomPubInlineCategories Load(TextReader reader)
    {
      return (AtomPubInlineCategories)XElement.Load(reader);
    }

    public static AtomPubInlineCategories Load(XmlReader reader)
    {
      return (AtomPubInlineCategories)XElement.Load(reader);
    }

    public static AtomPubInlineCategories LoadXml(string xml)
    {
      return (AtomPubInlineCategories)XElement.Parse(xml);
    }

    protected override XName ElementName
    {
      get { return AtomPubNamespace + "categories"; }
    }

    protected override bool CanAddExtElement(XElement element)
    {
      return element.Name != AtomFeed.AtomNamespace + "category";
    }

    protected override bool CanRemoveExtElement(XElement element)
    {
      return element.Name != AtomFeed.AtomNamespace + "category";
    }

    public static implicit operator AtomPubCategories(XElement element)
    {
      if(element == null) return null;
      if(element.Attribute("href") == null) return (AtomPubInlineCategories)element;
      return (AtomPubOutOfLineCategories)element;
    }
  }
}
