using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>An abstract base class that represents an Atom node whose content is undefined.</summary>
  public abstract class AtomUndefinedContainerNode : AtomNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomUndefinedContainerNode"/> class.</summary>
    protected AtomUndefinedContainerNode() { }

    /// <summary>Initializes a new instance of the <see cref="AtomUndefinedContainerNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomUndefinedContainerNode(XElement element) : base(element) { }

    /// <summary>Returns an <see cref="XElement"/> representing the first extension element with the specified <see cref="XName"/>.</summary>
    /// <param name="name">An <see cref="XName"/> representing the name of the extension element.</param>
    /// <returns>An <see cref="XElement"/> representing the first extension element with the specified <see cref="XName"/> if one exists; otherwise, null.</returns>
    public XElement ExtElement(XName name)
    {
      return this.Element.Element(name);
    }

    /// <summary>Returns an <see cref="IEnumerable&lt;T&gt;"/> of <see cref="XElement"/> representing the extension elements in this node.</summary>
    /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> of <see cref="XElement"/> representing the extension elements in this node.</returns>
    public IEnumerable<XElement> ExtElements()
    {
      return this.Element.Elements();
    }

    /// <summary>Returns an <see cref="IEnumerable&lt;T&gt;"/> of <see cref="XElement"/> representing the extension elements with the specified <see cref="XName"/>.</summary>
    /// <param name="name">An <see cref="XName"/> representing the name of the extension elements.</param>
    /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> of <see cref="XElement"/> representing the extension elements with the specified <see cref="XName"/>.</returns>
    public IEnumerable<XElement> ExtElements(XName name)
    {
      return this.Element.Elements(name);
    }

    /// <summary>Adds the specified <see cref="XElement"/> to this node as an extension element.</summary>
    /// <param name="extElement">The <see cref="XElement"/> to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="extElement"/> is null.</exception>
    public void Add(XElement extElement)
    {
      if(extElement == null) throw new ArgumentNullException("extElement");
      this.Element.Add(extElement);
    }

    /// <summary>Removes the specified <see cref="XElement"/> from this node as an extension element.</summary>
    /// <param name="extElement">The <see cref="XElement"/> to remove.</param>
    /// <exception cref="ArgumentNullException"><paramref name="extElement"/> is null.</exception>
    public void Remove(XElement extElement)
    {
      if(extElement == null) throw new ArgumentNullException("extElement");
      if(extElement.Parent == this.Element)
        extElement.Remove();
    }
  }
}
