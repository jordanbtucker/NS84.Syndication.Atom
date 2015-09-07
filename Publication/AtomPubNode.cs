using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public abstract class AtomPubNode
  {
    protected static readonly XNamespace AtomPubNamespace = Resources.AtomPubNamespace;

    private XElement element;

    protected AtomPubNode()
    {
      this.element = new XElement(this.ElementName);
    }

    protected AtomPubNode(XElement element)
    {
      if(element.Name != this.ElementName) throw new ArgumentException(string.Format(Errors.WrongElementName, this.GetType(), element.Name), "element");
      this.element = element;
    }

    protected XElement Element
    {
      get { return this.element; }
    }

    protected abstract XName ElementName { get; }

    public string BaseUri
    {
      get { return (string)this.Element.Attribute(XNamespace.Xml + "base"); }
      set { this.Element.SetAttributeValue(XNamespace.Xml + "base", value); }
    }

    public string Language
    {
      get { return (string)this.Element.Attribute(XNamespace.Xml + "lang"); }
      set { this.Element.SetAttributeValue(XNamespace.Xml + "lang", value); }
    }

    public AtomPubWhitespace Whitespace
    {
      get
      {
        XAttribute whitespace = this.Element.Attribute(XNamespace.Xml + "space");
        return whitespace == null ? AtomPubWhitespace.None : (AtomPubWhitespace)Enum.Parse(typeof(AtomPubWhitespace), (string)whitespace, true);
      }

      set { this.Element.SetAttributeValue(XNamespace.Xml + "space", value == AtomPubWhitespace.None ? null : value.ToString().ToLower()); }
    }

    public XAttribute ExtAttribute(XName name)
    {
      return this.ExtAttributes().FirstOrDefault(a => a.Name == name);
    }

    public IEnumerable<XAttribute> ExtAttributes()
    {
      return this.Element.Attributes().Where(a => a.Name != XNamespace.Xml + "base" && a.Name != XNamespace.Xml + "lang" && a.Name != XNamespace.Xml + "space" && a.Name.NamespaceName != "");
    }

    public IEnumerable<XAttribute> ExtAttributes(XName name)
    {
      return this.ExtAttributes().Where(a => a.Name == name);
    }

    public void Add(XAttribute extAttribute)
    {
      if(extAttribute == null) throw new ArgumentNullException("extAttribute");
      if(extAttribute.Name.Namespace == AtomPubNamespace) throw new ArgumentException(Errors.AttributeAtomPubNamespace, "extAttribute");
      if(extAttribute.Name.NamespaceName == "") throw new ArgumentException(Errors.AttributeNoNamespace, "extAttribute");
      this.Element.Add(extAttribute);
    }

    public void Remove(XAttribute extAttribute)
    {
      if(extAttribute.Name.Namespace == AtomPubNamespace) throw new ArgumentException(Errors.AttributeAtomPubNamespace, "extAttribute");
      if(extAttribute.Name.NamespaceName == "") throw new ArgumentException(Errors.AttributeNoNamespace, "extAttribute");
      if(extAttribute.Parent == this.Element)
        extAttribute.Remove();
    }

    public override bool Equals(object obj)
    {
      if(obj == null) return false;
      AtomPubNode node = obj as AtomPubNode;
      return (object)node == null ? false : node.Element == this.Element;
    }

    public override int GetHashCode()
    {
      return this.Element.GetHashCode();
    }

    public override string ToString()
    {
      return this.Element.ToString();
    }

    public string ToXml()
    {
      return this.Element.ToString();
    }

    public static bool operator ==(AtomPubNode a, AtomPubNode b)
    {
      if(object.ReferenceEquals(a, b)) return true;
      if((object)a == null || (object)b == null) return false;
      return a.Element == b.Element;
    }

    public static bool operator !=(AtomPubNode a, AtomPubNode b)
    {
      return (a == b) == false;
    }

    public static implicit operator XElement(AtomPubNode node)
    {
      return node == null ? null : node.element;
    }
  }
}
