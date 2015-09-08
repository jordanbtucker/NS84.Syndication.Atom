using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  /// <summary>An abstract base class that represents an Atom Publishing node that can contain other nodes.</summary>
  public abstract class AtomPubNodeContainerNode : AtomPubExtensionContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubNodeContainerNode"/> class.</summary>
    protected AtomPubNodeContainerNode() { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubNodeContainerNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubNodeContainerNode(XElement element) : base(element) { }

    /// <summary>Adds or replaces the first child element with the specified <see cref="XName"/> with the specified <see cref="XElement"/>.</summary>
    /// <param name="name">An <see cref="XName"/> representing the name of the child element to be replaced.</param>
    /// <param name="element">The <see cref="XElement"/> to add or replace.</param>
    protected void SetSingleElement(XName name, XElement element)
    {
      XElement current = this.Element.Element(name);
      if(current == null) this.Element.Add(element);
      else current.ReplaceWith(element);
    }

    /// <summary>When overridden in a derived class, returns a value indicating whether the specified <see cref="AtomPubNode"/> can be added.</summary>
    /// <param name="node">The <see cref="AtomPubNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomPubNode"/> can be added; otherwise, false.</returns>
    protected abstract bool CanAddNode(AtomPubNode node);

    /// <summary>When overridden in a derived class, returns a value indicating whether the specified <see cref="AtomPubNode"/> can be removed.</summary>
    /// <param name="node">The <see cref="AtomPubNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomPubNode"/> can be removed; otherwise, false.</returns>
    protected abstract bool CanRemoveNode(AtomPubNode node);

    /// <summary>Adds the specified <see cref="AtomPubNode"/> to this node.</summary>
    /// <param name="node">The <see cref="AtomPubNode"/> to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="node"/> cannot be added.</exception>
    public void Add(AtomPubNode node)
    {
      if(node == null) throw new ArgumentNullException("node");
      if(this.CanAddNode(node) == false) throw new ArgumentException(Errors.CannotAddNode, "node");
      this.Element.Add((XElement)node);
    }

    /// <summary>Removes the specified <see cref="AtomPubNode"/> from this node.</summary>
    /// <param name="node">The <see cref="AtomPubNode"/> to remove.</param>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="node"/> cannot be removed.</exception>
    public void Remove(AtomPubNode node)
    {
      if(node == null) throw new ArgumentNullException("node");
      if(this.CanRemoveNode(node) == false) throw new ArgumentException(Errors.CannotRemoveNode, "node");
      XElement element = (XElement)node;
      if(element.Parent == this.Element)
        element.Remove();
    }
  }
}
