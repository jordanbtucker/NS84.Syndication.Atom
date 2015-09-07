using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public class AtomPubControl : AtomPubExtensionContainerNode
  {
    public AtomPubControl() : this((bool?)null) { }

    public AtomPubControl(bool? draft) { }

    protected AtomPubControl(XElement element) : base(element) { }

    public bool? Draft
    {
      get
      {
        string draft = (string)this.Element.Element(AtomPubNamespace + "draft");
        return draft == null ? (bool?)null : draft == "yes";
      }

      set { this.Element.SetElementValue(AtomPubNamespace + "draft", value.HasValue ? value.Value ? "yes" : "no" : null); }
    }

    protected override XName ElementName
    {
      get { return AtomPubNamespace + "control"; }
    }

    protected override bool CanAddExtElement(XElement element)
    {
      return true;
    }

    protected override bool CanRemoveExtElement(XElement element)
    {
      return true;
    }

    public static implicit operator AtomPubControl(XElement element)
    {
      return element == null ? null : new AtomPubControl(element);
    }
  }
}
