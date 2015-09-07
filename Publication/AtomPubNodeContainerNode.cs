using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public abstract class AtomPubNodeContainerNode : AtomPubExtensionContainerNode
  {
    protected AtomPubNodeContainerNode() { }

    protected AtomPubNodeContainerNode(XElement element) : base(element) { }

    protected void SetSingleElement(XName name, XElement element)
    {
      XElement current = this.Element.Element(name);
      if(current == null) this.Element.Add(element);
      else current.ReplaceWith(element);
    }

    protected abstract bool CanAddNode(AtomPubNode node);

    protected abstract bool CanRemoveNode(AtomPubNode node);

    public void Add(AtomPubNode node)
    {
      if(node == null) throw new ArgumentNullException("node");
      if(this.CanAddNode(node) == false) throw new ArgumentException(Errors.CannotAddNode, "node");
      this.Element.Add((XElement)node);
    }

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
