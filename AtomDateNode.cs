using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>An abstract base class that represents date and time based Atom nodes.</summary>
  [DebuggerDisplay("Date = {Date}")]
  public abstract class AtomDateNode : AtomNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomDateNode"/> class with the specified date and time.</summary>
    /// <param name="date">A <see cref="DateTime"/> representing the date and time.</param>
    protected AtomDateNode(DateTime date)
    {
      this.Date = date;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomDateNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomDateNode(XElement element) : base(element) { }

    /// <summary>Gets or sets the date and time of this node.</summary>
    /// <value>A <see cref="DateTime"/> representing the date and time of this node.</value>
    public DateTime Date
    {
      get { return (DateTime)this.Element; }
      set { this.Element.SetValue(value.ToString(value.Kind == DateTimeKind.Utc ? "yyyy-MM-ddTHH:mm:ssZ" : "yyyy-MM-ddTHH:mm:sszzz")); }
    }

    /// <summary>Returns a <see cref="string"/> representing the date and time of this node.</summary>
    /// <returns>A <see cref="string"/> representing the date and time of this node.</returns>
    public override string ToString()
    {
      return this.Date.ToString();
    }

    /// <summary>Converts an <see cref="AtomDateNode"/> to a <see cref="DateTime"/>.</summary>
    /// <param name="node">An <see cref="AtomDateNode"/> to convert to a <see cref="DateTime"/>.</param>
    /// <returns>A <see cref="DateTime"/> converted from the specified <see cref="AtomDateNode"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is null.</exception>
    public static implicit operator DateTime(AtomDateNode node)
    {
      if(node == null) throw new ArgumentNullException("node");
      return node.Date;
    }

    /// <summary>Converts an <see cref="AtomDateNode"/> to a <see cref="Nullable{T}"/> of <see cref="DateTime"/>.</summary>
    /// <param name="node">An <see cref="AtomDateNode"/> to convert to a <see cref="Nullable{T}"/> of <see cref="DateTime"/>.</param>
    /// <returns>A <see cref="Nullable{T}"/> of <see cref="DateTime"/> converted from the specified <see cref="AtomDateNode"/>.</returns>
    public static implicit operator DateTime?(AtomDateNode node)
    {
      return node == null ? (DateTime?)null : node.Date;
    }
  }
}
