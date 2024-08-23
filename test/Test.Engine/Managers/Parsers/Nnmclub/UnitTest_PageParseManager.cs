using Contracts.Interfaces;
using Contracts.Models;
using Engine.Managers.Parsers.Nnmclub;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace Test.Engine.Managers.Parsers.Nnmclub;

public class UnitTest_PageParseManager
{
	[Fact]
	public async Task LoadDataAsync_should_return_data()
	{
		var client = A.Fake<IHttpTrackerClient>();
		A.CallTo(() => client.GetAsync(A<string>.Ignored, A<CancellationToken>.Ignored))
			.Returns(GetPage());
		var logger = A.Fake<ILogger<NnmPageParserManager>>();

		var manager = new NnmPageParserManager(client, logger);
		var postDto = new PostDto("123", "","http://123.ru/forum/viewtopic.php?t=6257950", "", 0, null, null);
		var resultDto = await manager.LoadDataAsync(postDto, default);
		resultDto.Description.Should().NotBeEmpty();
		resultDto.Description.Should().StartWith("На дурака не нужен нож");
		resultDto.ImageUrl.Should()
			.Be("https://i123.fastpic.org/big/2024/0822/43/e4d173f6abf94a1240c9b189fb1b5743.jpeg");
	}
	
	
	private string GetPage() => @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">
<html prefix=""ya: http://webmaster.yandex.ru/vocabularies/""><head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=windows-1251"">
<meta name=""yandex-verification"" content=""13f34e1b1ba9373f"" />
<meta http-equiv=""Content-Style-Type"" content=""text/css"">
<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
<meta property=""ya:interaction"" content=""XML_FORM"" />
<meta property=""ya:interaction:url"" content=""http://nnm-club.me/forum/yandex.xml"" />
<link rel=""yandex-tableau-widget"" href=""https://nnm-club.me/tableau/tableau.json"" />
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
<meta name=""msapplication-config"" content=""/manifest/browserconfig.xml?v=OmyB83LpBX"">
<meta name=""theme-color"" content=""#ffffff"">
<meta name=""robots"" content=""index,follow"">
<title>Приключения Буратино (1975) HDTVRip [H.264] :: NNM-Club</title>
<link rel=""canonical"" href=""https://nnmclub.to/forum/viewtopic.php?t=1744589"">
<link rel=""stylesheet"" href=""https://nnmstatic.win/forum/templates/smartBlue/20210120.css"" type=""text/css"">
<link rel=""stylesheet"" href=""https://nnmstatic.win/forum/new_year/style2022.css"" type=""text/css"">
<link rel=""icon"" href=""https://nnmstatic.win/favicon.ico"" type=""image/x-icon"">
<link rel=""shortcut icon"" href=""https://nnmstatic.win/favicon.ico"" type=""image/x-icon"">
<link rel=""apple-touch-icon"" sizes=""180x180"" href=""https://nnmstatic.win/manifest/apple-touch-icon.png"">
<link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""https://nnmstatic.win/manifest/favicon-32x24.png"">
<link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""https://nnmstatic.win/manifest/favicon-16x16.png"">
<link rel=""manifest"" href=""https://nnmstatic.win/manifest/manifest.json"">
<link rel=""mask-icon"" href=""https://nnmstatic.win/manifest/safari-pinned-tab.svg"" color=""#5bbad5"">
<link rel=""alternate"" type=""application/rss+xml"" title=""NNM-Club new messages"" href=""rss.xml"">
<link rel=""alternate"" type=""application/rss+xml"" title=""NNM-Club new topics"" href=""rss-topic.xml"">
<link rel=""alternate"" type=""application/rss+xml"" title=""NNM-Club 100 messages"" href=""rss-100.xml"">
<link rel=""alternate"" type=""application/rss+xml"" title=""NNM-Club 100 topics"" href=""rss-100-topic.xml"">
<link rel=""alternate"" type=""application/rss+xml"" title=""NNM-Club torrents"" href=""rssd.xml"">
<link rel=""search"" type=""application/opensearchdescription+xml"" href=""opensearch_desc.xml"" title=""NNM-Club (Forum)"">
<link rel=""search"" type=""application/opensearchdescription+xml"" href=""opensearch_desc_bt.xml"" title=""NNM-Club (Tracker)"">
<script type=""text/javascript"">
window.hideIcon=function() { } ;
</script>
<script type=""text/javascript"">
window.ASSETS = 'https://nnmstatic.win';
</script>
<script type=""text/javascript"" src=""https://nnmstatic.win/forum/misc/js/m.bbcode.js""></script>
<script type='text/javascript' src='https://nnmstatic.win/forum/misc/js/jquery-3.4.0.min.js'></script>
<script type='text/javascript' src='https://nnmstatic.win/forum/misc/js/jquery-migrate-3.0.1.min.js'></script>
<script type='text/javascript' src='https://nnmstatic.win/forum/misc/js/20230923.js' charset='windows-1251'></script>
<script async src=""https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-7768347321290299"" crossorigin=""anonymous""></script>
<link rel=""stylesheet"" type=""text/css"" href=""https://nnmstatic.win/forum/highslide/highslide.css"">
<!--[if lt IE 7]>
<link rel=""stylesheet"" type=""text/css"" href=""https://nnmstatic.win/forum/highslide/highslide-ie6.css"">
<![endif]-->
</head><body>
<a name=""top""></a>
<div class=""wrap"">
<table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""center"" class=""tg""><tr><td>
	<table width=""100%"" cellspacing=""1"" cellpadding=""0"" border=""0"" class=""header""><tr><td height=""75"">
	<!-- Начало -->
		<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td>
			<a href=""index.php""><img src='https://nnmstatic.win/forum/images/logos/birthday/birthday-00y-sdr-red.png' alt=""Классический форум-трекер"" title=""Классический форум-трекер"" border='0'></a>
<audio id=""logomusic"" preload=""none"">
  <source src=""https://nnmstatic.win/forum/mplayer/noname.mp3"" type=""audio/mpeg"">
	<source src=""https://nnmstatic.win/forum/mplayer/noname.ogg"" type=""audio/ogg"">
	<source src=""https://nnmstatic.win/forum/mplayer/noname.wav"" type=""audio/wav"">
<div class=""audioplayer""><object type=""application/x-shockwave-flash"" data=""https://nnmstatic.win/forum/mplayer/zplayer.swf?cache=1&mp3=https://nnmstatic.win/forum/mplayer/karina.mp3&c1=6699CC&vol=100"" width=""200"" height=""20""/><param name=""movie"" value=""https://nnmstatic.win/forum/mplayer/zplayer.swf?cache=1&mp3=https://nnmstatic.win/forum/mplayer/karina.mp3&c1=6699CC&vol=100"" /><param name=""wmode"" value=""transparent"" /></object></div>
</audio>
<!--[if (gte IE 9)|!(IE)]>-->
<div class=""audioplayer"">
	<div id=""play"" class=""play"" onclick=""playAudio()""></div>
<canvas id=""logobar"" class=""logobar"" width=""150"" height=""7"">canvas not supported</canvas>
<div id=""pMute"" class=""unmute"" onclick=""unmute()""></div><div><noindex><a rel=""nofollow"" href=""viewtopic.php?t=830137"" class=""lmute"" title=""скачать""></a></noindex></div>
</div>
<!--<![endif]-->
		</td><td align='center' width='100%'>
			<!-- ТАБЛИЧКА :) -->
			<table class=""menutable"">
				<tr><td align='center' valign='middle'>
					<table width=""690"" border=""0""><tr>
					<td width='115' height='37' align='center'>
																<a href=""release.php"" class=""mainmenu"">Добавление<br>релиза</a>
										</td>
					<td width='115' height='37' align='center'><a href=""tracker.php"" class=""mainmenu"">Трекер</a></td>
					<td width='115' height='37' align='center'>
					<a href=""search.php"" class=""mainmenu"">Поиск по форуму</a>
					</td>
					<td width='115' height='37' align='center'>
					<a href=""watched_topics.php"" class=""mainmenu"">Закладки</a>
					</td>
					<td width='115' height='37' align='center'>
					<a href=""rss.xml"" class=""mainmenu"">RSS</a><br>
					<a href=""rss-topic.xml"" class=""mainmenu"">RSS новые темы</a>
					</td>
					<td width='115' height='37' align='center'>
					<a href=""contact.php"" class=""mainmenu"">Мой Клуб</a>
					</td>
					</tr>
					<tr>
					<td width='115' height='37' align='center'>
					<a href=""/"" class=""mainmenu"">Портал</a>
					</td>
					<td width='115' height='37' align='center'>
					<a href='viewtopic.php?t=74841' class=""mainmenu"">FAQ</a>
					</td>
					<td width='115' height='37' align='center'>
					<a href=""viewtopic.php?t=867"" class=""mainmenu"">Правила</a>
					</td>
					<td width='115' height='37' align='center'>
																<a href=""profile.php?mode=viewprofile&amp;u=7979410#torrent"" class=""mainmenu"">Профиль</a>
										</td>
					<td width='115' height='37' align='center'>
					<a href=""privmsg.php?folder=inbox"" class=""mainmenu"">Непрочитанных сообщений: 8</a>
					</td>
					<td width='115' height='37' align='center'>
					<a href=""login.php?logout=true&amp;sid=41641e2e6357ae97ebd8eac40e4d5a4e"" class=""mainmenu"">Выход [ kreolx ]</a>
					</td>
					</tr>
					</table>
					</td></tr>
					</table><div class=""total-users"">Нас вместе:  4 237 459</div>					<!-- ТАБЛИЧКА :) -->
				</td></tr></table>
				<!-- Конец -->
			</td></tr><tr><td class=""row2"">
				<table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"">
					<tr><td>
					<!-- NNM-Club.ADs Start -->
					<center><!-- add --></center>
					<!-- NNM-Club.ADs End -->
					</td></tr>
					<tr><td class=""no-adb"" id=""adss"">
					<!-- NNM-Club.ADs Start -->
					<center></center>
					<!-- NNM-Club.ADs End -->
					</td></tr>
					<tr><td>
					<!-- NNM-Club.ADs Start -->
					<center></center>
					<!-- NNM-Club.ADs End -->
					</td></tr>
				</table>
        <table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" class=""menubot"">
					<tr>
					<td width=""35%"" align=""center""><ul class=""menu"" style=""width:392px""><li><a href=""viewtopic.php?t=3842"">Правила оформления</a><ul><li><a href=""viewtopic.php?t=68458"" title=""Категория Видео и Документалистика"">Видео</a></li><li><a href=""viewtopic.php?t=66878"" title=""Правила раздела Музыка"">Музыка</a></li><li><a href=""viewtopic.php?t=121110"" title=""Правила раздела Игры"">Игры</a></li><li><a href=""viewtopic.php?t=176300"" title=""Правила раздела Программы"">Программы</a></li></ul></li><li><a href=""viewforum.php?f=1244"" title=""Форум для обсуждения"">Обход блокировок</a><ul><li><a href=""viewtopic.php?t=958349"" title=""Путеводитель по браузерам"">Обход&nbsp;блокировок</a></li><li><a href=""viewtopic.php?t=683354"" title=""Обход блокировок часть 1 обсуждение"">Обход Часть 1</a></li><li><a href=""viewtopic.php?t=716328"" title=""Обход блокировок часть 2 обсуждение"">Обход Часть 2</a></li><li><a href=""viewforum.php?f=3"" title=""Все новости Клуба"">Новости Клуба</a></li></ul></li><li><a href=""medal.php"" title=""Популярные раздачи и рейтинги"">Популярное</a></li></ul></td>
					<td width=""28%"" align=""center"" nowrap=""nowrap""><form action=""tracker.php"" method=""post"">
            <input name=""f"" type=""hidden"" value=""-1""><span class=""mainmenu"">Поиск :</span>
						<input name=""nm"" placeholder=""по трекеру"" style=""width:200px;font-style:normal"" type=""text"">
						<input type=""submit"" name=""search_submit"" value=""Искать"" class=""mbutton""></form></td>
					<td width=""37%"" align=""center""><ul class=""menu"" style=""width:390px"">
                    <li>
                    <a href=""viewtopic.php?t=74397"">Как искать</a>
                    </li>
                    <li>
                    <a href=""viewtopic.php?t=366"">Как скачивать</a>
                    </li>
                    <li>
                    <a href=""viewtopic.php?t=892"" title=""Создание и публикация торрента"">Как раздавать</a>
                    </li>
                    <li>
                    <a href=""#"" id=""ny-garland-toggler"" style=""display:none"" onclick=""return toggle_new_year();"">Гирлянда</a>
                    <a href=""viewtopic.php?t=150259"" title=""Благодарности участников"">Спасибо!</a>
                    </li>
                    </ul></td>
          </tr>
        </table>
				</td></tr></table>
	</td></tr><tr><td>
		<table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0""><tr><td>
