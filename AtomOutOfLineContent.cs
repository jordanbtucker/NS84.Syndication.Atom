using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the out-of-line content of an Atom entry.</summary>
  [DebuggerDisplay("Src = {Src}, Type = {Type}")]
  public class AtomOutOfLineContent : AtomContent
  {
    /// <summary>Initializes a new instance of the <see cref="AtomOutOfLineContent"/> class with the specified src.</summary>
    /// <param name="src">A <see cref="string"/> representing the src of the content.</param>
    public AtomOutOfLineContent(string src) : this(src, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomOutOfLineContent"/> class with the specified src and type.</summary>
    /// <param name="src">A <see cref="string"/> representing the src of the content.</param>
    /// <param name="type">A <see cref="string"/> representing the type of the content.</param>
    /// <exception cref="ArgumentNullException"><paramref name="src"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="src"/> is an empty <see cref="string"/>.</exception>
    public AtomOutOfLineContent(string src, string type)
      : base(type)
    {
      if(src == null) throw new ArgumentNullException("src");
      if(src == "") throw new ArgumentException("", "src");
      this.Src = src;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomOutOfLineContent"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomOutOfLineContent(XElement element) : base(element) { }

    /// <summary>Gets or sets the src of this content.</summary>
    /// <value>A <see cref="string"/> representing the src of this content.</value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
    public string Src
    {
      get { return (string)this.Element.Attribute("src"); }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.Element.SetAttributeValue("src", value);
      }
    }

    /// <summary>Returns a <see cref="string"/> representing the src of this content.</summary>
    /// <returns>A <see cref="string"/> representing the src of this content.</returns>
    public override string ToString()
    {
      return this.Src;
    }

    /// <summary>Converts an <see cref="AtomOutOfLineContent"/> to a <see cref="string"/>.</summary>
    /// <param name="node">An <see cref="AtomOutOfLineContent"/> to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> converted from the specified <see cref="AtomOutOfLineContent"/>.</returns>
    public static implicit operator string(AtomOutOfLineContent node)
    {
      return node == null ? null : node.Src;
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomOutOfLineContent"/>.</summary>
    /// <param name="src">A <see cref="string"/> to convert to an <see cref="AtomOutOfLineContent"/>.</param>
    /// <returns>An <see cref="AtomOutOfLineContent"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomOutOfLineContent(string src)
    {
      return src == null ? null : new AtomOutOfLineContent(src);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomOutOfLineContent"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomOutOfLineContent"/>.</param>
    /// <returns>An <see cref="AtomOutOfLineContent"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomOutOfLineContent(XElement element)
    {
      return element == null ? null : new AtomOutOfLineContent(element);
    }
  }
}
