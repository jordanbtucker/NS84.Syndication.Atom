using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  public class AtomPubEdited : AtomPubNode
  {
    public AtomPubEdited(DateTime date)
    {
      this.Date = date;
    }

    protected AtomPubEdited(XElement element) : base(element) { }

    public DateTime Date
    {
      get { return (DateTime)this.Element; }
      set { this.Element.SetValue(value.ToString("yyyy-MM-ddTHH:mm:sszzz")); }
    }

    protected override XName ElementName
    {
      get { return AtomPubNamespace + "edited"; }
    }

    public override string ToString()
    {
      return this.Date.ToString();
    }

    public static implicit operator DateTime(AtomPubEdited node)
    {
      if(node == null) throw new ArgumentNullException("node");
      return node.Date;
    }

    public static implicit operator DateTime?(AtomPubEdited node)
    {
      return node == null ? (DateTime?)null : node.Date;
    }

    public static implicit operator AtomPubEdited(DateTime date)
    {
      return new AtomPubEdited(date);
    }

    public static implicit operator AtomPubEdited(DateTime? date)
    {
      return date == null ? null : new AtomPubEdited(date.Value);
    }

    public static implicit operator AtomPubEdited(XElement element)
    {
      return element == null ? null : new AtomPubEdited(element);
    }
  }
}