<br>
<!--<form name=""search_block_top"" method=""get"" action=""/"">
<center><span class=""gen""><b>Поиск</b>:&nbsp;<input type=""text"" name=""q"" size=""50"" value=""""
/>&nbsp;в&nbsp;<select name=""w"">
<option value=""title"" >названиях</option>
<option value=""text"" >описаниях</option>
<option value=""comments"" >комментариях</option>
</select>&nbsp;<input type=""submit"" value=""Искать"" class=""liteoption""></span></center></form>-->
<table width=""100%"" cellspacing=""2"" cellpadding=""2"" border=""0"">
<tr>
	<td align=""left"" valign=""bottom""><h1 style=""display:inline""><a class=""maintitle"" href=""viewtopic.php?t=1744589"">Приключения Буратино (1975) HDTVRip [H.264]</a></h1><br>
	<span class=""nav""></span><span class=""gensmall"">&nbsp; <br>
	&nbsp; </span></td><td align=""right"" valign=""top""><a href=""rss.php?topic=1744589""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/rss.png"" alt=""RSS"" title=""Новые сообщения"" width=""32"" height=""32"" border=""0""></a></td>
</tr>
</table>


<table width=""100%"" cellspacing=""2"" cellpadding=""2"" border=""0"">
<tr>
	<td align=""left"" valign=""bottom"" nowrap=""nowrap""><span class=""nav""><a href=""posting.php?mode=newtopic&amp;f=731"" rel=""nofollow""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/post.gif"" border=""0"" alt=""Начать новую тему"" align=""middle""></a>&nbsp;&nbsp;&nbsp;<a href=""posting.php?mode=reply&amp;t=1744589"" rel=""nofollow""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/reply.gif"" border=""0"" alt=""Ответить на тему"" align=""middle""></a></span></td>
	<td align=""left"" valign=""middle"" width=""100%""><span class=""nav"">&nbsp;&nbsp;&nbsp;<a href=""index.php"" class=""nav"">Торрент-трекер NNM-Club</a>
	 -> <a class=""nav"" href=""viewforum.php?f=724"">Видео, Кино и Сериалы для детей и родителей</a>	-> <a href=""viewforum.php?f=731"" class=""nav"">Отечественные Фильмы и Сериалы для детей (SD)</a></span></td>
		<td nowrap=""nowrap"">
		<form method=""post"" action=""search.php?search_id=likeposts"" style=""display:none"">
		<input type=""hidden"" name=""show_results"" value=""posts"">
		<input type=""hidden"" name=""mode"" value=""likeposts"">
		<input type=""hidden"" name=""topic_id"" value=""1744589"">
		<input id=""l-btn"" type=""submit"" name=""search_submit"" value=""Сообщения получившие поддержку пользователей"">
		</form>
		<a href=""#"" onclick=""{ $('#l-btn').click() } return false;"" class=""gensmall"" title=""Сообщения получившие поддержку пользователей"">Полезные</a></td>
	</td>
	<td nowrap=""nowrap"">
		<form method=""post"" action=""search.php?search_id=myposts"" style=""display:none"">
		<input type=""hidden"" name=""show_results"" value=""posts"">
		<input type=""hidden"" name=""mode"" value=""myposts"">
		<input type=""hidden"" name=""topic_id"" value=""1744589"">
		<input id=""my-btn"" type=""submit"" name=""search_submit"" value=""Поиск в теме со следующим ID топика"">
		</form>
		<a href=""#"" onclick=""{ $('#my-btn').click() } return false;"" class=""gensmall"" title=""Найти темы с Вашими сообщениями"">Мои сообщения</a></td>
	</td>
<td align=""right""><span class=""gensmall""><a href=""viewtopic.php?t=1744589&amp;watch=topic&amp;start=0&amp;sid=41641e2e6357ae97ebd8eac40e4d5a4e"">Добавить&nbsp;тему&nbsp;в&nbsp;закладки</a></span></td>
</tr>
</table>

<!-- //bt -->
<table width=""100%"" class=""forumline"" cellspacing=""1"" cellpadding=""6"" border=""0"">
	<tr>
		<td colspan=""2"" height=""24"" class=""catHead"" align=""center"" style=""letter-spacing: 1px""><span class=""gen""><b><a href=""viewtopic.php?t=1744589&amp;spmode=full&dl=names"" class=""gen"">
			Torrent activity		</a></b></span></td>
	</tr>
			
	
									<tr>
				<td colspan=""2"" class=""row2"" align=""center"">
                									<table cellspacing=""0"" cellpadding=""4"" border=""0"" align=""center"">
												<tr>
							<td nowrap=""nowrap"" align=""center""><span class=""seed""><b>Seeders:</b></span></td>
							<td nowrap=""nowrap"" align=""center""><span class=""seed"">[ <b>17 &nbsp;(8.73&nbsp;KB/s)</b> ]</span></td>
						</tr>
																		<tr>
							<td nowrap=""nowrap"" align=""center""><span class=""leech""><b>Leechers:</b></span></td>
							<td nowrap=""nowrap"" align=""center""><span class=""leech"">[ <b>0 &nbsp;(55.8&nbsp;KB/s)</b> ]</span></td>
						</tr>
											</table>
									</td>
			</tr>
										<tr>
			<td colspan=""2"" align=""center"" valign=""middle"" class=""row3"" style=""padding: 0px; height: 28px"">
			<div align=""center"" class=""gen"" style=""width: 60%;padding: 6px; margin-top: 6px; margin-bottom: 6px; border: 1px solid #98AAB1;""><a href=""javascript:"" onclick=""location='#simil';$('.sim').toggle('slow'); return false;"" style=""font-weight:bold;color:blue;"">Похожие темы</a></div>&nbsp;
			<form method=""POST"" action=""dl_list.php?t=1744589"" style=""display: inline"">
				<input type=""submit"" name=""dl_set_will"" value=""Буду качать"" class=""liteoption"" />&nbsp;												<input type=""submit"" name=""dl_set_cancel"" value=""Отмена"" class=""liteoption"" />&nbsp;				<input type=""submit"" name=""dl_set_drop"" value=""Уже удалил"" class=""liteoption"" />				
		<input type=""hidden"" name=""sid"" value=""41641e2e6357ae97ebd8eac40e4d5a4e"" />
		<input type=""hidden"" name=""f"" value=""731"" />
		<input type=""hidden"" name=""t"" value=""1744589"" />
		<input type=""hidden"" name=""mode"" value=""set_dl_status"" />
				</form>
			&nbsp;
			</td>
		</tr>
	</table>
<div><img src=""https://nnmstatic.win/forum/images/spacer.gif"" alt="""" width=""1"" height=""6"" /></div>
<!-- //bt end -->
<table style=""background-color:#aec9e4;"" width=""100%"" cellspacing=""1"" cellpadding=""3"" border=""0"">
	<tr>
    <td width=""30%""><span class=""ya-share2"" data-lang=""en"" data-yasharedescription=""Международный, русскоязычный Торрент-трекер NNM-Club"" data-yashareimage=""https://nnmstatic.win/forum/images/nnm90.jpg"" data-size=""s"" data-services=""facebook,twitter,odnoklassniki,moimir,gplus,vkontakte,viber,whatsapp,skype""></span></td>
    <td align=""center""><form action=""search.php?mode=results"" method=""POST"">
      <input type=""hidden"" name=""show_results"" value=""posts"">
      <input name=""topic_id"" type=""hidden"" value=""1744589"">
      <input name=""search_keywords"" value=""Поиск в теме"" class=""hint"" style=""vertical-align:middle;width:240px;position:relative"" type=""text"">
      <input class=""fbutton"" type=""submit"" name=""search_submit"" value=""&raquo;""></form>
    </td>
    <td align=""right"" width=""30%""><a href=""viewtopic.php?t=1744589&amp;view=previous"" class=""nav"">Предыдущая тема</a> :: <a href=""viewtopic.php?t=1744589&amp;view=next"" class=""nav"">Следующая тема</a>&nbsp;</td>
	</tr>
