using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public class AtomPubAccept : AtomPubNode
  {
    public AtomPubAccept() : this("") { }

    public AtomPubAccept(string text)
    {
      this.Text = text ?? "";
    }

    protected AtomPubAccept(XElement element) : base(element) { }

    public string Text
    {
      get { return (string)this.Element; }
      set { this.Element.SetValue(value ?? ""); }
    }

    protected override XName ElementName
    {
      get { return AtomPubNamespace + "accept"; }
    }

    public override string ToString()
    {
      return this.Text;
    }

    public static implicit operator string(AtomPubAccept node)
    {
      return node == null ? null : node.Text;
    }

    public static implicit operator AtomPubAccept(string text)
    {
      return new AtomPubAccept(text);
    }

    public static implicit operator AtomPubAccept(XElement element)
    {
      return element == null ? null : new AtomPubAccept(element);
    }
  }
}
