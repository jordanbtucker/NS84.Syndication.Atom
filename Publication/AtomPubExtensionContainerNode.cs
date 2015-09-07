using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public abstract class AtomPubExtensionContainerNode : AtomPubNode
  {
    protected AtomPubExtensionContainerNode() { }

    protected AtomPubExtensionContainerNode(XElement element) : base(element) { }

    public XElement ExtElement(XName name)
    {
      return this.ExtElements().FirstOrDefault(e => e.Name == name);
    }

    public virtual IEnumerable<XElement> ExtElements()
    {
      return this.Element.Elements().Where(e => e.Name.Namespace != AtomPubNamespace);
    }

    public IEnumerable<XElement> ExtElements(XName name)
    {
      return this.ExtElements().Where(e => e.Name == name);
    }

    protected abstract bool CanAddExtElement(XElement element);

    protected abstract bool CanRemoveExtElement(XElement element);

    public void Add(XElement extElement)
    {
      if(extElement == null) throw new ArgumentNullException("extElement");
      if(extElement.Name.Namespace == AtomPubNamespace) throw new ArgumentException(Errors.ElementAtomPubNamespace, "extElement");
      if(this.CanAddExtElement(extElement) == false) throw new ArgumentException(Errors.CannotAddExtElement, "extElement");
      this.Element.Add(extElement);
    }

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