</table>
<table class=""forumline"" width=""100%"" cellspacing=""1"" cellpadding=""3"" border=""0"">
		<tr>
		<th class=""thTop"" width=""11%"" height=""24"" nowrap=""nowrap"">Автор</th>
		<th class=""thTop"" width=""89%"" height=""24"" nowrap=""nowrap"">Сообщение</th>
	</tr>
		<tr  class=""row1"">

		<td width=""150"" align=""left"" valign=""top"" class=""row1""><a name=""12463766""></a>
														<span class=""genmed"" style=""padding-top: 2px"" title=""Вставить имя или выделенный кусок сообщения."" onmouseout=""bbcode && bbcode.refreshSelection(false)"" onmouseover=""bbcode && bbcode.refreshSelection(true)"" onclick=""bbcode && bbcode.onclickPoster('messer20080','12463766'); return false"">
					<a href=""#"" class=""genmed"" onclick=""return false""><b>messer20080 <span class=""seed_bonus"">&reg;</span></b></a></span><br>
																							<div><a href=""viewtopic.php?t=15061"" rel=""nofollow"" style=""text-decoration:none""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/supercub.gif"" width=""24"" alt=""""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/supercub.gif"" width=""24"" alt=""""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/4star.gif"" alt=""""></a></div>
										<div><var class=""posterAvatar"" title=""images/avatars/30813260864c96353302aa.jpg""></var></div>
													<div>Стаж: 14 лет 4 мес. </div>
										<div>Сообщений: 3813</div>
										<div class=""nobreak"">Ratio: <font color=""green"">26.351</font></div>
										<div class=""nobreak"">Раздал: <span class=""seed"">70.71&nbsp;TB</span></div>
										<div>Поблагодарили: 118128</div>
			              <div class=""rank_progress_bar tit"" title=""<b>Коэффициент благодарности</b><br>Скачал(а): 4838 раз(а)<br>Поблагодарил(а): 10178 раз(а)""><span style=""width:100%"" class=""bar""></span> <span>100%</span></div>
      							<div>Откуда: Измаил</div>
										<div><img src=""https://nnmstatic.win/forum/images/flags/ussr.gif"" alt=""ussr.gif"" title=""ussr"" border=""0"" width=""32"" height=""20""></div>
						<div><img src=""https://nnmstatic.win/forum/images/spacer.gif"" width=""122"" height=""2"" border=""0"" alt=""""></div>
				</td>
			<td class=""row1"" width=""100%"" height=""28"" valign=""top"">
			<table id=""post_12463766"" width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: fixed"">
	<tr>
			<td width=""65%"">
							<span class=""postdata""><a href=""viewtopic.php?p=12463766#12463766"" class=""p-link gensmall"" rel=""nofollow"">
				<img src=""https://nnmstatic.win/forum/templates/smartBlue/images/icon_minipost.gif"" width=""12"" height=""9"" alt=""Сообщение"" title=""Сообщение"" border=""0""></a>				<a class=""p-link gensmall"" href=""viewtopic.php?p=12463766#12463766"" title=""Ссылка на это сообщение"" rel=""nofollow"">22 Авг 2024 15:31:47</a></span><span class=""postdetails"">&nbsp;&nbsp;Приключения Буратино (1975) HDTVRip [H.264]</span>
						</td>
							<td valign=""top"" align=""right"" nowrap=""nowrap""> <a href=""posting.php?mode=quote&amp;p=12463766"" rel=""nofollow"" class=""postquotehref""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_quote.gif"" alt=""Ответить с цитатой"" title=""Ответить с цитатой"" border=""0"" class=""pims""></a>    <a href=""report.php?p=12463766""><img class=""pims"" src=""https://nnmstatic.win/forum/templates/smartBlue/images/icon_report1.gif"" border=""0"" alt=""Обратить внимание модераторов"" title=""Обратить внимание модераторов"" /></a> </td>
				</tr>
	<tr>
			<td colspan=""2""><hr /></td>
	</tr>
	<tr>
			<td colspan=""2""><div class=""postbody"" style=""overflow:auto""><span style=""text-align: center; display: block;""><span style=""color: #006699""><span style=""font-size: 20px; line-height: normal""><span style=""font-weight: bold""> Приключения Буратино (1975) HDTVRip [H.264]</span></span></span></span> <hr /><var class=""postImg postImgAligned img-right"" title=""https://nnmstatic.win/forum/image.php?link=https://i123.fastpic.org/big/2024/0822/43/e4d173f6abf94a1240c9b189fb1b5743.jpeg"">&#10;</var><meta property=""og:image"" content=""https://i123.fastpic.org/big/2024/0822/43/e4d173f6abf94a1240c9b189fb1b5743.jpeg"" /><span style=""font-weight: bold"">Производство:</span> СССР / Беларусьфильм<br /><span style=""font-weight: bold"">Жанр:</span> етский, <a href=""/?q=%EC%FE%E7%E8%EA%EB&w=text"" class=""postLink"">мюзикл</a>, <a href=""/?q=%F4%FD%ED%F2%E5%E7%E8&w=text"" class=""postLink"">фэнтези</a>, <a href=""/?q=%EF%F0%E8%EA%EB%FE%F7%E5%ED%E8%FF&w=text"" class=""postLink"">приключения</a>, семейный<br /><br /><span style=""font-weight: bold"">Режиссер:</span> Леонид Нечаев<br /><span style=""font-weight: bold"">Актеры:</span> Дмитрий Иосифов, Владимир Этуш, Ролан Быков, Елена Санаева, Владимир Басов, Татьяна Проценко, Роман Столкарц, Томас Аугустинас, Григорий Светлорусов, Николай Гринько и другие<br /><br /><span style=""font-weight: bold"">Описание:</span><br />На дурака не нужен нож: ему немного подпоешь - и делай с ним, что хошь! Деревянный человечек, которого Папа Карло выстругал из полена, получился веселым, дерзким, шумным и доверчивым. Лиса Алиса и Кот Базилио завели его в Страну Дураков, но мудрая Черепаха Тортила помогла Буратино найти Золотой Ключик, потому что он был ужасно обаятельным.<br /><br /><noindex><a href=""https://www.kinopoisk.ru/film/77301/"" target=""_blank"" rel=""nofollow noopener noreferrer""><var class=""postImg"" title=""https://www.kinopoisk.ru/rating/77301.gif"">&#10;</var></a></noindex> <noindex><span class=""imdbRatingPlugin"" data-user=""ur79343845"" data-title=""tt0073570"" data-style=""p3""><a href=""https://www.imdb.com/title/tt0073570/?ref_=plg_rt_1"" target=""_blank"" rel=""nofollow noopener noreferrer"" class=""imlink""></a></span></noindex><br /><span style=""font-size: 11px; line-height: normal""><span style=""font-weight: bold"">Возраст:</span> <span style=""color: #008000""><span style=""font-weight: bold"">0+</span> (для любой зрительской аудитории)</span></span><br /><br /><span style=""font-weight: bold"">Релиз от:</span> <span style=""color: #0000BF"">george$t</span><br /><br /><span style=""font-weight: bold"">Продолжительность:</span> 02:13:02<br /><span style=""font-weight: bold"">Качество видео:</span> HDTVRip <a href=""https://www.sendspace.com/file/g37cu5"" rel=""nofollow noopener noreferrer"" class=""postLink""><var class=""postImg"" title=""https://nnmstatic.win/forum/images/channel/sample_light_nnm.png"">&#10;</var></a><br /><span style=""font-weight: bold"">Субтитры:</span> отсутствуют<br /><br /><span style=""font-weight: bold"">Видео:</span> AVC/H.264, 1004x648, ~2478 Kbps<br /><span style=""font-weight: bold"">Аудио:</span> AC3, 2 ch, 192 Kbps </a><div class=""spoiler-wrap"" style=""border: solid #69c;border-width: 1px 1px 1px 2px"">	<div class=""spoiler-body"" title=""MediaInfo&#58;""><pre><br />Общее<br />Уникальный идентификатор                 : 132322649525588351499373005603978673665 (0x638C6A51603FC4FAE3EDED8035ACFE01)<br />Полное имя                               : D:\Видео\Приключения Буратино.mkv<br />Формат                                   : Matroska<br />Версия формата                           : Version 4 / Version 2<br />Размер файла                             : 2,48 Гбайт<br />Продолжительность                        : 2 ч. 13 мин.<br />Общий битрейт                            : 2 671 Кбит/сек<br />Частота кадров                           : 25,000 кадров/сек<br />Дата кодирования                         : 2023-04-03 20:31:40 UTC<br />Программа кодирования                    : mkvmerge v41.0.0 ('Smarra') 32-bit<br />Библиотека кодирования                   : libebml v1.3.9 + libmatroska v1.5.2<br /><br />Видео<br />Идентификатор                            : 1<br />Формат                                   : AVC<br />Формат/Информация                        : Advanced Video Codec<br />Профиль формата                          : <a href=""mailto:High@L4.1"" class=""postLink"">High@L4.1</a><br />Настройки формата                        : CABAC / 12 Ref Frames<br />Параметр CABAC формата                   : Да<br />Параметр RefFrames формата               : 12 кадров<br />Идентификатор кодека                     : V_MPEG4/ISO/AVC<br />Продолжительность                        : 2 ч. 13 мин.<br />Битрейт                                  : 2 478 Кбит/сек<br />Ширина                                   : 1 004 пикселя<br />Высота                                   : 648 пикселей<br />Соотношение сторон дисплея               : 3:2<br />Режим частоты кадров                     : Постоянный<br />Частота кадров                           : 25,000 кадров/сек<br />Цветовое пространство                    : YUV<br />Цветовая субдискретизация                : 4:2:0<br />Битовая глубина                          : 8 бит<br />Тип развёртки                            : Прогрессивная<br />Бит/(Пиксели*Кадры)                      : 0.152<br />Размер потока                            : 2,30 Гбайт (93%)<br />Библиотека кодирования                   : x264 core 164 r3085+55M 938b6d0 t_mod_New [(8 &amp; 10)-bit@all X86]<br />Параметры библиотеки кодирования         : cabac=1 / ref=12 / deblock=1:-2:-2 / analyse=0x3:0x133 / me=umh / subme=10 / psy=1 / fade_compensate=0.00 / psy_rd=1.00:0.10 / mixed_ref=1 / me_range=32 / chroma_me=1 / trellis=2 / 8x8dct=1 / cqm=0 / deadzone=21,11 / fast_pskip=0 / chroma_qp_offset=-3 / threads=12 / lookahead_threads=2 / sliced_threads=0 / nr=0 / decimate=0 / interlaced=0 / bluray_compat=0 / stitchable=1 / constrained_intra=0 / fgo=0 / bframes=9 / b_pyramid=2 / b_adapt=2 / b_bias=0 / direct=3 / weightb=1 / open_gop=0 / weightp=2 / keyint=250 / keyint_min=25 / scenecut=40 / intra_refresh=0 / rc_lookahead=80 / rc=crf / mbtree=0 / crf=18.8000 / qcomp=0.60 / qpmin=0:0:0 / qpmax=69:69:69 / qpstep=4 / vbv_maxrate=62500 / vbv_bufsize=78125 / crf_max=0.0 / nal_hrd=none / filler=0 / ip_ratio=1.40 / pb_ratio=1.30 / aq=1:0.80 / aq-sensitivity=10.00 / aq-factor=1.00:1.00:1.00 / aq2=0 / aq3=0<br />По умолчанию                             : Да<br />Принудительно                            : Нет<br />Цветовой диапазон                        : Limited<br />Основные цвета                           : BT.709<br />Характеристики трансфера                 : BT.709<br />Коэффициенты матрицы                     : BT.709<br /><br />Аудио<br />Идентификатор                            : 2<br />Формат                                   : AC-3<br />Формат/Информация                        : Audio Coding 3<br />Коммерческое название                    : Dolby Digital<br />Идентификатор кодека                     : A_AC3<br />Продолжительность                        : 2 ч. 13 мин.<br />Вид битрейта                             : Постоянный<br />Битрейт                                  : 192 Кбит/сек<br />Канал(-ы)                                : 2 канала<br />Расположение каналов                     : L R<br />Частота дискретизации                    : 48,0 КГц<br />Частота кадров                           : 31,250 кадров/сек (1536 SPF)<br />Метод сжатия                             : С потерями<br />Размер потока                            : 183 Мбайт (7%)<br />Язык                                     : Русский<br />Вид сервиса                              : Complete Main<br />По умолчанию                             : Да<br />Принудительно                            : Нет<br />Нормализация звука речи                  : -27 dB<br />compr                                    : -0.28 dB<br />mixlevel                                 : 285 dB<br />roomtyp                                  : 3<br />ltrtcmixlev                              : -3.0 dB<br />ltrtsurmixlev                            : -3.0 dB<br />lorocmixlev                              : -3.0 dB<br />lorosurmixlev                            : -3.0 dB<br />dialnorm_Average                         : -27 dB<br />dialnorm_Minimum                         : -27 dB<br />dialnorm_Maximum                         : -27 dB<br /></pre> 	</div></div> <div class=""clear""></div><center><span style=""font-weight: bold"">Скриншоты:</span><br /><a href=""https://i.imgur.com/G20VcKj.png"" style=""text-decoration:underline #3ab991;cursor:zoom-in"" class=""highslide"" onclick=""return hs.expand(this,{slideshowGroup: '12463766'})"" rel=""nofollow noopener noreferrer""><var class=""postImg"" title=""https://nnmstatic.win/forum/image.php?link=https://i.imgur.com/K8z1g4g.png"">&#10;</var></a>  <a href=""https://i.imgur.com/PQIFP9L.png"" style=""text-decoration:underline #3ab991;cursor:zoom-in"" class=""highslide"" onclick=""return hs.expand(this,{slideshowGroup: '12463766'})"" rel=""nofollow noopener noreferrer""><var class=""postImg"" title=""https://nnmstatic.win/forum/image.php?link=https://i.imgur.com/XFQ21Zx.png"">&#10;</var></a>  <a href=""https://i.imgur.com/r2O2Zp2.png"" style=""text-decoration:underline #3ab991;cursor:zoom-in"" class=""highslide"" onclick=""return hs.expand(this,{slideshowGroup: '12463766'})"" rel=""nofollow noopener noreferrer""><var class=""postImg"" title=""https://nnmstatic.win/forum/image.php?link=https://i.imgur.com/dpbJO0i.png"">&#10;</var></a>  <a href=""https://i.imgur.com/GfQyYdR.png"" style=""text-decoration:underline #3ab991;cursor:zoom-in"" class=""highslide"" onclick=""return hs.expand(this,{slideshowGroup: '12463766'})"" rel=""nofollow noopener noreferrer""><var class=""postImg"" title=""https://nnmstatic.win/forum/image.php?link=https://i.imgur.com/ChL8C2B.png"">&#10;</var></a> <a href=""https://i.imgur.com/LiNStym.png"" style=""text-decoration:underline #3ab991;cursor:zoom-in"" class=""highslide"" onclick=""return hs.expand(this,{slideshowGroup: '12463766'})"" rel=""nofollow noopener noreferrer""><var class=""postImg"" title=""https://nnmstatic.win/forum/image.php?link=https://i.imgur.com/kDWZcnc.png"">&#10;</var></a><br /></center><br /><center><a href=""/?q=Приключения+Буратино+1975&amp;w=title"" class=""postLink""><span style=""font-size: 16px; line-height: normal""><span style=""color: #800000""><span style=""font-weight: bold"">Все одноименные релизы в Клубе</span></span></span></a></center><br /><span style=""font-size: 11px; line-height: normal""><span style=""font-weight: bold"">Время раздачи:</span> 24/7 (мультитрекер) (минимум до появления первых 3-5 скачавших)</span></div></td>
	</tr>
	<tr><td colspan=""2"">
                                                
