using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the date and time when an Atom feed or entry was last updated.</summary>
  public class AtomUpdated : AtomDateNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomUpdated"/> class with the specified date and time.</summary>
    /// <param name="date">A <see cref="DateTime"/> representing the date and time.</param>
    public AtomUpdated(DateTime date) : base(date) { }

    /// <summary>Initializes a new instance of the <see cref="AtomUpdated"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomUpdated(XElement element) : base(element) { }

    /// <summary>Gets an <see cref="XName"/> representing the name of the underlying element.</summary>
    /// <returns>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomUpdated"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "updated".</returns>
    protected override XName ElementName
    {
      get { return AtomNamespace + "updated"; }
    }

    /// <summary>Converts a <see cref="DateTime"/> to an <see cref="AtomUpdated"/>.</summary>
    /// <param name="date">A <see cref="DateTime"/> to convert to an <see cref="AtomUpdated"/>.</param>
    /// <returns>An <see cref="AtomUpdated"/> converted from the specified <see cref="DateTime"/>.</returns>
    public static implicit operator AtomUpdated(DateTime date)
    {
      return new AtomUpdated(date);
    }

    /// <summary>Converts a <see cref="Nullable&lt;T&gt;"/> of <see cref="DateTime"/> to an <see cref="AtomUpdated"/>.</summary>
    /// <param name="date">A <see cref="Nullable&lt;T&gt;"/> of <see cref="DateTime"/> to convert to an <see cref="AtomUpdated"/>.</param>
    /// <returns>An <see cref="AtomUpdated"/> converted from the specified <see cref="Nullable&lt;T&gt;"/> of <see cref="DateTime"/>.</returns>
    public static implicit operator AtomUpdated(DateTime? date)
    {
      return date == null ? null : new AtomUpdated(date.Value);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomUpdated"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomUpdated"/>.</param>
    /// <returns>An <see cref="AtomUpdated"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomUpdated(XElement element)
    {
      return element == null ? null : new AtomUpdated(element);
    }
  }
}
