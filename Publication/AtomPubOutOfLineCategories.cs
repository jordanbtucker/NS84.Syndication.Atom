using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  [DebuggerDisplay("Href = {Href}")]
  public class AtomPubOutOfLineCategories : AtomPubCategories
  {
    public AtomPubOutOfLineCategories(string href)
    {
      this.Href = href;
    }

    protected AtomPubOutOfLineCategories(XElement element) : base(element) { }

    public string Href
    {
      get { return (string)this.Element.Attribute("href"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.Element.SetAttributeValue("href", value);
      }
    }

    public static implicit operator AtomPubOutOfLineCategories(XElement element)
    {
      return element == null ? null : new AtomPubOutOfLineCategories(element);
    }
  }
}
