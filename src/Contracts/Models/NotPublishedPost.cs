using System.Reflection;
using System.Text;

namespace Contracts.Models;

public record NotPublishedPost(Guid Id, string Title, string? Description, string? ImageUrl, string Link)
{
    public override string ToString()
    {
        var str = new StringBuilder();
        str.Append(Title);
        str.Append("\r\n");
        str.Append(Description);
        if (!string.IsNullOrEmpty(Description)) str.Append("\r\n");
        str.Append("<a href=\"");
        str.Append(Link);
        str.Append("\">Ссылка</a>");
        return str.ToString();
    }
    
}