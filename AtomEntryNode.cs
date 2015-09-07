using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>An abstract base class that represents an Atom node with entry information.</summary>
  [DebuggerDisplay("Id = {Id}, Title = {Title}, Updated = {Updated}")]
  public abstract class AtomEntryNode : AtomNodeContainerNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomEntryNode"/> class.</summary>
    protected AtomEntryNode() { }

    /// <summary>Initializes a new instance of the <see cref="AtomEntryNode"/> class with an ID, title, and date and time when the entry was last updated.</summary>
    /// <param name="id">An <see cref="AtomId"/> representing the ID of the entry.</param>
    /// <param name="title">An <see cref="AtomTitle"/> representing the title of the entry.</param>
    /// <param name="updated">An <see cref="AtomUpdated"/> representing the date and time when the entry was last updated.</param>
    protected AtomEntryNode(AtomId id, AtomTitle title, AtomUpdated updated)
    {
      this.Id = id;
      this.Title = title;
      this.Updated = updated;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomEntryNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the entry from.</param>
    protected AtomEntryNode(XElement element) : base(element) { }

    /// <summary>Gets or sets an <see cref="AtomId"/> representing the ID of this entry.</summary>
    /// <returns>An <see cref="AtomId"/> representing the ID of this entry.</returns>
    public virtual AtomId Id
    {
      get { return this.Element.Element(AtomNamespace + "id"); }
      set { this.SetSingleElement(AtomNamespace + "id", value); }
    }

    /// <summary>Gets or sets an <see cref="AtomTitle"/> representing the title of this entry.</summary>
    /// <returns>An <see cref="AtomTitle"/> representing the title of this entry.</returns>
    public virtual AtomTitle Title
    {
      get { return this.Element.Element(AtomNamespace + "title"); }
      set { this.SetSingleElement(AtomNamespace + "title", value); }
    }

    /// <summary>Gets or sets an <see cref="AtomUpdated"/> representing the date and time when this entry was last updated.</summary>
    /// <returns>An <see cref="AtomUpdated"/> representing the date and time when this entry was last updated.</returns>
    public virtual AtomUpdated Updated
    {
      get { return this.Element.Element(AtomNamespace + "updated"); }
      set { this.SetSingleElement(AtomNamespace + "updated", value); }
    }

    /// <summary>Gets or sets an <see cref="AtomRights"/> representing copyright information about this entry.</summary>
    /// <returns>An <see cref="AtomRights"/> representing copyright information about this entry.</returns>
    public AtomRights Rights
    {
      get { return this.Element.Element(AtomNamespace + "rights"); }
      set { this.SetSingleElement(AtomNamespace + "rights", value); }
    }

    /// <summary>Gets an <see cref="IEnumerable&lt;T&gt;"/> of <see cref="AtomAuthor"/> representing the authors of this entry.</summary>
    /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> of <see cref="AtomAuthor"/> representing the authors of this entry.</returns>
    public IEnumerable<AtomAuthor> Authors
    {
      get { return this.Element.Elements(AtomNamespace + "author").Select(e => (AtomAuthor)e); }
    }

    /// <summary>Gets an <see cref="IEnumerable&lt;T&gt;"/> of <see cref="AtomCategory"/> representing the categories of this entry.</summary>
    /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> of <see cref="AtomCategory"/> representing the categories of this entry.</returns>
    public IEnumerable<AtomCategory> Categories
    {
      get { return this.Element.Elements(AtomNamespace + "category").Select(e => (AtomCategory)e); }
    }

    /// <summary>Gets an <see cref="IEnumerable&lt;T&gt;"/> of <see cref="AtomContributor"/> representing the contributors of this entry.</summary>
    /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> of <see cref="AtomContributor"/> representing the contributors of this entry.</returns>
    public IEnumerable<AtomContributor> Contributors
    {
      get { return this.Element.Elements(AtomNamespace + "contributor").Select(e => (AtomContributor)e); }
    }

    /// <summary>Gets an <see cref="IEnumerable&lt;T&gt;"/> of <see cref="AtomLink"/> representing the links in this entry.</summary>
    /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> of <see cref="AtomLink"/> representing the links in this entry.</returns>
    public IEnumerable<AtomLink> Links
    {
      get { return this.Element.Elements(AtomNamespace + "link").Select(e => (AtomLink)e); }
    }

    /// <summary>Gets a value indicating whether the specified <see cref="AtomNode"/> can be added.</summary>
    /// <param name="node">The <see cref="AtomNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomNode"/> can be added; otherwise, false.</returns>
    protected override bool CanAddNode(AtomNode node)
    {
      return node is AtomAuthor || node is AtomCategory || node is AtomContributor || node is AtomLink;
    }

    /// <summary>Gets a value indicating whether the specified <see cref="AtomNode"/> can be removed.</summary>
    /// <param name="node">The <see cref="AtomNode"/> to test.</param>
    /// <returns>True if the specified <see cref="AtomNode"/> can be removed; otherwise, false.</returns>
    protected override bool CanRemoveNode(AtomNode node)
    {
      return true;
    }
  }
}
