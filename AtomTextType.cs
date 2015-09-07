using System;

namespace NerdSince1984.Syndication.Atom
{
  /// <summary>Specifies the type of text of an <see cref="AtomTextNode"/>.</summary>
  public enum AtomTextType
  {
    /// <summary>Specifies that no type is set. The text should be treated as plain text.</summary>
    None,

    /// <summary>Specifies that the text is plain text.</summary>
    Text,

    /// <summary>Specifies that the text is HTML.</summary>
    Html,

    /// <summary>Specifies that the text is XHTML.</summary>
    Xhtml
  }
}
