using System;
using System.Xml.Linq;

namespace NS84.Syndication.Atom
{
  /// <summary>Represents the date and time when an Atom feed or entry was published.</summary>
  public class AtomPublished : AtomDateNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomPublished"/> class with the specified date and time.</summary>
    /// <param name="date">A <see cref="DateTime"/> representing the date and time.</param>
    public AtomPublished(DateTime date) : base(date) { }

    /// <summary>Initializes a new instance of the <see cref="AtomPublished"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomPublished(XElement element) : base(element) { }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomPublished"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "published".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "published"; }
    }

    /// <summary>Converts a <see cref="DateTime"/> to an <see cref="AtomPublished"/>.</summary>
    /// <param name="date">A <see cref="DateTime"/> to convert to an <see cref="AtomPublished"/>.</param>
    /// <returns>An <see cref="AtomPublished"/> converted from the specified <see cref="DateTime"/>.</returns>
    public static implicit operator AtomPublished(DateTime date)
    {
      return new AtomPublished(date);
    }

    /// <summary>Converts a <see cref="Nullable{T}"/> of <see cref="DateTime"/> to an <see cref="AtomPublished"/>.</summary>
    /// <param name="date">A <see cref="Nullable{T}"/> of <see cref="DateTime"/> to convert to an <see cref="AtomPublished"/>.</param>
    /// <returns>An <see cref="AtomPublished"/> converted from the specified <see cref="Nullable{T}"/> of <see cref="DateTime"/>.</returns>
    public static implicit operator AtomPublished(DateTime? date)
    {
      return date == null ? null : new AtomPublished(date.Value);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomPublished"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomPublished"/>.</param>
    /// <returns>An <see cref="AtomPublished"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomPublished(XElement element)
    {
      return element == null ? null : new AtomPublished(element);
    }
  }
}
