using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the source of an Atom entry.</summary>
  public class AtomSource : AtomEntryNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomSource"/> class.</summary>
    public AtomSource() { }

    /// <summary>Initializes a new instance of the <see cref="AtomSource"/> class with an ID, title, and date and time when the entry was last updated.</summary>
    /// <param name="id">An <see cref="AtomId"/> representing the ID of the source.</param>
    /// <param name="title">An <see cref="AtomTitle"/> representing the title of the source.</param>
    /// <param name="updated">An <see cref="AtomUpdated"/> representing the date and time when the source was last updated.</param>
    /// <exception cref="ArgumentNullException"><paramref name="id"/>, <paramref name="title"/>, or <paramref name="updated"/> is null.</exception>
    public AtomSource(AtomId id, AtomTitle title, AtomUpdated updated) : base(id, title, updated) { }

    /// <summary>Initializes a new instance of the <see cref="AtomSource"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the source from.</param>
    protected AtomSource(XElement element) : base(element) { }

    /// <summary>Gets the generator of this source.</summary>
    /// <value>An <see cref="AtomGenerator"/> representing information about the generator of this source.</value>
    public virtual AtomGenerator Generator
    {
      get { return this.Element.Element(AtomNamespace + "generator"); }
      protected set { this.SetSingleElement(AtomNamespace + "generator", value); }
    }

    /// <summary>Gets or sets the icon of this source.</summary>
    /// <value>An <see cref="AtomIcon"/> representing the icon of this source.</value>
    public virtual AtomIcon Icon
    {
      get { return this.Element.Element(AtomNamespace + "icon"); }
      set { this.SetSingleElement(AtomNamespace + "icon", value); }
    }

    /// <summary>Gets or sets the logo of this source.</summary>
    /// <value>An <see cref="AtomLogo"/> representing the logo of this source.</value>
    public virtual AtomLogo Logo
    {
      get { return this.Element.Element(AtomNamespace + "logo"); }
      set { this.SetSingleElement(AtomNamespace + "logo", value); }
    }

    /// <summary>Gets or sets the subtitle of this source.</summary>
    /// <value>An <see cref="AtomSubtitle"/> representing the subtitle of this source.</value>
    public virtual AtomSubtitle Subtitle
    {
      get { return this.Element.Element(AtomNamespace + "subtitle"); }
      set { this.SetSingleElement(AtomNamespace + "subtitle", value); }
    }

    /// <summary>Gets the name of the underlying element.</summary>
    /// <value>An <see cref="XName"/> representing the name of the underlying element. For <see cref="AtomSource"/>, this value is <see cref="AtomFeed.AtomNamespace"/> + "source".</value>
    protected override XName ElementName
    {
      get { return AtomNamespace + "source"; }
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomSource"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomSource"/>.</param>
    /// <returns>An <see cref="AtomSource"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomSource(XElement element)
    {
      return element == null ? null : new AtomSource(element);
    }
  }
}