<!-- //bt -->
<div><img src=""https://nnmstatic.win/forum/images/spacer.gif"" alt="""" width=""1"" height=""6"" /></div>
<style type=""text/css"">
.dlother {background:url('https://nnmstatic.win/forum/images/dlother.png');width:200px;height:50px;overflow:hidden;margin:0;-webkit-border-radius:5px;-moz-border-radius:5px;border-radius:5px}
.dlother a, .dlother a:hover {color:rgba(255,255,255,0.6);font-size:18px;font-family:Arial;display:block;padding:14px;text-decoration:none;text-align:left;font-weight:normal;margin:0}
.dlother a span {color:#fff}
</style>
<table width=""95%"" border=""0"" cellpadding=""2"" cellspacing=""1"" class=""btTbl"" align=""center"">
        <tr class=""row3"">
                <td colspan=""3"" class=""gen"" align=""center"" style=""padding: 3px""><b>[NNMClub.to]_Priklyucheniya Buratino 1975 HDTVRip-AVC.torrent</b></td>
        </tr>
        <tr class=""row1"">
                <td width=""15%"" class=""genmed"">&nbsp;Торрент:&nbsp;</td>
                <td width=""70%"" class=""genmed"">&nbsp;Зарегистрирован<div style=""float:right""><a href=""subscribe.php?attach_id=1336301"" class=""seedmed tit-top"" title=""Подписавшись на обновление, Вы будете автоматически получать уведомление на емайл адрес о произошедших изменениях в раздаче"">Подписаться на изменения <span class=""subscription_counter"">(0)</span></a>&nbsp;</div></td>
                <td width=""15%"" class=""gensmall"" rowspan=""6"" align=""center"" style=""padding: 5px""><span class=""genmed""><b><a href=""download.php?id=1336301"" rel=""nofollow"">Скачать</a></b></span><br />12.6&nbsp;KB<br /><img src=""https://nnmstatic.win/forum/images/freeleech.gif"" alt=""Free Leech"" title=""Free Leech!"" border=""0"" /><br /><!--noindex--> &nbsp; <a href=""magnet:?xt=urn:btih:742794e92db44cdd83cbb37e16bd2a1fd79c4cff&tr=http%3A%2F%2Fbt02.nnm-club.cc%3A2710%2F0079c192a5152462673217282884ed96%2Fannounce&tr=http%3A%2F%2Fbt02.nnm-club.cc%3A2710%2F0079c192a5152462673217282884ed96%2Fannounce"" title=""Примагнититься""><img src=""https://nnmstatic.win/forum/images/magnet48.png"" width=""42"" height=""48"" border=""0"" alt=""Примагнититься""></a><!--/noindex--></td>
        </tr>
        <tr class=""row1"">
                <td class=""genmed"">&nbsp;Зарегистрирован:&nbsp;</td>
                <td class=""genmed"">&nbsp;22 Авг 2024 15:31:47</td>
        </tr>
        <tr class=""row1"">
                <td class=""genmed"">&nbsp;Размер:&nbsp;</td>
                <td class=""genmed""><span title=""Размер блока: 4&nbsp;MB"">&nbsp;2.48&nbsp;GB&nbsp;</span> <span class=""seedmed"">(Вам доступно: </span><span class=""leechmed"">не ограничено во время Free Leech)&nbsp;</span> </td>
        </tr>
	<tr class=""row1"">
		<td class=""genmed"">&nbsp;Рейтинг:&nbsp;</td>
		<td class=""genmed"">&nbsp;<span id=""VR1336301""><img src=""https://nnmstatic.win/forum/images/super.gif"" alt="""" class=""tit-top"" title=""<b>Просто супер!</b><br>Оценка пользователей<br>более 4.8 баллов из 5!""></span>&nbsp;(Голосов: <span id=""VC1336301"">27</span>)
				<span id=""VD1336301""><input type=""radio"" name=""rate1336301"" value=""5"" onClick=""ajax_do('rate.php?a=1336301&v=5');"" /><span onclick=""nodeClick(this);"">Супер</span><input type=""radio"" name=""rate1336301"" value=""4"" onClick=""ajax_do('rate.php?a=1336301&v=4');"" /><span onclick=""nodeClick(this);"">Хорошо</span></span>				</td>
	</tr>
	<tr class=""row1"">
		<td class=""genmed"">&nbsp;Поблагодарили:&nbsp;</td>
		<td class=""genmed"">&nbsp;<span id=""VT1336301"">81</span><span id=""VB1336301"">&nbsp; <img src=""https://nnmstatic.win/forum/images/sps.gif"" onClick=""this.disabled=true;ajax_do('thank.php?a=1336301');"" title=""Не стесняйтесь благодарить Релизера! Поверьте, автору будет приятно..."" alt=""Спасибо"" style=""cursor:pointer"" /></span> &nbsp; (<span id=""VL1336301""><a href=""#torrent"" onClick=""ajax_do('th_list.php?a=1336301');"" title=""Благодарные пользователи"">список</a></span>)</td>
	</tr>
        <tr class=""row1"">
                <td class=""genmed"">&nbsp;Проверка:&nbsp;</td>
                <td class=""genmed"">&nbsp;Оформление проверено модератором 22 Авг 2024 15:41:39</td>
        </tr>
                <tr class=""row3"">
                <td class=""genmed"" valign=""middle"" align=""center"" colspan=""3"" style=""padding: 3px"">
                <a href=""viewtopic.php?t=366"">Как cкачать</a> &nbsp;·&nbsp; <a href=""viewtopic.php?t=892"">Как раздать</a> &nbsp;·&nbsp; <a href=""viewtopic.php?t=3842"">Правильно оформить</a> &nbsp;·&nbsp; <a href=""viewtopic.php?t=154688"">Поднять ратио!</a>
                        &nbsp;</td>
    </table>
<div align=""center"">
  <div class=""spoiler-wrap"" align=""center"" style=""width: 95%; margin: 6px auto; clear: both; border: solid #6699CC; background: #D0DFEF; border-width: 1px 1px 1px 2px;"" onmousedown=""var d=document.getElementById('contentdiv');if(!d.flDone){ajax_do('filelst.php?attach_id=1336301');}"">
    <div class=""spoiler-body"" id=""contentdiv"" style=""border-top:1px solid #6699CC; background: #F4F8FB; padding: 1px 6px 2px; display: none;overflow:auto;max-height:350px;"" title=""Список файлов в торренте"">&nbsp;</div>
    <div class=""clear""></div>
  </div>
</div>
<div id=""simil""></div>
<div align=""center"">                 <div class=""spoiler-wrap"" align=""center"" style=""width: 95%; margin: 6px auto; clear: both; border: solid #6699CC; background: #D0DFEF; border-width: 1px 1px 1px 2px; font-weight: bold;"">
                <div class=""sim spoiler-body"" style=""border-top:1px solid #6699CC; background: #F4F8FB; padding: 1px 6px 2px; display: none;"" title=""Похожие темы (3110 совп.; «приключен, буратин»):""><br />
                                <table border=""0"" cellpadding=""2"" cellspacing=""1"" class=""btTbl"" width=""95%"">
                <tbody>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">18 Май 2024 18:46:16</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=470"" target=""_blank"" title=""Фантастика, Фэнтези (аудиокниги)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Фантастика, Фэнтези (аудиокниги)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1724169"" target=""_blank"" title=""Алексей Брусницын | Приключения Буратино (Книга 3.5). Петрович (2024) [MP3, Сергей Чонишвили]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Алексей Брусницын | Приключения Буратино (Книга 3.5). Петрович (2024) [MP3, Сергей Чонишвили] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">23.9&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">01 Окт 2023 21:16:19</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=470"" target=""_blank"" title=""Фантастика, Фэнтези (аудиокниги)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Фантастика, Фэнтези (аудиокниги)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1665823"" target=""_blank"" title=""Алексей Брусницын | Приключения Буратино (Книга 3). Игра снов (2023) [MP3, Сергей Чонишвили]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Алексей Брусницын | Приключения Буратино (Книга 3). Игра снов (2023) [MP3, Сергей Чонишвили] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">391&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">15 Сен 2022 17:49:35</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=470"" target=""_blank"" title=""Фантастика, Фэнтези (аудиокниги)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Фантастика, Фэнтези (аудиокниги)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1576768"" target=""_blank"" title=""Алексей Брусницын | Приключения Буратино (Книга 2). Новейший Завет (2022) [MP3, Сергей Чонишвили]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Алексей Брусницын | Приключения Буратино (Книга 2). Новейший Завет (2022) [MP3, Сергей Чонишвили] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">1.05&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">23 Апр 2022 13:11:41</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=1345"" target=""_blank"" title=""Отечественные Фильмы и Сериалы для детей (HD, FHD, UHD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Фильмы и Сериалы для детей (HD, FHD, UHD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1546315"" target=""_blank"" title=""Приключения Буратино (1975) WEB-DL [VP9/1440p]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1975) WEB-DL [VP9/1440p] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">4.54&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">23 Апр 2022 10:24:58</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=1345"" target=""_blank"" title=""Отечественные Фильмы и Сериалы для детей (HD, FHD, UHD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Фильмы и Сериалы для детей (HD, FHD, UHD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1546280"" target=""_blank"" title=""Приключения Буратино (1975) WEB-DL [VP9/2160p] [Реставрация Беларусьфильм]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1975) WEB-DL [VP9/2160p] [Реставрация Беларусьфильм] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">7.85&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">18 Апр 2022 16:09:05</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=1345"" target=""_blank"" title=""Отечественные Фильмы и Сериалы для детей (HD, FHD, UHD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Фильмы и Сериалы для детей (HD, FHD, UHD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1545179"" target=""_blank"" title=""Приключения Буратино (1975) WEB-DLRip [H.264/1080p-LQ]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1975) WEB-DLRip [H.264/1080p-LQ] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">8.54&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">22 Май 2021 13:10:31</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=735"" target=""_blank"" title=""Аудиокниги для детей и родителей"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Аудиокниги для детей и родителей
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1471809"" target=""_blank"" title=""Алексей Николаевич Толстой | Золотой ключик, или Приключения Буратино (2013) [MP3]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Алексей Николаевич Толстой | Золотой ключик, или Приключения Буратино (2013) [MP3] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">88.1&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">04 Дек 2020 17:22:57</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=1345"" target=""_blank"" title=""Отечественные Фильмы и Сериалы для детей (HD, FHD, UHD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Фильмы и Сериалы для детей (HD, FHD, UHD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1428953"" target=""_blank"" title=""Приключения Буратино (1975) DVDRip [H.264/1080p-LQ] [handmade remastered upscale AI]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1975) DVDRip [H.264/1080p-LQ] [handmade remastered upscale AI] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">8.51&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">18 Июн 2020 10:00:21</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=731"" target=""_blank"" title=""Отечественные Фильмы и Сериалы для детей (SD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Фильмы и Сериалы для детей (SD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1390991"" target=""_blank"" title=""Приключения Буратино (1975) DVDRip [H.264]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1975) DVDRip [H.264] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">4.61&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">18 Июн 2020 09:44:15</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=1329"" target=""_blank"" title=""Отечественные Мультфильмы 20-го века (SD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Мультфильмы 20-го века (SD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1390989"" target=""_blank"" title=""Приключения Буратино (1959) DVDRip [H.264]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1959) DVDRip [H.264] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">1.31&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">28 Май 2020 19:43:05</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=739"" target=""_blank"" title=""Детская литература"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Детская литература
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1386363"" target=""_blank"" title=""Алексей Толстой | Золотой ключик, или Приключения Буратино (2020) [EPUB]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Алексей Толстой | Золотой ключик, или Приключения Буратино (2020) [EPUB] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">15.2&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">15 Фев 2019 04:23:51</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=731"" target=""_blank"" title=""Отечественные Фильмы и Сериалы для детей (SD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Фильмы и Сериалы для детей (SD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1283026"" target=""_blank"" title=""Приключения Буратино (1975) DVBRip [H.264]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1975) DVBRip [H.264] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">2.18&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">28 Авг 2016 06:00:36</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=739"" target=""_blank"" title=""Детская литература"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Детская литература
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1046828"" target=""_blank"" title=""А.Н. Толстой | Золотой ключик или приключения Буратино [Первое издание] (1936) [PDF]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        А.Н. Толстой | Золотой ключик или приключения Буратино [Первое издание] (1936) [PDF] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">53.1&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">24 Июл 2016 16:44:24</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=739"" target=""_blank"" title=""Детская литература"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Детская литература
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1037548"" target=""_blank"" title=""А. Толстой | Золотой ключик или приключения Буратино (1963) [PDF, DJVU]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        А. Толстой | Золотой ключик или приключения Буратино (1963) [PDF, DJVU] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">95.7&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">01 Июн 2016 12:21:04</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=731"" target=""_blank"" title=""Отечественные Фильмы и Сериалы для детей (SD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Фильмы и Сериалы для детей (SD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=1022262"" target=""_blank"" title=""Приключения Буратино (1975) DVD5"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1975) DVD5 <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">4.06&nbsp;GB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">23 Окт 2015 17:25:07</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=739"" target=""_blank"" title=""Детская литература"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Детская литература
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=949534"" target=""_blank"" title=""Алексей Толстой и др. | Приключения Буратино [6 книг] (1936-2005) [FB2, DJVU]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Алексей Толстой и др. | Приключения Буратино [6 книг] (1936-2005) [FB2, DJVU] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">19.1&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">29 Июн 2015 17:32:45</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=184"" target=""_blank"" title=""Архив КПК и Мобильных устройств"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Архив КПК и Мобильных устройств
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=913607"" target=""_blank"" title=""Приключения Буратино 1.2 [Ru]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино 1.2 [Ru] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">27.4&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">18 Ноя 2014 14:31:06</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=735"" target=""_blank"" title=""Аудиокниги для детей и родителей"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Аудиокниги для детей и родителей
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=842299"" target=""_blank"" title=""А.Н. Толстой | Невероятные приключения Буратино (1995) [MP3]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        А.Н. Толстой | Невероятные приключения Буратино (1995) [MP3] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">92.7&nbsp;MB</td>
                        </tr>                        <tr class=""row1"">
                            <td class=""genmed"" width=""80"" style=""white-space: nowrap;text-align:left;"">01 Сен 2014 13:57:57</td>
                            <td class=""genmed"" width=""115"">
                                <a href=""viewforum.php?f=731"" target=""_blank"" title=""Отечественные Фильмы и Сериалы для детей (SD)"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:115px;"">
                                        Отечественные Фильмы и Сериалы для детей (SD)
                                </a>
                            </td>
                            <td width=""10"" align=""center"">4</td>
                            <td class=""genmed"" width=""500"">
                                <a href=""viewtopic.php?t=817927"" target=""_blank"" title=""Приключения Буратино (1975) DVDRip [H.264]"" class=""dupz""
                                    style=""text-align:left;white-space:nowrap;display:block;overflow:hidden;width:500px; "">
                                        Приключения Буратино (1975) DVDRip [H.264] <img src=""https://nnmstatic.win/forum/images/platinum.gif"" alt=""Платиновая раздача"" title=""Платиновая раздача""> 
                                </a>
                            </td>
                            <td class=""genmed"" width=""50"" align=""center"">1.4&nbsp;GB</td>
                        </tr></tbody></table></div></div> </div>
<div><img src=""https://nnmstatic.win/forum/images/spacer.gif"" alt="""" width=""1"" height=""6"" /></div>
<!-- //bt end -->
</td></tr>

	<tr>
			<td colspan=""2""><div style=""max-height:96px;overflow:hidden"" class=""signature""></div><span class=""gensmall""></span></td>
	</tr>
		</table></td>
	</tr>


		<tr  class=""row1"">

		<td class=""row1"" width=""150"" align=""left"" valign=""middle"" nowrap=""nowrap""><span class=""nav""><a href=""#top"" class=""nav"">Вернуться к началу</a></span></td>
		<td class=""row1"" width=""100%"" height=""28"" valign=""bottom"" nowrap=""nowrap""><table cellspacing=""0"" cellpadding=""0"" border=""0"" height=""18"" width=""100%"">
			<tr>
				<td width=""50%"" valign=""middle"" nowrap=""nowrap""><a href=""profile.php?mode=viewprofile&amp;u=1417083"" rel=""nofollow""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_profile.gif"" alt=""Посмотреть профиль"" title=""Посмотреть профиль"" border=""0""></a> <a href=""privmsg.php?mode=post&amp;u=1417083"" rel=""nofollow""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_pm.gif"" alt=""Отправить личное сообщение"" title=""Отправить личное сообщение"" border=""0""></a>    <a href=""tg://resolve?domain=messer20080"" rel=""nofollow noopener noreferrer""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_tg.png"" alt=""Telegram"" title=""Telegram"" border=""0""></a>   <a href=""tracker.php?pid=1417083""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_rel.png"" alt=""Найти релизы"" title=""Найти релизы"" border=""0""></a></td>
				<td align=""right"" width=""50%"" valign=""middle"" style=""padding-right:30px""></td>
			</tr>
		</table></td>
	</tr>
	    
	<tr>
		<td class=""spaceRow"" colspan=""2"">
<a name=""pagestart""></a>		<img src=""https://nnmstatic.win/forum/images/spacer.gif"" alt="""" width=""1"" height=""1""></td>
	</tr>
		<tr  class=""row2"">

		<td width=""150"" align=""left"" valign=""top"" class=""row2""><a name=""12464474""></a>
														<span class=""genmed"" style=""padding-top: 2px"" title=""Вставить имя или выделенный кусок сообщения."" onmouseout=""bbcode && bbcode.refreshSelection(false)"" onmouseover=""bbcode && bbcode.refreshSelection(true)"" onclick=""bbcode && bbcode.onclickPoster('danrecords','12464474'); return false"">
					<a href=""#"" class=""genmed"" onclick=""return false""><b>danrecords</b></a></span><br>
																							<div><a href=""viewtopic.php?t=15061"" rel=""nofollow"" style=""text-decoration:none""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/icon_dp2.gif"" alt=""""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/icon_dp2.gif"" alt=""""></a></div>
										<div><var class=""posterAvatar"" title=""images/avatars/17300225594ed4e1ba8b139.jpg""></var><br><img src=""https://nnmstatic.win/forum/images/online.gif"" alt=""Online"" style=""margin-top:2""></div>
													<div>Стаж: 12 лет 8 мес. </div>
										<div>Сообщений: 5574</div>
										<div class=""nobreak"">Ratio: <font color=""green"">9.182</font></div>
													<div>Поблагодарили: 4</div>
			              <div class=""rank_progress_bar tit"" title=""<b>Коэффициент благодарности</b><br>Скачал(а): 6319 раз(а)<br>Поблагодарил(а): 16359 раз(а)""><span style=""width:100%"" class=""bar""></span> <span>100%</span></div>
      							<div>Откуда: Беларусь, Минск</div>
										<div><img src=""https://nnmstatic.win/forum/images/flags/belarus.gif"" alt=""belarus.gif"" title=""belarus"" border=""0"" width=""32"" height=""20""></div>
						<div><img src=""https://nnmstatic.win/forum/images/spacer.gif"" width=""122"" height=""2"" border=""0"" alt=""""></div>
				</td>
			<td class=""row2"" width=""100%"" height=""28"" valign=""top"">
			<table id=""post_12464474"" width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""table-layout: fixed"">
	<tr>
			<td width=""65%"">
							<span class=""postdata""><a href=""viewtopic.php?p=12464474#12464474"" class=""p-link gensmall"" rel=""nofollow"">
				<img src=""https://nnmstatic.win/forum/templates/smartBlue/images/icon_minipost.gif"" width=""12"" height=""9"" alt=""Сообщение"" title=""Сообщение"" border=""0""></a>				<a class=""p-link gensmall"" href=""viewtopic.php?p=12464474#12464474"" title=""Ссылка на это сообщение"" rel=""nofollow"">23 Авг 2024 11:19:59</a></span><span class=""postdetails"">&nbsp;&nbsp;</span>
						</td>
							<td valign=""top"" align=""right"" nowrap=""nowrap""> <a href=""posting.php?mode=quote&amp;p=12464474"" rel=""nofollow"" class=""postquotehref""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_quote.gif"" alt=""Ответить с цитатой"" title=""Ответить с цитатой"" border=""0"" class=""pims""></a>    <a href=""report.php?p=12464474""><img class=""pims"" src=""https://nnmstatic.win/forum/templates/smartBlue/images/icon_report1.gif"" border=""0"" alt=""Обратить внимание модераторов"" title=""Обратить внимание модераторов"" /></a> </td>
				</tr>
	<tr>
			<td colspan=""2""><hr /></td>
	</tr>
	<tr>
			<td colspan=""2""><div class=""postbody"" style=""overflow:auto"">Классный фильм, смотрю его с самого детства, а мне уже шестой десяток! Актеры, музыка, песни просто неподражаемы...Карабас, Дуремар, Тортила, Кот и Лиса сыграны знаменитыми актёрами просто гениально!</div></td>
	</tr>
	
	<tr>
			<td colspan=""2""><div style=""max-height:96px;overflow:hidden"" class=""signature""><br />_________________<br />Слушать попсу нельзя!</div><span class=""gensmall""></span></td>
	</tr>
		</table></td>
	</tr>


		<tr  class=""row2"">

		<td class=""row2"" width=""150"" align=""left"" valign=""middle"" nowrap=""nowrap""><span class=""nav""><a href=""#top"" class=""nav"">Вернуться к началу</a></span></td>
		<td class=""row2"" width=""100%"" height=""28"" valign=""bottom"" nowrap=""nowrap""><table cellspacing=""0"" cellpadding=""0"" border=""0"" height=""18"" width=""100%"">
			<tr>
				<td width=""50%"" valign=""middle"" nowrap=""nowrap""><a href=""profile.php?mode=viewprofile&amp;u=5238318"" rel=""nofollow""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_profile.gif"" alt=""Посмотреть профиль"" title=""Посмотреть профиль"" border=""0""></a> <a href=""privmsg.php?mode=post&amp;u=5238318"" rel=""nofollow""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_pm.gif"" alt=""Отправить личное сообщение"" title=""Отправить личное сообщение"" border=""0""></a>       <a href=""tracker.php?pid=5238318""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/icon_rel.png"" alt=""Найти релизы"" title=""Найти релизы"" border=""0""></a></td>
				<td align=""right"" width=""50%"" valign=""middle"" style=""padding-right:30px""><span id=""VTT12464474""><input type=""image"" src=""https://nnmstatic.win/forum/templates/smartBlue/images/like1.png"" name=""like12464474"" value=""1"" onClick=""$.getScript('like.php?p=12464474&amp;likemode=like')"" title=""Мне нравится!"" alt="""" class=""lb-like-icon"" /><input type=""image"" src=""https://nnmstatic.win/forum/templates/smartBlue/images/like1.png"" name=""dislike12464474"" value=""1"" onClick=""$.getScript('like.php?p=12464474&amp;likemode=dislike')"" title=""Мне не нравится!"" alt="""" class=""lb-like-icon"" style=""transform:rotateZ(180deg)"" /></span><span id=""VTC12464474"" class=""lb-count"">+1</span></td>
			</tr>
		</table></td>
	</tr>
	    
   <tr> 
      <td colspan=""2"" class=""row1""> 
         <table class=""forumline"" cellspacing=""1"" cellpadding=""3"" border=""0"" width=""100%""> 
            <tr> 
               <td class=""row2"" align=""right""><span id=""VLP12464474""><a href=""#likelist"" onClick=""ajax_do('like_list.php?p=12464474');"" style=""color:#4183C4;font-weight:bold;text-decoration:none"" title=""Список пользователей"">Нравится! <span id=""VTDL12464474"">(1)</span>&nbsp;&nbsp;|&nbsp;&nbsp;Не нравится! <span id=""VTDD12464474"">(0)</span></a></span></td>    
            </tr> 
         </table> 
      </td> 
   </tr> 
    
	<tr>
		<td class=""spaceRow"" colspan=""2"">
		<img src=""https://nnmstatic.win/forum/images/spacer.gif"" alt="""" width=""1"" height=""1""></td>
	</tr>
	
	<!-- ADS -->
	<tr>
		<td colspan=""2"" align=""center""></td>
	</tr>
	<!-- ADS -->
		<tr>
		<th colspan=""2"" class=""thHead"" height=""20"" align=""center""><b>Форма быстрого ответа</b></th>
	</tr>
	<tr>
		<td colspan=""2"" class=""row2"" align=""center"">
		<form style=""display: inline"" action=""posting.php"" method=""post"" name=""post"" onsubmit=""return checkForm(this)"">
<!--		<p><font color=""red""><b>Клуб временно работает в режиме ""Только чтение"" Торренты качаются. 
		Приносим извинения за доставленные неудобства. Время окончания работ 18.00</b></font></p>-->
		<input type=""hidden"" name=""sid"" value=""41641e2e6357ae97ebd8eac40e4d5a4e"" />
			<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
								<tr>
          <td width=""30%"" class=""row2"" style=""padding:20px""><div style=""text-align:center;font-weight:bold"">Внимание!</div>
Мы  удалим Ваш комментарий если в нем есть нецензурная брань, оскорбления, троллинг, а так же неаргументированные высказывания и просьбы о скорости!</td>
					<td width=""40%"" class=""row2"" align=""center"" valign=""top"">
					<span class=""genmed"">
						<input class=""button"" title=""Bold (Ctrl+B)"" style=""font-weight:bold;width:30px"" type=""button"" value=""B"" name=""codeB"">
						<input class=""button"" title=""Italic (Ctrl+I)"" style=""width:30px;font-style:italic"" type=""button"" value=""i"" name=""codeI"">
						<input class=""button"" title=""Underline (Ctrl+U)"" style=""width:30px;text-decoration:underline"" type=""button"" value=""u"" name=""codeU"">
						<input class=""button"" title=""Quote (Ctrl+Q)"" style=""width:60px"" type=""button"" value=""Quote"" name=""codeQuote"">
						<input class=""button"" title=""Image (Ctrl+R)"" style=""width:40px"" type=""button"" value=""Img"" name=""codeImg"">
						<input class=""button"" type=""button"" value=""YouTube"" name=""codeYouTube"" title=""YouTube"" style=""width:70px"" onMouseOver=""helpline('youtube')"">
						<input class=""button"" title=""Code (Ctrl+K)"" style=""width:45px"" type=""button"" value=""Code"" name=""codeCode"">
                        						<input class=""button"" title=""Цитировать выделенный текст"" style=""width:120px"" type=""button"" name=""quoteselected"" value=""Quote selected"" onmouseout=""bbcode && bbcode.refreshSelection(false)"" onmouseover=""bbcode && bbcode.refreshSelection(true)"" onclick=""bbcode && bbcode.onclickQuoteSel(); return false"">
						<input class=""button"" title=""(-;"" style=""width:60px"" onclick=""window.open('posting.php?mode=smilies', '_phpbbsmilies', 'HEIGHT=400,WIDTH=500,resizable=yes,scrollbars=yes'); return false"" type=""button"" value=""Smilies"">
						<input class=""button"" title=""Translit"" style=""width:70px"" onclick=""dk_translit2win(document.post.message,this); return false"" type=""button"" value=""Translit"">
						<input class=""button"" title=""Spoiler (Ctrl+S)"" style=""width:60px"" type=""button"" value=""Spoiler"" name=""codeSpoiler"">
					</span><br>
					<span class=""gen""><textarea id=""post_body"" name=""message"" rows=""17"" cols=""78"" wrap=""virtual"" style=""width:700px"" class=""post"" onselect=""storeCaret(this)"" onclick=""storeCaret(this)"" onkeyup=""storeCaret(this)""></textarea></span></td>
					<td width=""30%"" class=""row2"" valign=""top""></td>
				</tr>
				<tr>
					<td colspan=""3"" class=""row2"" align=""center"" valign=""middle"" style=""padding: 6px""><input type=""hidden"" name=""mode"" value=""reply"" /><input type=""hidden"" name=""t"" value=""1744589"" />
            <img src=""https://nnmstatic.win/forum/speller/spell.gif"" onclick=""spellCheck()"" style=""width:20px;height:20px;cursor:pointer;"" alt="""" title="""">&nbsp;
						<input style=""width: 140px"" title=""Alt+Enter"" type=""submit"" name=""preview"" class=""mainoption"" value=""Предв. просмотр"" />&nbsp;
						<input style=""width: 100px"" title=""Ctrl+Enter"" type=""submit"" name=""post"" class=""mainoption"" value=""Отправить"" />&nbsp;
						<img src=""https://nnmstatic.win/forum/speller/options.gif"" style=""width:20px;height:20px;cursor:pointer;"" onclick=""speller.optionsDialog()"" alt="""" title="""">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr id=""post_opt"" class=""row2"">
		<td colspan=""2"" class=""row2"" align=""center"">
<!--		    <table border=""0"" align=""center"">
<tr>
<td>
Загрузить картинку:<br>
<iframe src=""iframe.php?txtcolor=111111&type=blank&size=30"" scrolling=""no"" allowtransparency=""true"" frameborder=""0"" width=""280"" height=""70"">Update your browser for ImageShack.us!</iframe>
</td>
</tr>
</table>-->
			<table cellspacing=""0"" cellpadding=""1"" border=""0"">
				<tr>
<!--					<td class=""genmed"">Отключить:&nbsp;</td>

					<td class=""genmed""><input type=""checkbox"" name=""disable_html"" id=""disable_html""  checked=""checked""   disabled=""disabled""  /></td>
					<td class=""genmed""><label for=""disable_html"">HTML&nbsp;</label></td>

					<td class=""genmed""><input type=""checkbox"" name=""disable_bbcode"" id=""disable_bbcode""   /></td>
					<td class=""genmed""><label for=""disable_bbcode"">BBCode&nbsp;</label></td>
-->
					<td class=""genmed""><input type=""checkbox"" name=""disable_smilies"" id=""disable_smilies""   /></td>
					<td class=""genmed""><label for=""disable_smilies"">Отключить смайлики &nbsp;</label>&nbsp;&nbsp;&nbsp;</td>

					<td class=""genmed""><input type=""checkbox"" name=""attach_sig"" id=""attach_sig""   disabled=""disabled""  /></td>
					<td class=""genmed""><label for=""attach_sig"">Присоединить подпись&nbsp;</label>&nbsp;&nbsp;&nbsp;</td>

					<td class=""genmed""><input type=""checkbox"" name=""notify"" id=""notify""   /></td>
					<td class=""genmed""><label for=""notify"">Уведомлять об ответах&nbsp;</label></td>
				</tr>
			</table>
		</form>
<script language=""JavaScript"">
<!--
var bbcode = new BBCode(document.post.message);
var ctrl = ""ctrl"";
bbcode.addTag(""codeB"", ""b"", null, ""B"", ctrl);
bbcode.addTag(""codeI"", ""i"", null, ""I"", ctrl);
bbcode.addTag(""codeU"", ""u"", null, ""U"", ctrl);
bbcode.addTag(""codeQuote"", ""quote"", null, ""Q"", ctrl);
bbcode.addTag(""codeImg"", ""img"", null, ""R"", ctrl);
bbcode.addTag(""codeYouTube"", ""yt"", ""/yt"", """", ctrl);
bbcode.addTag(""codeCode"", ""code"", null, ""K"", ctrl);
bbcode.addTag(""codeSpoiler"", ""spoiler"", null, ""S"", ctrl);
//-->
</script>
		</td>
	</tr>
		<tr align=""center"">
		<td class=""catBottom"" colspan=""2"" height=""24""><table cellspacing=""0"" cellpadding=""0"" border=""0"">
		<tr>
			<td align=""center""><form method=""post"" action=""viewtopic.php?t=1744589"" style=""display:inline""><span class=""gensmall"">Показать сообщения: <select name=""postdays""><option value=""0"" selected=""selected"">все сообщения</option><option value=""1"">за последний день</option><option value=""7"">за последние 7 дней</option><option value=""14"">за последние 2 недели</option><option value=""30"">за последний месяц</option><option value=""90"">за последние 3 месяца</option><option value=""180"">за последние 6 месяцев</option><option value=""364"">за последний год</option></select>&nbsp;<select name=""postorder""><option value=""asc"" selected=""selected"">Начиная со старых</option><option value=""desc"">Начиная с новых</option></select>&nbsp;<input type=""submit"" value=""Перейти"" class=""liteoption"" name=""submit"" /></span></form></td>
		</tr></table></td>
	</tr>
</table>

<table width=""100%"" cellspacing=""2"" cellpadding=""2"" border=""0"" align=""center"">
<tr>
	<td align=""left"" valign=""middle"" nowrap=""nowrap""><span class=""nav""><a href=""posting.php?mode=newtopic&amp;f=731""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/post.gif"" border=""0"" alt=""Начать новую тему"" align=""middle""></a>&nbsp;&nbsp;&nbsp;<a href=""posting.php?mode=reply&amp;t=1744589""><img src=""https://nnmstatic.win/forum/templates/smartBlue/images/lang_russian/reply.gif"" border=""0"" alt=""Ответить на тему"" align=""middle""></a></span></td>
	<td align=""left"" valign=""middle"" width=""100%""><span class=""nav"">&nbsp;&nbsp;&nbsp;<a href=""index.php"" class=""nav"">Торрент-трекер NNM-Club</a>
		-> <a class=""nav"" href=""viewforum.php?f=724"">Видео, Кино и Сериалы для детей и родителей</a>
		-> <a href=""viewforum.php?f=731"" class=""nav"">Отечественные Фильмы и Сериалы для детей (SD)</a></span></td>
	<td align=""right"" valign=""top"" nowrap=""nowrap""><span class=""gensmall"">Часовой пояс: GMT + 3</span><br><span class=""nav""></span>
	</td>
</tr>
<tr>
	<td align=""left"" colspan=""3""><span class=""nav"">Страница <b>1</b> из <b>1</b></span></td>
</tr>
</table>
<table width=""100%"" cellspacing=""2"" border=""0"" align=""center"">
<tr>
	<td width=""40%"" valign=""top"" nowrap=""nowrap"" align=""left""><span class=""gensmall""><a href=""viewtopic.php?t=1744589&amp;watch=topic&amp;start=0&amp;sid=41641e2e6357ae97ebd8eac40e4d5a4e"">Добавить&nbsp;тему&nbsp;в&nbsp;закладки</a></span><br>
	&nbsp;<br>
	Вы <b>можете</b> начинать темы<br>Вы <b>можете</b> отвечать на сообщения<br>Вы <b>можете</b> редактировать свои сообщения<br>Вы <b>не можете</b> удалять свои сообщения<br>Вы <b>можете</b> голосовать в опросах<br>Вы <b>можете</b> присоединять файлы в этом форуме<br />Вы <b>можете</b> скачивать файлы в этом форуме<br /></td>
	<td align=""right"" valign=""top"" nowrap=""nowrap""><span class=""gensmall""></span></td>
</tr>
</table>
<script src=""https://nnmstatic.win/forum/misc/js/share.js"" async=""async""></script>
<script type=""text/javascript"" src=""https://nnmstatic.win/forum/speller/spell.js""></script>
<script type=""text/javascript"">
var speller = new Speller({ url: ""speller"", lang: ""ru"", options: Speller.IGNORE_URLS });

function spellCheck() {
speller.check([document.getElementById(""post_body"")]);
}
</script>
<script>
// April's fools
let aprilDate = new Date();
if (aprilDate.getDate() == 1 && aprilDate.getMonth() == 3) {
$('.postquotehref').mouseenter(function () {
    $(this).css('position', 'relative');
    $(this).animate({
        top: Math.max(25, Math.random() * 150) - 75,
        left: Math.max(50, Math.random() * 150) - 75
    }, 100);
});
}
</script>
<div class=""copyright"" style=""margin:6px;color:#000"" align=""center"">[ &nbsp;Powered by <a href=""http://xbtt.sf.net/"" rel=""nofollow"" target=""_blank"">XBTT</a>&nbsp; | &nbsp;Design by <a href=""http://vadaboom-dok.nnm.me/"" rel=""nofollow"" target=""_blank"">Vadaboom</a> &nbsp; | &nbsp;Programmed by <a href=""profile.php?mode=viewprofile&u=1214357"" rel=""nofollow"" target=""_blank"">Alex14san</a>&nbsp;]</div></td></tr></table>


<script type='text/javascript' data-cfasync='false'>
(function(){
  var script = document.createElement('script');
  script.type = 'text/javascript';
  script.charset = 'utf-8';
  script.async = 'true';
  script.src = 'https://nnmstatic.win/forum/ads/eb927f21fc.2407b.js' + '?' + Math.random();
  document.body.appendChild(script);
})();
</script>

<div align=""center"" class=""copyright"">
<table border='0' width='100%'>
<tr>
<td align='center' class='copyright'><br><span class=""postbody""><a id=""panel""></a></span><br>
<tr>
<td>
<!-- NNM-Club.ADs+SAPE Start -->
<center></center>
<!-- NNM-Club.ADs+SAPE End -->
<center></center>
<!-- NNM-Club.ADs+SAPE End -->
<tr>
<td align='center' class='copyright'>
		<div class=""med bold"" style=""margin-left: auto;  margin-right: auto"">
			<a href=""info.php?show=user_agreement"" onclick=""window.open('info.php?show=user_agreement', '_user_agreement', 'HEIGHT=500,resizable=yes,WIDTH=780'); return false;"">Пользовательское соглашение</a>
			<span class=""normal"">&nbsp;|&nbsp;</span>
			<a href=""info.php?show=copyright_holders"" onclick=""window.open('info.php?show=copyright_holders', '_copyright_holders', 'HEIGHT=500,resizable=yes,WIDTH=780'); return false;"">Для правообладателей</a>
			<span class=""normal"">&nbsp;|&nbsp;</span>
			<a href=""misc/html/advert.html"" onclick=""return hs.htmlExpand(this, { objectType: 'iframe', width: '1024', headingText: 'Реклама на NNM-Club.me', slideshowGroup: 'advert', wrapperClassName: 'titlebar' } )"">Реклама на сайте</a>
		</div>
		<br>
</td></tr>
<tr><td align='center' class='copyright'>
</td></tr>
<tr><td id='livi' align='center' class='copyright'>
</td></tr>

</table>
</div>
</td></tr></table><!--<div class=""b-magic-forest""></div>--></div>
<div id=""preload"" style=""position: absolute; overflow: hidden; top: 0; left: 0; height: 1px; width: 1px;""></div>
<!--<div id=""april"" class=""highslide-maincontent"">
<img src=""images/1april.jpg"" style=""margin:10px"" align=""left"">
<p>День смеха и юмора отмечается 1 апреля. В этот день принято шутить и разыгрывать друзей, коллег по работе, домашних, словом всех, с кем Вам предстоит увидеться в этот праздник – первое апреля. Первоапрельские розыгрыши, приколы на 1 апреля, первоапрельские шутки должны быть веселыми и безобидными. Приколы на 1 апреля, как правило, удаются в том случае, если человек забыл какой сегодня месяц и день, словом, забыл про 1 апреля – день смеха, шуток, день дурака.</p>
<p>Желаем Вам много улыбок и хорошего настроения в этот день!<br><span style=""font-family:Segoe Print;font-weight:bold"">С Уважением, администрация NNM-Club</span> <img src=""images/smiles/k_smile.gif"" alt="":)"" border=""0""></p>
</div>-->
<script type=""text/javascript"" src=""https://nnmstatic.win/forum/docs/requests.js""></script>
<!-- Yandex.Metrika counter --><script type=""text/javascript"">(function(m,e,t,r,i,k,a){m[i]=m[i]||function(){(m[i].a=m[i].a||[]).push(arguments)};m[i].l=1*new Date();k=e.createElement(t),a=e.getElementsByTagName(t)[0],k.async=1,k.src=r,a.parentNode.insertBefore(k,a)})
   (window, document, ""script"", ""https://mc.yandex.ru/metrika/tag.js"", ""ym"");ym(222923,""init"",{trackLinks:true,accurateTrackBounce:true});</script><noscript><div><img src=""https://mc.yandex.ru/watch/222923"" style=""position:absolute; left:-9999px;"" alt="""" /></div></noscript><!-- /Yandex.Metrika counter -->
<script type='text/javascript' src='https://nnmstatic.win/forum/new_year/newyear2022a.js' charset='windows-1251'></script>
<!--[if lte IE 9]><script type='text/javascript' src='https://nnmstatic.win/forum/misc/js/textshadow.min.js'></script>
<script type='text/javascript' src='https://nnmstatic.win/forum/misc/js/placeholder.js'></script>
<![endif]-->
<!--[if (gte IE 9)|!(IE)]>--><script type='text/javascript' src='https://nnmstatic.win/forum/misc/js/logomusic.js'></script><!--<![endif]-->
<script type='text/javascript' src='https://nnmstatic.win/forum/misc/js/imgbbtest.js?5' charset='windows-1251'></script>
<script>
$(function(){var a=$(""#optlist option"").map(function(){return[[this.value,$(this).text()]]});$(""#someinput"").keyup(function(){var b=new RegExp($(""#someinput"").val(),""i""),c=$(""#optlist"").empty();a.each(function(){b.test(this[1])&&c.append($(""<option/>"").attr(""value"",this[0]).text(this[1]))})})});
</script>
<script>
$(function(){var o=$(""#post_174458922"");o.length&&(o.addClass(""scrolled-to-post""),setTimeout(function(){$.scrollTo(o,{duration:0,offset:-3})},300))});
</script>
<script type='text/javascript' src='https://www.google-analytics.com/ga.js'></script>
<script type='text/javascript'>
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-1886062-1']);
  _gaq.push(['_setDomainName', 'nnm-club.me']);
  _gaq.push(['_setAllowLinker', true]);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
</script>
<!--<div style=""z-index: 9999; position:fixed;top:-40px;right:-60px;width:300px; height:229px;background:url('images/vetka.gif')""></div>-->
<!--<img src=""http://maxplan.ru:40001/px.jpg"" style=""display:none;"">-->
<script type='text/javascript'>
<!--
jQuery(document).ready(function(){
initPost();
$('a.dupz').each(function(){
	var a = $(this), td = $(a.parents('td')[0]);
	a.css('width', td.width() + 'px');
});
$('var.posterAvatar').each(function(){
	var v = $(this), src = v.attr('title'),img = $('<img style=""max-width:120px; max-height:120px;"" border=""0"" title=""pic"" />').attr('src', 'https://nnmstatic.win/forum/' + src);
	v.append(img);
});
$('#livi').html('\x3Ca href=""https://www.liveinternet.ru/stat/nnm-club.ru/"" target=_blank>\x3Cimg src=""https://counter.yadro.ru/hit?t52.10;r'+escape(document.referrer)+((typeof(screen)=='undefined')?'':';s'+screen.width+'*'+screen.height+'*'+(screen.colorDepth?screen.colorDepth:screen.pixelDepth))+';u'+escape(document.URL)+';'+Math.random()+'"" alt="""" title=""LiveInternet: показано число просмотров и посетителей за 24 часа"" border=0 width=88 height=31>\x3C/a> &nbsp; \x3Ca href=""http://nnmclub2vvjqzjne6q4rrozkkkdmlvnrcsyes2bbkm7e5ut2aproy4id.onion"" title=""NNM-Club в TOR"" target=""_blank"">\x3Cimg src=""https://nnmstatic.win/forum/images/onion.gif"" width=""88"" height=""31"" border=""0"" alt=""NNM-Club в TOR"">\x3C/a>');
});
//-->
</script>
<noindex></noindex>
</body></html>
";
}