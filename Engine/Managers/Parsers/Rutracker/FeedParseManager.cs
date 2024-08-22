using System.Runtime.CompilerServices;
using System.Xml;
using Contracts.Models;
using Engine.Managers.Contracts;

[assembly: InternalsVisibleTo("Test.Engine")]
namespace Engine.Managers.Parsers.Rutracker;

internal sealed class FeedParseManager : IFeedParserManager
{
    public Source Source { get; } = Source.Rutracker;

    public IEnumerable<PostDto>? ParseFeed(string feed)
    {
        var doc = new XmlDocument();
        doc.LoadXml(feed);
        var entries = doc.DocumentElement?.GetElementsByTagName("entry");
        if (entries == null) return null;
        var posts = new PostDto[entries.Count];
        for (var i = 0; i < entries.Count; i++)
        {
            var entry = entries[i];
            if (entry == null) continue;
            var entryChildNodes = entry.ChildNodes;
            var nodes = new XmlNode[entry.ChildNodes.Count];
            for (var j = 0; j < entryChildNodes.Count; j++)
            {
                nodes[j] = entryChildNodes[j]!;
            }
            var title = nodes.FirstOrDefault(x => x.Name == "title")?.InnerText;
            var link = nodes.FirstOrDefault(x => x.Name == "link")?.Attributes["href"]?.Value;
            var externalId = Int64.Parse(link.Split("=")[^1]);
            posts[i] = new PostDto(title, "", link, "", externalId);
        }
        return posts;
    }
}