using System;
using System.Linq;
using System.Xml.Linq;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Represents the inline content of an Atom entry.</summary>
  public class AtomInlineContent : AtomContent
  {
    /// <summary>Initializes a new instance of the <see cref="AtomInlineContent"/> class.</summary>
    public AtomInlineContent() { }

    /// <summary>Initializes a new instance of the <see cref="AtomInlineContent"/> class with the specified type.</summary>
    /// <param name="type">A <see cref="string"/> representing the type of the content.</param>
    public AtomInlineContent(string text) : this(text, null) { }

    /// <summary>Initializes a new instance of the <see cref="AtomInlineContent"/> class with the specified text and type.</summary>
    /// <param name="text">A <see cref="string"/> representing the content as text.</param>
    /// <param name="type">A <see cref="string"/> representing the type of the content.</param>
    public AtomInlineContent(string text, string type)
      : base(type)
    {
      this.Text = text;
    }

    /// <summary>Initializes a new instance of the <see cref="AtomInlineContent"/> class from an <see cref="XElement"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to create the node from.</param>
    protected AtomInlineContent(XElement element) : base(element) { }

    /// <summary>Gets or sets this content as text.</summary>
    /// <value>A <see cref="string"/> representing this content as text.</value>
    public string Text
    {
      get
      {
        if(this.Type == "xhtml")
        {
          XElement div = this.Element.Element(XhtmlNamespace + "div");
          return div == null ? null : div.ToString(SaveOptions.DisableFormatting);
        }
        return (string)this.Element;
      }

      set { this.SetText(value, this.Type); }
    }

    /// <summary>Sets this content as HTML.</summary>
    /// <param name="html">A <see cref="string"/> representing the HTML content to set.</param>
    public void SetHtml(string html)
    {
      this.SetText(html, "html");
    }

    /// <summary>Sets this content as XHTML.</summary>
    /// <param name="xhtml">A <see cref="string"/> representing the XHTML content to set.</param>
    public void SetXhtml(string xhtml)
    {
      this.SetText(xhtml, "xhtml");
    }

    /// <summary>Sets this content as plain text.</summary>
    /// <param name="text">A <see cref="string"/> representing the plain text content to set.</param>
    public void SetText(string text)
    {
      this.SetText(text, null);
    }

    /// <summary>Sets this content as text of the specified type.</summary>
    /// <param name="text">A <see cref="string"/> representing this content to set as text.</param>
    /// <param name="type">A <see cref="string"/> representing the type of content.</param>
    /// <exception cref="ArgumentException"><paramref name="type"/> is "xhtml" and <paramref name="text"/> is not a valid XHTML element.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="type"/> is "xhtml" and <paramref name="text"/> is not a valid XHTML div element.</exception>
    public void SetText(string text, string type)
    {
      if(type == "xhtml")
      {
        XElement div = null;
        try { div = XElement.Parse(text); }
        catch(Exception) { throw new ArgumentException(Errors.NotAnElement, "text"); }
        if(div.Name != XhtmlNamespace + "div") throw new InvalidOperationException(Errors.NotAnXhtmlDiv);
        this.Element.ReplaceNodes(div);
      }
      else
        this.Element.SetValue(text);

      this.Element.SetAttributeValue("type", type);
    }

    /// <summary>Returns a <see cref="string"/> representing this content as text.</summary>
    /// <returns>A <see cref="string"/> representing this content as text.</returns>
    public override string ToString()
    {
      return this.Text;
    }

    /// <summary>Converts an <see cref="AtomInlineContent"/> to a <see cref="string"/>.</summary>
    /// <param name="node">An <see cref="AtomInlineContent"/> to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> converted from the specified <see cref="AtomInlineContent"/>.</returns>
    public static implicit operator string(AtomInlineContent node)
    {
      return node == null ? null : node.Text;
    }

    /// <summary>Converts a <see cref="string"/> to an <see cref="AtomInlineContent"/>.</summary>
    /// <param name="text">A <see cref="string"/> to convert to an <see cref="AtomInlineContent"/>.</param>
    /// <returns>An <see cref="AtomInlineContent"/> converted from the specified <see cref="string"/>.</returns>
    public static implicit operator AtomInlineContent(string text)
    {
      return text == null ? null : new AtomInlineContent(text);
    }

    /// <summary>Casts an <see cref="XElement"/> to an <see cref="AtomInlineContent"/>.</summary>
    /// <param name="element">An <see cref="XElement"/> to cast to an <see cref="AtomInlineContent"/>.</param>
    /// <returns>An <see cref="AtomInlineContent"/> casted from the specified <see cref="XElement"/>.</returns>
    public static implicit operator AtomInlineContent(XElement element)
    {
      return element == null ? null : new AtomInlineContent(element);
    }
  }
}
