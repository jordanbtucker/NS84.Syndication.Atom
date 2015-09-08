using System;

namespace NerdSince1984.Syndication.Atom.Publication
{
  /// <summary>Specifies how whitespace should be handled.</summary>
  public enum AtomPubWhitespace
  {
    /// <summary>Specifies no information on how whitespace should be handled.</summary>
    None,

    /// <summary>Specifies that whitespace may be altered.</summary>
    Default,

    /// <summary>Specifies that whitespace should be preserved.</summary>
    Preserve
  }
}
