using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NS84.Syndication.Atom.Publication
{
  /// <summary>Represents control information about an Atom entry.</summary>
  public class AtomPubControl : AtomPubExtensionContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubControl"/> class.</summary>
    public AtomPubControl() : this((bool?)null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubControl"/> class with a value indicating with the entry is a draft.</summary>
    /// <param name="draft">A value indicating whether the entry is a draft.</param>
    public AtomPubControl(bool? draft) { }

    /// <summary>Initializes a new instance of the <see cref="AtomPubControl"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubControl(XElement element) : base(element) { }

    /// <summary>Gets or sets a value indicating whether the entry is a draft.</summary>
    /// <value>True if the entry is a draft; otherwise, false.</value>
    public bool? Draft
    {
      get
      {
        string draft = (string)this.Element.Element(AtomPubNamespace + "draft");
        return draft == null ? (bool?)null : draft == "yes";
      }

      set { this.Element.SetElementValue(AtomPubNamespace + "draft", value.HasValue ? value.Value ? "yes" : "no" : null); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomPubControl"/>, this value is <see cref="AtomPubService.AtomPubNamespace"/> + "control".</value>
    protected override XName ElementName
    {
      get { return AtomPubNamespace + "control"; }
    }

    /// <summary>Returns a value indicating whether the specified <see cref="XElement"/> can be added.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be added; otherwise, false.</returns>
    protected override bool CanAddExtElement(XElement element)
    {
      return true;
    }

    /// <summary>Returns a value indicating whether the specified <see cref="XElement"/> can be removed.</summary>
    /// <param name="element">The <see cref="XElement"/> to test.</param>
    /// <returns>True if the specified <see cref="XElement"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveExtElement(XElement element)
    {
      return true;
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubControl"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubControl"/>.</param>
    /// <returns>An <see cref="AtomPubControl"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubControl(XElement element)
    {
      return element == null ? null : new AtomPubControl(element);
    }
  }
}
