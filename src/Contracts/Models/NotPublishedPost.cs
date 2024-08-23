using System.Reflection;
using System.Text;

namespace Contracts.Models;

public record NotPublishedPost(Guid Id, string Title, string? Description, string? ImageUrl, string Link, string? Tag, string? Magnit)
{
    public override string ToString()
    {
        var str = new StringBuilder();
        str.Append("<b>");
        str.Append(Title);
        str.Append("</b>");
        str.Append("\r\n");
        str.Append(Description);
        if (!string.IsNullOrEmpty(Description)) str.Append("\r\n");
        str.Append("<a href=\"");
        str.Append(Link);
        str.Append("\">Ссылка на трекер</a>");
        str.Append("\r\n");
        str.Append("#");
        str.Append(Tag.Replace(" ", "").Replace(",", " #")
            .Replace("//", " #")
            .Replace("-", ""));
        return str.ToString();
    }
    
}