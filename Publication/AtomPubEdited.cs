using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom.Publication
{
  /// <summary>Represents the date and time when an Atom feed or entry was last edited.</summary>
  public class AtomPubEdited : AtomPubNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPubEdited"/> class with the specified date and time.</summary>
    /// <param name="date">A <see cref="DateTime"/> representing the date and time.</param>
    public AtomPubEdited(DateTime date)
    {
      this.Date = date;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomPubEdited"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPubEdited(XElement element) : base(element) { }

    /// <summary>Gets or sets the date and time of this node.</summary>
    /// <value>A <see cref="DateTime"/> representing the date and time of this node.</value>
    public DateTime Date
    {
      get { return (DateTime)this.Element; }
      set { this.Element.SetValue(value.ToString("yyyy-MM-ddTHH:mm:sszzz")); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomPubEdited"/>, this value is <see cref="AtomPubService.AtomPubNamespace"/> + "edited".</value>
    protected override XName ElementName
    {
      get { return AtomPubNamespace + "edited"; }
    }

    /// <summary>Returns a <see cref="string"/> representing the date and time of this node.</summary>
    /// <returns>A <see cref="string"/> representing the date and time of this node.</returns>
    public override string ToString()
    {
      return this.Date.ToString();
    }

    /// <summary>Converts an <see cref="AtomPubEdited"/> to a <see cref="DateTime"/>.</summary>
    /// <param name="node">An <see cref="AtomPubEdited"/> to convert to a <see cref="DateTime"/>.</param>
    /// <returns>A <see cref="DateTime"/> converted from the specified <see cref="AtomPubEdited"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is null.</exception>
    public static implicit operator DateTime(AtomPubEdited node)
    {
      if(node == null) throw new ArgumentNullException("node");
      return node.Date;
    }

    /// <summary>Converts an <see cref="AtomPubEdited"/> to a <see cref="Nullable{T}"/> of <see cref="DateTime"/>.</summary>
    /// <param name="node">An <see cref="AtomPubEdited"/> to convert to a <see cref="Nullable{T}"/> of <see cref="DateTime"/>.</param>
    /// <returns>A <see cref="Nullable{T}"/> of <see cref="DateTime"/> converted from the specified <see cref="AtomPubEdited"/>.</returns>
    public static implicit operator DateTime?(AtomPubEdited node)
    {
      return node == null ? (DateTime?)null : node.Date;
    }

    /// <summary>Converts a <see cref="DateTime"/> to an <see cref="AtomPubEdited"/>.</summary>
    /// <param name="date">A <see cref="DateTime"/> to convert to an <see cref="AtomPubEdited"/>.</param>
    /// <returns>An <see cref="AtomPubEdited"/> converted from the specified <see cref="DateTime"/>.</returns>
    public static implicit operator AtomPubEdited(DateTime date)
    {
      return new AtomPubEdited(date);
    }

    /// <summary>Converts a <see cref="Nullable{T}"/> of <see cref="DateTime"/> to an <see cref="AtomPubEdited"/>.</summary>
    /// <param name="date">A <see cref="Nullable{T}"/> of <see cref="DateTime"/> to convert to an <see cref="AtomPubEdited"/>.</param>
    /// <returns>An <see cref="AtomPubEdited"/> converted from the specified <see cref="Nullable{T}"/> of <see cref="DateTime"/>.</returns>
    public static implicit operator AtomPubEdited(DateTime? date)
    {
      return date == null ? null : new AtomPubEdited(date.Value);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPubEdited"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPubEdited"/>.</param>
    /// <returns>An <see cref="AtomPubEdited"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPubEdited(XElement element)
    {
      return element == null ? null : new AtomPubEdited(element);
    }
  }
}
