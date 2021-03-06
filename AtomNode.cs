﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>An abstract base class that represents an Atom node.</summary>
  public abstract class AtomNode
  {
    /// <summary>Represents the Atom namespace (http://www.w3.org/2005/Atom). This field is read-only.</summary>
    protected static readonly XNamespace AtomNamespace = Resources.AtomNamespace;

    /// <summary>Represents the XHTML namespace (http://www.w3.org/1999/xhtml). This field is read-only.</summary>
    protected static readonly XNamespace XhtmlNamespace = Resources.XhtmlNamespace;

    private XElement element;

    /// <summary>Initializes a new instance of the <see cref="AtomNode"/> class.</summary>
    protected AtomNode()
    {
      this.element = new XElement(this.ElementName);
    }

    /// <summary>Initializes a new instance of the <see cref="AtomNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    /// <exception cref="ArgumentException">The name of <paramref name="element"/> does not match the <see cref="AtomNode.ElementName"/> of this node.</exception>
    protected AtomNode(XElement element)
    {
      if(element.Name != this.ElementName) throw new ArgumentException(string.Format(Errors.WrongElementName, this.GetType(), element.Name), "element");
      this.element = element;
    }

    /// <summary>Gets the underlying element of this node.</summary>
    /// <value>An <see cref="XElement"/> representing the underlying element of this node.</value>
    protected XElement Element
    {
      get { return this.element; }
    }

    /// <summary>When overridden in a derived class, gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element.</value>
    protected abstract XName ElementName { get; }

    /// <summary>Gets or sets the base URI of this node.</summary>
    /// <value>A <see cref="string"/> representing the base URI of this node.</value>
    public string BaseUri
    {
      get { return (string)this.Element.Attribute(XNamespace.Xml + "base"); }
      set { this.Element.SetAttributeValue(XNamespace.Xml + "base", value); }
    }

    /// <summary>Gets or sets the language of this node.</summary>
    /// <value>A <see cref="string"/> representing the language of this node.</value>
    public string Language
    {
      get { return (string)this.Element.Attribute(XNamespace.Xml + "lang"); }
      set { this.Element.SetAttributeValue(XNamespace.Xml + "lang", value); }
    }

    /// <summary>Returns the first extension attribute with the specified <see cref="XName"/>.</summary>
    /// <param name="name">An <see cref="XName"/> representing the name of the extension attribute.</param>
    /// <returns>An <see cref="XAttribute"/> representing the first extension attribute with the specified <see cref="XName"/> if any exist; otherwise, null.</returns>
    public XAttribute ExtAttribute(XName name)
    {
      return this.ExtAttributes().FirstOrDefault(a => a.Name == name);
    }

    /// <summary>Returns the extension attributes of this node.</summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="XAttribute"/> representing the extension attributes of this node.</returns>
    public IEnumerable<XAttribute> ExtAttributes()
    {
      return this.Element.Attributes().Where(a => a.Name != XNamespace.Xml + "base" && a.Name != XNamespace.Xml + "lang" && a.Name.NamespaceName != "");
    }

    /// <summary>Returns the extension attributes with the specified <see cref="XName"/>.</summary>
    /// <param name="name">An <see cref="XName"/> representing the name of the extension attributes.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="XAttribute"/> representing the extension attributes with the specified <see cref="XName"/>.</returns>
    public IEnumerable<XAttribute> ExtAttributes(XName name)
    {
      return this.ExtAttributes().Where(a => a.Name == name);
    }

    /// <summary>Adds the specified <see cref="XAttribute"/> to this node as an extension attribute.</summary>
    /// <param name="extAttribute">The <see cref="XAttribute"/> to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="extAttribute"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="extAttribute"/> belongs to the Atom or local namespace.</exception>
    public void Add(XAttribute extAttribute)
    {
      if(extAttribute == null) throw new ArgumentNullException("extAttribute");
      if(extAttribute.Name.Namespace == AtomNamespace) throw new ArgumentException(Errors.AttributeAtomNamespace, "extAttribute");
      if(extAttribute.Name.NamespaceName == "") throw new ArgumentException(Errors.AttributeNoNamespace, "extAttribute");
      this.Element.Add(extAttribute);
    }

    /// <summary>Removes the specified <see cref="XAttribute"/> from this node as an extension attribute.</summary>
    /// <param name="extAttribute">The <see cref="XAttribute"/> to remove.</param>
    /// <exception cref="ArgumentException"><paramref name="extAttribute"/> belongs to the Atom or local namespace.</exception>
    public void Remove(XAttribute extAttribute)
    {
      if(extAttribute.Name.Namespace == AtomNamespace) throw new ArgumentException(Errors.AttributeAtomNamespace, "extAttribute");
      if(extAttribute.Name.NamespaceName == "") throw new ArgumentException(Errors.AttributeNoNamespace, "extAttribute");
      if(extAttribute.Parent == this.Element)
        extAttribute.Remove();
    }

    /// <summary>Returns a value indicating whether the specified <see cref="object"/> is equal to this node.</summary>
    /// <param name="obj">The <see cref="object"/> to test.</param>
    /// <returns>True if <paramref name="obj"/> is equal to this node; otherwise, false.</returns>
    /// <remarks>This method first tests whether <paramref name="obj"/> and this node reference the same <see cref="AtomNode"/>, and if so returns true. If not, it tests whether the underlying elements of <paramref name="obj"/> and this node reference the same <see cref="XElement"/>.</remarks>
    public override bool Equals(object obj)
    {
      if(obj == null) return false;
      AtomNode node = obj as AtomNode;
      return (object)node == null ? false : node.Element == this.Element;
    }

    /// <summary>Returns a hash code for this node.</summary>
    /// <returns>An <see cref="Int32"/> representing the hash code for this node.</returns>
    public override int GetHashCode()
    {
      return this.Element.GetHashCode();
    }

    /// <summary>Returns the indented XML for this node.</summary>
    /// <returns>A <see cref="string"/> representing the indented XML for this node.</returns>
    public override string ToString()
    {
      return this.Element.ToString();
    }

    /// <summary>Returns the indented XML for this node.</summary>
    /// <returns>A <see cref="string"/> representing the indented XML for this node.</returns>
    public string ToXml()
    {
      return this.Element.ToString();
    }

    /// <summary>Returns a value indicating whether two instances of <see cref="AtomNode"/> are equal.</summary>
    /// <param name="a">The first <see cref="AtomNode"/> to test.</param>
    /// <param name="b">The second <see cref="AtomNode"/> to test.</param>
    /// <returns>True if <paramref name="a"/> is equal to <paramref name="b"/>; otherwise, false.</returns>
    /// <remarks>This operator first tests whether <paramref name="a"/> and <paramref name="b"/> reference the same <see cref="AtomNode"/>, and if so returns true. If not, it tests whether the underlying elements of <paramref name="a"/> and <paramref name="b"/> reference the same <see cref="XElement"/>.</remarks>
    public static bool operator ==(AtomNode a, AtomNode b)
    {
      if(object.ReferenceEquals(a, b)) return true;
      if((object)a == null || (object)b == null) return false;
      return a.Element == b.Element;
    }

    /// <summary>Returns a value indicating whether two instances of <see cref="AtomNode"/> are not equal.</summary>
    /// <param name="a">The first <see cref="AtomNode"/> to test.</param>
    /// <param name="b">The second <see cref="AtomNode"/> to test.</param>
    /// <returns>True if <paramref name="a"/> is not equal to <paramref name="b"/>; otherwise, false.</returns>
    public static bool operator !=(AtomNode a, AtomNode b)
    {
      return (a == b) == false;
    }

    /// <summary>Casts an <see cref="AtomNode"/> to an <see cref="XElement"/>.</summary>
    /// <param name="node">An <see cref="AtomNode"/> to cast to an <see cref="XElement"/>.</param>
    /// <returns>An <see cref="XElement"/> casted from the specified <see cref="AtomNode"/>.</returns>
    public static implicit operator XElement(AtomNode node)
    {
      return node == null ? null : node.element;
    }
  }
}
