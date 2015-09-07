# What?

A .NET Framework library for reading and writing documents in the [Atom
Syndication Format](http://tools.ietf.org/html/rfc4287), including support for
the [Atom Publishing Protocol](http://tools.ietf.org/html/rfc5023) and [Feed
Paging and Archiving](http://tools.ietf.org/html/rfc5005). Supports .NET 3.5 and
4.

# Who?

Contact me at [jordan@ns84.com](mailto:jordan@ns84.com).

# How?

## Writing a feed

```c#
AtomFeed feed = new AtomFeed(
    "http://example.org/feed",
    "Example Atom Feed",
    DateTime.Now);
feed.Subtitle = "Demonstrating the Atom Library for the .NET Framework";
feed.Add(new AtomLink("http://example.org/feed", "self"));
feed.Add(new AtomLink("http://example.org"));

AtomEntry entry = new AtomEntry(
    "http://exmaple.org/entries/1",
    "Example Entry One",
    DateTime.Now);
entry.Published = DateTime.Now;
entry.Add(new AtomLink("http://exmaple.org/entries/1"));
entry.Content = new AtomInlineContent("<p>Hello, World!</p>", "html");
entry.Add(new AtomAuthor("Jordan", "jordan@example.org"));
entry.Add(new AtomCategory("examples"));

feed.Add(entry);
```

## Reading a feed

```c#
AtomFeed feed = XElement.Load("http://example.org/feed");
Console.WriteLine("Title:    " + feed.Title);
Console.WriteLine("Subtitle: " + feed.Subtitle);
Console.WriteLine("Updated:  " + feed.Updated);
Console.WriteLine("Website:  " + feed.Links.FirstOrDefault(
    l => l.Rel == null || l.Rel == "alternate"));

Console.WriteLine();
Console.WriteLine("Entries");
foreach(AtomEntry entry in feed.Entries)
{
    Console.WriteLine();
    Console.WriteLine("Title:    " + entry.Title);
    Console.WriteLine("Updated:  " + entry.Updated);
    Console.WriteLine("Location: " + entry.Links.FirstOrDefault(
        l => l.Rel == null || l.Rel == "alternate"));
}
```
