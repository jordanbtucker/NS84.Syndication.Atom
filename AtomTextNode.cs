using System;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>An abstract base class that represents a text based Atom node.</summary>
  public abstract class AtomTextNode : AtomNode
  {
    /// <summary>Initializes a new instance of the <see cref="AtomTextNode"/> class with the specified text.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    protected AtomTextNode(string text) : this(text, AtomTextType.None) { }

    /// <summary>Initializes a new instance of the <see cref="AtomTextNode"/> class with the specified text and type.</summary>
    /// <param name="text">A <see cref="string"/> representing the text.</param>
    /// <param name="type">An <see cref="AtomTextType"/> representing the type of text.</param>
    protected AtomTextNode(string text, AtomTextType type)
    {
      this.SetText(text, type);
    }

    /// <summary>Initializes a new instance of the <see cref="AtomTextNode"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomTextNode(XElement element) : base(element) { }

    /// <summary>Gets or sets a <see cref="string"/> representing the text of this node.</summary>
    /// <returns>A <see cref="string"/> representing the text of this node.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is an empty <see cref="string"/>.</exception>
    public string Text
    {
      get
      {
        if(this.Type == AtomTextType.Xhtml)
        {
          XElement div = this.Element.Element(XhtmlNamespace + "div");
          return div == null ? null : div.ToString(SaveOptions.DisableFormatting);
        }
        return (string)this.Element;
      }

      set
      {
        if(value == null) throw new ArgumentNullException("value");
        if(value == "") throw new ArgumentException(Errors.EmptyString, "value");
        this.SetText(value);
      }
    }

    /// <summary>Gets an <see cref="AtomTextType"/> representing the type of text of this node.</summary>
    /// <returns>An <see cref="AtomTextType"/> representing the type of text of this node.</returns>
    public AtomTextType Type
    {
      get
      {
        XAttribute type = this.Element.Attribute("type");
        return type == null ? AtomTextType.None : (AtomTextType)Enum.Parse(typeof(AtomTextType), (string)type, true);
      }
    }

    /// <summary>Sets the <see cref="AtomTextNode.Text"/> of this node, and sets the <see cref="AtomTextNode.Type"/> of this node to <see cref="AtomTextType.Html"/>.</summary>
    /// <param name="html">A <see cref="string"/> representing the HTML to set the text of this node to.</param>
    /// <exception cref="ArgumentNullException"><paramref name="html"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="html"/> is an empty <see cref="string"/>.</exception>
    public void SetHtml(string html)
    {
      if(html == null) throw new ArgumentNullException("html");
      if(html == "") throw new ArgumentException(Errors.EmptyString, "html");
      this.SetText(html, AtomTextType.Html);
    }

    /// <summary>Sets the <see cref="AtomTextNode.Text"/> of this node, and sets the <see cref="AtomTextNode.Type"/> of this node to <see cref="AtomTextType.Xhtml"/>.</summary>
    /// <param name="xhtml">A <see cref="string"/> representing the XHTML to set the text of this node to.</param>
    /// <exception cref="ArgumentNullException"><paramref name="xhtml"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="xhtml"/> is an empty <see cref="string"/>.</exception>
    public void SetXhtml(string xhtml)
    {
      if(xhtml == null) throw new ArgumentNullException("xhtml");
      if(xhtml == "") throw new ArgumentException(Errors.EmptyString, "xhtml");
      this.SetText(xhtml, AtomTextType.Xhtml);
    }

    /// <summary>Sets the <see cref="AtomTextNode.Text"/> of this node, and sets the <see cref="AtomTextNode.Type"/> of this node to <see cref="AtomTextType.None"/>.</summary>
    /// <param name="text">A <see cref="string"/> representing the text to set.</param>
    public void SetText(string text)
    {
      this.SetText(text, AtomTextType.None);
    }

    /// <summary>Sets the <see cref="AtomTextNode.Text"/> of this node, and sets the <see cref="AtomTextNode.Type"/> of this node to <see cref="AtomTextType.Text"/>.</summary>
    /// <param name="text">A <see cref="string"/> representing the text to set.</param>
    /// <param name="type">An <see cref="AtomTextType"/> representing the type of text.</param>
    /// <exception cref="ArgumentNullException"><paramref name="text"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="text"/> is an empty <see cref="string"/>.</exception>
    public void SetText(string text, AtomTextType type)
    {
      if(text == null) throw new ArgumentNullException("text");
      if(text == "") throw new ArgumentException(Errors.EmptyString, "text");

      if(type == AtomTextType.Xhtml)
      {
        XElement div = null;
        try { div = XElement.Parse(text); }
        catch(Exception) { throw new ArgumentException(Errors.NotAnElement, "text"); }
        if(div.Name != XhtmlNamespace + "div") throw new InvalidOperationException(Errors.NotAnXhtmlDiv);
        this.Element.ReplaceNodes(div);
      }
      else
        this.Element.SetValue(text);

      this.Element.SetAttributeValue("type", type == AtomTextType.None ? null : type.ToString().ToLower());
    }

    /// <summary>Returns a <see cref="string"/> representing the text of this node.</summary>
    /// <returns>A <see cref="string"/> representing the text of this node.</returns>
    public override string ToString()
    {
      return this.Text;
    }

    /// <summary>Converts an <see cref="AtomTextNode"/> to a <see cref="string"/>.</summary>
    /// <param name="node">An <see cref="AtomTextNode"/> to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> converted from the specified <see cref="AtomTextNode"/>.</returns>
    public static implicit operator string(AtomTextNode node)
    {
      return node == null ? null : node.Text;
    }
  }
}
