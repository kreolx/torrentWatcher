using Engine.Managers.Parsers.Rutracker;
using FluentAssertions;

namespace Test.Engine.Managers.Parsers.Rutracker;

public class UnitTest_FeedParseManager
{
    [Fact]
    public void ParseFeed_should_return_array_of_posts()
    {
        var manager = new RutrackerFeedParseManager();
        var feed = GetFeed();
        var posts = manager.ParseFeed(feed);
        posts.Should().NotBeNull();
        posts.Count().Should().Be(2);
        posts.First().ExternalId.Should().Be(6257950);
    }
    
    private string GetFeed() => @"<?xml version=""1.0"" encoding=""utf-8""?>
<feed xmlns=""http://www.w3.org/2005/Atom"">
<id>tag:rto.feed,2000:/f/0</id>
<link href=""http://rutracker.org/forum/"" />
<updated>2024-08-18T03:30:03+00:00</updated>
<title>Общая по всем разделам</title>
<entry>
	<id>tag:rto.feed,2024-08-18:/t/6257950</id>
	<link href=""https://rutracker.org/forum/viewtopic.php?t=6257950"" />
	<updated>2024-08-18T02:29:20+00:00</updated>
	<title>[Обновлено] [Журнал] American Fine Art Magazine [2019-2024, PDF, ENG] номеров - 32 [1.31 GB]</title>
	<author>
		<name>shtirts</name>
	</author>
	<category term=""f-1412"" label=""Коллекционирование и вспомогательные ист. дисциплины"" />
</entry>
<entry>
	<id>tag:rto.feed,2024-08-18:/t/6546290</id>
	<link href=""https://rutracker.org/forum/viewtopic.php?t=6546290"" />
	<updated>2024-08-18T02:26:49+00:00</updated>
	<title>[Обновлено] Последний герой. Русский сезон / Сезон: 11 / Выпуск: 1-8 из 10 [2024, Реалити-шоу, WEB-DL 720p] обновляемая [15.8 GB]</title>
	<author>
		<name>Канск</name>
	</author>
	<category term=""f-939"" label=""[Видео Юмор] Реалити и ток-шоу / номинации / показы"" />
</entry>
</feed>";
}