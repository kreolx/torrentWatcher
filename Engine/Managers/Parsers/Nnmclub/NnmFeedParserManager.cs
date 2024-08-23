using System.Xml;
using Contracts.Models;
using Engine.Managers.Contracts;

namespace Engine.Managers.Parsers.Nnmclub;

internal sealed class NnmFeedParserManager : IFeedParserManager
{
    public Source Source { get; } = Source.Nnmclub;
    public IEnumerable<PostDto>? ParseFeed(string feed)
    {
        var doc = new XmlDocument();
        doc.LoadXml(feed);
        var entries = doc.DocumentElement?.GetElementsByTagName("item");
        if (entries == null) return null;
        var posts = new PostDto[entries.Count];
        for (var i = 0; i < entries.Count; i++)
        {
            var entry = entries[i];
            if (entry is null) continue;
            var entryChildNodes = entry.ChildNodes;
            var nodes = new XmlNode[entry.ChildNodes.Count];
            for (var j = 0; j < nodes.Length; j++)
            {
                nodes[j] = entryChildNodes[j]!;
            }

            var title = nodes.FirstOrDefault(x => x.Name == "title")?.InnerText;
            var link = nodes.FirstOrDefault(x => x.Name == "link")?.InnerText;
            var id = link.Split("=")[^1].Split("#")[0];
            var externalId = Int64.Parse(id);
            var category = String.Join(", ", nodes.Where(x => x.Name == "category")?.Select(x => x.InnerText));
            posts[i] = new PostDto(title, null, link, null, externalId, category, null);
        }
        return posts;
    }
}