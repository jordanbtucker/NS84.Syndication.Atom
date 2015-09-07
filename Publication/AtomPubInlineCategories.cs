using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public class AtomPubInlineCategories : AtomPubCategories
  {
    public AtomPubInlineCategories() : this(null, null) { }

    public AtomPubInlineCategories(bool? @fixed) : this(@fixed, null) { }

    public AtomPubInlineCategories(string scheme) : this(null, scheme) { }

    public AtomPubInlineCategories(bool? @fixed, string scheme)
    {
      this.Fixed = @fixed;
      this.Scheme = scheme;
    }

    protected AtomPubInlineCategories(XElement element) : base(element) { }

    public bool? Fixed
    {
      get
      {
        string @fixed = (string)this.Element.Attribute("fixed");
        return @fixed == null ? (bool?)null : @fixed == "yes";
      }

      set { this.Element.SetAttributeValue("fixed", value.HasValue ? value.Value ? "yes" : "no" : null); }
    }

    public string Scheme
    {
      get { return (string)this.Element.Attribute("scheme"); }
      set { this.Element.SetAttributeValue("scheme", value); }
    }

    public IEnumerable<AtomCategory> Categories
    {
      get { return this.Element.Elements(AtomFeed.AtomNamespace + "category").Select(e => (AtomCategory)e); }
    }

    public void Add(AtomCategory category)
    {
      if(category == null) throw new ArgumentNullException("category");
      this.Element.Add((XElement)category);
    }

    public void Remove(AtomCategory category)
    {
      if(category == null) throw new ArgumentNullException("category");
      XElement element = (XElement)category;
      if(element.Parent == this.Element)
        element.Remove();
    }

    public override IEnumerable<XElement> ExtElements()
    {
      return this.Element.Elements().Where(e => e.Name != AtomFeed.AtomNamespace + "category");
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

    public static implicit operator AtomPubInlineCategories(XElement element)
    {
      return element == null ? null : new AtomPubInlineCategories(element);
    }
  }
}
