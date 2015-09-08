using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  /// <summary>An abstract base class that represents an Atom Publishing node that can contain Atom extension nodes.</summary>
  public abstract class AtomPubExtensionContainerNode : AtomPubNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubExtensionContainerNode"/> class.</summary>
    protected AtomPubExtensionContainerNode() { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubExtensionContainerNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubExtensionContainerNode(XElement element) : base(element) { }

    /// <summary>Returns the first extension element with the specified <see cref="XName"/>.</summary>
    /// <param name="name">An <see cref="XName"/> representing the name of the extension element.</param>
    /// <returns>An <see cref="XElement"/> representing the first extension element with the specified <see cref="XName"/> if any exist; otherwise, null.</returns>
    public XElement ExtElement(XName name)
    {
      return this.ExtElements().FirstOrDefault(e => e.Name == name);
    }

    /// <summary>Returns the extension elements in this node.</summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="XElement"/> representing the extension elements in this node.</returns>
    public virtual IEnumerable<XElement> ExtElements()
    {
      return this.Element.Elements().Where(e => e.Name.Namespace != AtomPubNamespace);
    }

    /// <summary>Returns the extension elements with the specified <see cref="XName"/>.</summary>
    /// <param name="name">An <see cref="XName"/> representing the name of the extension elements.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="XElement"/> representing the extension elements with the specified <see cref="XName"/>.</returns>
    public IEnumerable<XElement> ExtElements(XName name)
    {
      return this.ExtElements().Where(e => e.Name == name);
    }

    /// <summary>When overridden in a derived class, returns a value indicating whether the specified <see cref="XElement"/> can be added.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be added; otherwise, false.</returns>
    protected abstract bool CanAddExtElement(XElement element);

    /// <summary>When overridden in a derived class, returns a value indicating whether the specified <see cref="XElement"/> can be removed.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be removed; otherwise, false.</returns>
    protected abstract bool CanRemoveExtElement(XElement element);

    /// <summary>Adds the specified <see cref="XElement"/> to this node as an extension element.</summary>
    /// <param name="extElement">The <see cref="XElement"/> to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="extElement"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="extElement"/> belongs to the Atom namespace.</exception>
    public void Add(XElement extElement)
    {
      if(extElement == null) throw new ArgumentNullException("extElement");
      if(extElement.Name.Namespace == AtomPubNamespace) throw new ArgumentException(Errors.ElementAtomPubNamespace, "extElement");
      if(this.CanAddExtElement(extElement) == false) throw new ArgumentException(Errors.CannotAddExtElement, "extElement");
      this.Element.Add(extElement);
    }

    /// <summary>Removes the specified <see cref="XElement"/> from this node as an extension element.</summary>
    /// <param name="extElement">The <see cref="XElement"/> to remove.</param>
    /// <exception cref="ArgumentNullException"><paramref name="extElement"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="extElement"/> belongs to the Atom namespace.</exception>
    public void Remove(XElement extElement)
    {
      if(extElement == null) throw new ArgumentNullException("extElement");
      if(extElement.Name.Namespace == AtomPubNamespace) throw new ArgumentException(Errors.ElementAtomPubNamespace, "extElement");
      if(this.CanRemoveExtElement(extElement) == false) throw new ArgumentException(Errors.CannotRemoveExtElement, "extElement");
      if(extElement.Parent == this.Element)
        extElement.Remove();
    }
  }
}
