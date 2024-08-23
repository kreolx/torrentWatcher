﻿using Contracts.Interfaces;
using Contracts.Models;
using Engine.Managers.Parsers.Rutracker;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace Test.Engine.Managers.Parsers.Rutracker;

public class UnitTest_PageParseManager
{
    [Fact]
    public async Task LoadData_should_return_correct_data()
    {
	    var client = A.Fake<IHttpTrackerClient>();
        A.CallTo(() => client.GetAsync(A<string>.Ignored, A<CancellationToken>.Ignored))
	        .Returns(GetPage());
        var logger = A.Fake<ILogger<RutrackerPageParserManager>>();
		var manager = new RutrackerPageParserManager(logger, client);
		var postDto = new PostDto("123", "","http://123.ru/forum/viewtopic.php?t=6257950", "", 0, null, null);
		var resultDto = await manager.LoadDataAsync(postDto, default);
		resultDto.Description.Should().NotBeEmpty();
		resultDto.Description.Should().StartWith(": журнал");
		resultDto.ImageUrl.Should()
			.Be("https://i123.fastpic.org/big/2024/0818/c9/7d4eeef2add9842fd810bde405e61bc9.jpeg");
    }
    
    
    string GetPage() => @"<!DOCTYPE html>
<html lang=""ru"">
<head>
<meta charset=""Windows-1251"">
<meta name=""description"" content=""[Журнал] American Fine Art Magazine [2019-2024, PDF, ENG] номеров - 32 &raquo; Коллекционирование и вспомогательные ист. дисциплины :: RuTracker.org"">
<meta name=""robots"" content=""nofollow"">
<link rel=""canonical"" href=""https://rutracker.org/forum/viewtopic.php?t=6257950"">
<title>[Журнал] American Fine Art Magazine [2019-2024, PDF, ENG] номеров - 32 :: RuTracker.org</title>
<link rel=""shortcut icon"" href=""/favicon.ico"" type=""image/x-icon"">
<link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""/favicon-32x32.png"">
<link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""/favicon-16x16.png"">
<link rel=""manifest"" href=""/manifest.json"">
<link rel=""mask-icon"" href=""/safari-pinned-tab.svg"" color=""#5bbad5"">
<meta name=""msapplication-TileColor"" content=""#2b5797"">
<meta name=""msapplication-TileImage"" content=""/mstile-144x144.png"">
<meta name=""theme-color"" content=""#ffffff"">
<link rel=""search"" type=""application/opensearchdescription+xml"" title=""Поиск на RuTracker.org"" href=""https://static.rutracker.cc/opensearch.xml"">
<script>
window.BB = {
	cur_domain: location.hostname.replace(/.*?(([a-z0-9-]+\.){1,2}[a-z0-9-]+)$/, '$1'),
	form_token: 'fe43c73de2e5ec4c43daa0a181681fc8',
	opt_js: {""only_new"":0,""h_flag"":0,""h_av"":0,""h_rnk_i"":0,""h_post_i"":0,""h_smile"":0,""h_sig"":0,""sp_op"":0,""tr_tm"":0,""h_cat"":"""",""h_tsp"":0,""h_ta"":76},

	IS_GUEST: !!'',
	IMG_URL: 'https://static.rutracker.cc/templates/v1/images',
	SMILES_URL: 'https://static.rutracker.cc/smiles',
	catId: 25,
	FORUM_ID: 1412,
	parentForumId: 2033,
		COOKIE_MARK: 'bb_mark_read',
	};
BB.cookie_defaults = {
	domain: '.' + BB.cur_domain,
	path: ""/forum/"",
};
</script>
<link href=""https://static.rutracker.cc/templates/v1/min/10e5495ef26cfc18546ad21a308407ea.all.min.css"" rel=""stylesheet"">
<script src=""https://static.rutracker.cc/templates/v1/min/89cb07925b0747ebeb4acf70951adc9d.lib.min.js""></script>
<script src=""https://static.rutracker.cc/templates/v1/min/22df093cb1ab739edad6e7eb89f13efc.bb.min.js""></script>
<style>
.invisible-el {
	/* @include element-invisible(); */
	clip: rect(1px, 1px, 1px, 1px);
	height: 1px;
	overflow: hidden;
	position: absolute !important;
	width: 1px;
}
.hidden, .menu-sub, #ajax-loading, #ajax-error, var.ajax-params, #modal-blocker, .q-post {
	display: none;
}
/**/
/* temp */
/* temp end */
</style>
<noscript>
	<style>
	.sp-body {
		display: block; /* for bots */
	}
	</style>
</noscript>
</head>
<body class style>
<div id=""invisible-heap"" class=""invisible-el""></div>
<div id=""preload"" class=""invisible-el""></div>
<div id=""misc-hidden-elements"" style=""display: none;"">
<form id=""cse-search-box"" action=""search_cse.php"" accept-charset=""utf-8"">
<input id=""cse-text-match"" type=""text"" name=""q"" size=""60"" value>
<input type=""submit"" value=""Поиск в Google"">
</form>
</div>
<div id=""body_container"">
<script>
	if (top != self && !self.location.hostname.match(BB.allowed_translator_hosts)) {
		$(function () {
			$('body').html('<h1 style=""text-align: center;""><br><br>Похоже, вас пытаются обмануть<br>frame\'s hostname: ' + self.location.hostname + '</h1>');
			throw new Error('in frame');
		});
	}
		</script>
<div id=""page_container"">
<div id=""page_header"" class=""hide-for-print"">
<div id=""main-nav"" class=""site-nav clearfix"">
<ul class=""inlined middot-separated floatL"">
<li>
<a href=""index.php""><b>Главная</b></a>
</li>
<li>
<span class=""menu-split"">
<a href=""tracker.php"" rel=""nofollow""><b>Трекер</b></a>
<a href=""#tr-menu"" class=""menu-root"">
<img src=""https://static.rutracker.cc/templates/v1/images/menu_arrow_1.svg"" alt=""v"">
</a>
</span>
</li>
<li>
<a href=""search.php"" rel=""nofollow""><b>Поиск</b></a>
</li>
<li>
<a href=""groupcp.php"" rel=""nofollow""><b>Группы</b></a>
</li>
<li>
<a href=""http://rutracker.wiki/"" target=""_blank""><b>FAQ</b></a>
</li>
<li>
<a href=""viewforum.php?f=1649"" style=""color: #7b1fa2;""><b>VPN</b></a>
</li>
<li>
<a href=""viewtopic.php?t=1045""><b>Правила</b></a>
</li>
</ul>
<ul class=""inlined middot-separated ext-links"" style=""float: right;"" data-ext_link_data=""{&quot;p&quot;:4,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:1}"">
<li>
<a href=""viewtopic.php?t=6545955"" style=""color: #3f51b5;"" target=""_blank""><b>Браузер для геймеров</b></a> </li>
</ul>
</div>

<div class=""menu-sub"" id=""tr-menu"">
<div class=""menu-a bold nowrap"">
<a class=""med"" href=""tracker.php?f=2033"">Коллекционирование, увлечения и хобби</a>
<a class=""med"" href=""tracker.php?f=1412"">Коллекционирование и вспомогательные ист. дисциплины</a>
</div>
</div>
<div id=""logo"">
<table style=""height: 112px;"">
<tr>
<td id=""logo-td"" style=""padding: 3px 7px 3px 15px;"">
<a href=""index.php"" class=""site-logo-link"">
<img class=""site-logo"" src=""https://static.rutracker.cc/logo/logo-3.svg"" style alt=""logo"">
</a>
</td>
<td class=""tCenter w100"" style=""padding: 6px 10px 0 3px;"">
<style>
/* https://stackoverflow.com/a/23083463 */
#bn-top-block {
	display: none;
	width: 1px;
	/* min-width: JS */
	margin: 0 auto;
	overflow: hidden;
}
</style>
<script>
$(function () {
	var $block = $('#bn-top-block');
	var logoWidth = Math.max($('#logo-td').width(), 250);
	var frameWidth = Math.min($(window).width() - logoWidth - 50, $block.data('max_width'));
	$block.find('img').css({
		'max-width': frameWidth + 'px',
	});
	$block.css({
		'min-width': frameWidth + 'px',
		display: 'inline-block',
	});
});
</script>
<div style=""padding: 6px;"">
<iframe id=""bn-top-block"" data-max_width=""728"" src=""https://www.betsonsport.ru/banners/lend4.php"" height=""90"" marginwidth=""0"" marginheight=""0"" scrolling=""no"" frameborder=""0""></iframe>
</div>
</td>
</tr>
</table>
</div>

<div class=""topmenu"">
<table class=""w100"">
<tr>
<td class=""w50"">
<span class=""top-menu-username-wrap"">
<img class=""log-out-icon"" src=""https://static.rutracker.cc/templates/v1/images/logout_1.png"" onclick=""return post2url('login.php', {logout: 1});"" alt title=""Выход"">
<a id=""logged-in-username"" class=""truncated-text"" href=""https://rutracker.org/forum/profile.php?mode=viewprofile&amp;u=19487848"">kreolx</a>
</span>
</td>
<td class=""tCenter pad_2 nowrap"">
<div>
<form id=""quick-search"" method=""post"" action=""#"">
<input type=""hidden"" name=""max"" value=""1"">
<input id=""search-text"" type=""text"" name=""nm"" value tabindex=""1"" maxlength=""100"" accesskey=""q"">
<select id=""search-menu"" tabindex=""2"">
<option value=""search-tr"" data-action=""tracker.php"" selected> раздачи</option>
<option value=""search-tr"" data-action=""tracker.php"" data-forum_id=""1412""> |- по разделу</option>
<option value=""search-all"" data-action=""search.php""> все темы</option>
<option value=""search-all"" data-action=""search.php"" data-forum_id=""1412""> |- по разделу</option>
<option value=""cse""> в google</option>
<option value=""duckduckgo""> в duckduckgo</option>
<option value=""wiki""> в wiki</option>
<option value=""hash""> по info_hash</option>
</select>
<input id=""search-submit"" type=""submit"" value=""поиск"" tabindex=""3"">
</form>
<button id=""cse-search-btn-top"" data-query_input_id=""search-text"" style=""display: none;""></button>
</div>
</td>
<td class=""tRight w50 nowrap"">
<div>
<ul class=""inlined top-menus"">
<li>
<span class=""menu-split"">
<a href=""privmsg.php?folder=inbox"" class>
ЛС &#x2709; </a>
<a href=""#pms-menu"" class=""menu-root"" data-hide_el_id=""bn-top-right"">
<img src=""https://static.rutracker.cc/templates/v1/images/menu_arrow_1.svg"" alt=""v"">
</a>
</span>
</li>
<li>
<span class=""menu-split"">
<a href=""https://rutracker.org/forum/profile.php?mode=viewprofile&amp;u=19487848"">Профиль</a>
<a href=""#profile-menu"" class=""menu-root"" data-hide_el_id=""bn-top-right"">
<img src=""https://static.rutracker.cc/templates/v1/images/menu_arrow_1.svg"" alt=""v"">
</a>
</span>
</li>
<li>
<span class=""menu-split"">
<a href=""search.php?uid=19487848"">Мои сообщения</a>
<a href=""#my-posts-menu"" class=""menu-root"" data-hide_el_id=""bn-top-right"">
<img src=""https://static.rutracker.cc/templates/v1/images/menu_arrow_1.svg"" alt=""v"">
</a>
</span>
</li>
</ul>
</div>
</td>
</tr>
</table>
</div>
<div id=""pms-menu"" class=""menu-sub"">
<div class=""menu-a bold nowrap"">
<a class=""med"" href=""privmsg.php?folder=inbox"">Входящие</a>
<a class=""med"" href=""privmsg.php?folder=outbox"">Исходящие</a>
<a class=""med"" href=""privmsg.php?folder=sentbox"">Отправленные</a>
<a class=""med"" href=""privmsg.php?folder=savebox"">Сохранённые</a>
</div>
</div>
<div id=""profile-menu"" class=""menu-sub"">
<div class=""menu-a bold nowrap"">
<a class=""med"" href=""profile.php?mode=editprofile"">Настройки</a>
<a class=""med"" href=""search.php?future_dls"">Будущие закачки</a>
<a class=""med"" href=""bookmarks.php"">Избранное</a>
</div>
</div>
<div id=""my-posts-menu"" class=""menu-sub"">
<div class=""menu-a bold nowrap"">
<a class=""med"" href=""tracker.php?rid=19487848"">Мои раздачи</a>
<a class=""med topics-started"" href=""search.php?uid=19487848&amp;myt=1"">Начатые темы</a>
<a class=""med"" href=""posts.php?page=replies_in_started_topics&u=19487848"">Ответы в начатых темах</a>
</div>
</div>
</div>

<div id=""page_content"">
<table style=""width: 100%; border: none;"">
<tr>
<td id=""main_content"">
<div id=""main_content_wrap"">

<style>
/**/
/**/
/**/
/**/
/**/
</style>
<script>
$(function () {
		BB.initMagnetLinks();
	});
</script>
<script>
(function () {
	var loadedText = {};

	ajax.view_post = function (post_id) {
		if (loadedText[post_id] != null) {
			$('#ptx-' + post_id).toggle();
			return;
		}
		ajax.exec({
			action: 'view_post',
			post_id: post_id,
			mode: 'text',
		});
	};
	ajax.callback.view_post = function (data) {
		loadedText[data.post_id] = true;
		$('#p-' + data.post_id).prepend(
			'<textarea id=""ptx-' + data.post_id + '"" style=""width: 99%; height: 200px;"">' + data['post_text'] + '</textarea>'
		);
	};
})();
</script>
<table class=""w100"">
<tr>
<td class=""w100 vBottom pad_2"">
<h1 class=""maintitle"">
<a id=""topic-title"" class=""topic-title-6257950 highlight-cyrillic"" href=""https://rutracker.org/forum/viewtopic.php?t=6257950"">[Журнал] American Fine Art Magazine [2019-2024, PDF, ENG] номеров - 32</a>
</h1>
<div class=""small hide-for-print"" style=""margin: 12px 4px 8px;"">
<b> Страницы: &nbsp;1</b>
</div>
<div class=""small hide-for-print"" style=""margin: 8px 4px;"">
<ul class=""inlined middot-separated"">
<li>
<span id=""forum-moderators"" class=""a-like"">Модераторы</span>
</li>
</ul>
</div>
<table class=""w100"">
<tr>
<td class=""pad_2 hide-for-print"">
<a href=""posting.php?mode=reply&amp;t=6257950""><img src=""https://static.rutracker.cc/templates/v1/images/reply.gif"" alt=""Ответить""></a>
</td>
<td class=""nav t-breadcrumb-top w100 pad_2"">
&nbsp;<a href=""index.php?c=25"">Книги и журналы</a>
<em>&raquo;</em> <a href=""viewforum.php?f=2033"">Коллекционирование, увлечения и хобби</a>
<em>&raquo;</em> <a href=""viewforum.php?f=1412"">Коллекционирование и вспомогательные ист. дисциплины</a>
</td>
</tr>
</table>
</td>
<td class=""pad_2 hide-for-print"">
<div id=""bn-top-right"" class=""ext-links""><a href=""https://atomicheart.vkplay.ru"" target=""_blank"" rel=""nofollow""><img src=""https://rutrk.org/240x120/ref/AtomicHeart_731x408_1.jpg"" style=""width: 240px; height: auto;"" alt></a></div>
</td>
</tr>
</table>
<table id=""t-tor-stats"" class=""forumline dl_list hide-for-print"">
<colgroup>
<col class=""row1"">
</colgroup>
<tr>
<td class=""catTitle"">
<div>Статистика раздачи</div>
</td>
</tr>
<tr>
<td class=""borderless bCenter pad_8"">
Размер:&nbsp; <b>1.31&nbsp;GB</b>&nbsp; &nbsp;|&nbsp;
&nbsp;Зарегистрирован:&nbsp; <b>3 дня</b>&nbsp;
&nbsp;|&nbsp; &nbsp;.torrent скачан:&nbsp; <b>17 раз</b>
</td>
</tr>
<tr>
<td class=""row5 pad_2 tCenter"">
<div class=""mrg_4 pad_4"">
<span class=""seed"">Сиды:&nbsp; <b>5</b></span>
&nbsp;
<span class=""leech"">Личи:&nbsp; <b>1</b></span>
</div>
</td>
</tr>
<tr>
<td class=""row3 pad_4"">
<script>
		$(function () {
			ajax.future_dl = function (action) {
				ajax.exec({
					action: action,
					topic_id: '6257950',
				});
			};
			ajax.callback.add_future_dl = ajax.callback.del_future_dl = function (data) {
				$('#future-dl-buttons-wrap').html(data.html);
			};
			$('#del_future_dl, #add_future_dl').one('click', function () {
				var action = this.id;
				ajax.future_dl(action);
				$(this).removeClass('a-like');
			});
		});
		</script>
<span id=""future-dl-buttons-wrap"">
<span id=""add_future_dl"" class=""a-like med"">Добавить в «Будущие закачки»</span>
</span>
</td>
</tr>
</table>
<div class=""t-top-buttons-wrap row3 med bold hide-for-print"">
<ul id=""t-top-user-buttons"" class=""inlined middot-separated buttons-cell user-buttons"">
<li>
<a class=""med"" href=""bookmarks.php"">Избранное</a>
<span class=""normal"">
<script>
				$(function () {
					$('.action-bookmark').on('click', function () {
						post2url('bookmarks.php', {
							action: this.dataset['action'],
							topic_id: '6257950',
							forum_id: '1412',
							request_origin: 'from_topic_page',
						});
					});
				});
				</script>
[
<span class=""action-bookmark a-like"" data-action=""bookmark_add"">добавить</span>
]
</span>
</li>
<li>
<a class=""med"" href=""search.php?uid=19487848&amp;t=6257950&amp;dm=1"" title=""В этой теме"">Мои сообщения</a>
</li>
<li>
<a class=""med"" href=""search.php?uid=19487848&amp;f=1412"" title=""Ваши сообщения в разделе"">В разделе</a>
</li>
<li>
<a id=""t-view-opt"" class=""menu-root"" href=""#topic-options"">Опции показа</a>
</li>
</ul>
</div>
<div class=""menu-sub"" id=""topic-options"">
<table style=""border-spacing: 1px;"">
<tr>
<th class=""pad_4"">Опции показа</th>
</tr>
<tr>
<td class=""pad_4"">
<fieldset>
<div class=""med"" style=""padding: 6px 2px;"">
<ul>
<li class=""a-like bold"" onclick=""BB.printTopic();"">Версия для печати</li>
</ul>
</div>
</fieldset>
<div class=""spacer_4""></div>
<fieldset id=""show-only"">
<legend>Не показывать</legend>
<div class=""med pad_4"">
<label>
<input type=""checkbox"" onclick=""BB.set_opt_js('h_flag', this.checked ? 1 : 0);"" />флаги
</label>
<label>
<input type=""checkbox"" onclick=""BB.set_opt_js('h_av', this.checked ? 1 : 0);"" />аватары
</label>
<label>
<input type=""checkbox"" onclick=""BB.set_opt_js('h_rnk_i', this.checked ? 1 : 0);"" />картинки званий
</label>
<label>
<input type=""checkbox"" onclick=""BB.set_opt_js('h_post_i', this.checked ? 1 : 0);"" />картинки в сообщениях
</label>
<label>
<input type=""checkbox"" onclick=""BB.set_opt_js('h_smile', this.checked ? 1 : 0);"" />смайлики
</label>
<label>
<input type=""checkbox"" onclick=""BB.set_opt_js('h_sig', this.checked ? 1 : 0);"" />подписи
</label>
</div>
</fieldset>
<div class=""spacer_4""></div>
<fieldset id=""spoiler-opt"">
<legend>Показывать</legend>
<div class=""med pad_4"">
<label>
<input type=""checkbox"" onclick=""BB.set_opt_js('sp_op', this.checked ? 1 : 0);"" />спойлер открытым
</label>
</div>
</fieldset>
</td>
</tr>
<tr>
<td class=""cat tCenter pad_4""><input type=""button"" value=""Отправить"" style=""width: 100px;"" onclick=""window.location.reload();""></td>
</tr>
</table>
</div>
<table class=""topic"" id=""topic_main"">
<tbody class=""hide-for-print"">
<tr>
<th colspan=""2"" class=""thHead"">
<div id=""soc-container"" data-share_url=""https://rutracker.org/forum/viewtopic.php?t=6257950"" data-share_title=""[Журнал] American Fine Art Magazine [2019-2024, PDF, ENG] номеров - 32"">&nbsp;</div>
</th>
</tr>
</tbody>
<tbody id=""post_83619029"" class=""row1"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""83619029""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '83619029');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?t=6257950"">12-Сен-22 21:06</a>
</span>
<span class=""posted_since hide-for-print"">(1 год 11 месяцев назад, ред. 18-Авг-24 09:29)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><span class=""txtb"" onclick=""ajax.view_post('83619029');"">[Код]</span></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-1"">
<div class=""post_body"" id=""p-83619029"" data-ext_link_data=""{&quot;p&quot;:83619029,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<var class=""postImg postImgAligned img-right"" title=""https://i123.fastpic.org/big/2024/0818/c9/7d4eeef2add9842fd810bde405e61bc9.jpeg"">&#10;</var><hr class=""post-hr""><span style=""font-size: 16px; line-height: normal;"">AMERICAN<br>
<span style=""font-size: 28px; line-height: normal;""><span class=""post-b"">Fine Art</span></span><br>
<span style=""font-size: 14px; line-height: normal;"">MAGAZINE</span></span><hr class=""post-hr""><hr class=""post-hr""><span class=""post-b"">Год издания</span>: 2019-2024<br>
<span class=""post-b"">Автор</span>: Главный редактор/издатель: Sarah Gianelli<br>
<span class=""post-b"">Жанр или тематика</span>: Изобразительное искусство<span class=""post-br""><br></span><span class=""post-b"">Издательство</span>: International Artist Publishing Inc<br>
<span class=""post-b"">ISSN</span>: 2162-7827<br>
<span class=""post-b"">Язык</span>: Английский<span class=""post-br""><br></span><span class=""post-b"">Формат</span>: PDF<br>
<span class=""post-b"">Качество</span>: Издательский макет или текст (eBook)<br>
<span class=""post-b"">Интерактивное оглавление</span>: Нет<br>
<span class=""post-b"">Количество страниц</span>: 100<span class=""post-br""><br></span><span class=""post-b"">Описание</span>: журнал ""American Fine Art Magazine"" издается издательством International Artist Publishing, чьи издания ""Коллекционер американского искусства"" и ""Коллекционер западного искусства"" стали ""библиями"" для коллекционеров произведений искусства в соответствующих жанрах. В отличие от других журналов об изобразительном искусстве, журнал ""American Fine Art Magazine"" уникален тем, что в нем анонсировуются предстоящие продажи и аукционы исторического американского искусства до того, как они состоятся, а не просматривать их после окончания выставки.<span class=""post-br""><br></span><span class=""post-b"">Доп. информация</span>: продолжение <a href=""viewtopic.php?t=5497559"" class=""postLink"">этой раздачи</a>
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>Примеры страниц</span></div>
<div class=""sp-body""><a href=""https://fastpic.org/view/120/2022/0912/_53eec7b15bf8b125d5d5b48eb9d25e5b.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/5b/_53eec7b15bf8b125d5d5b48eb9d25e5b.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/_a233a526f3e85add7fcaf36a78e17bac.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/ac/_a233a526f3e85add7fcaf36a78e17bac.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/1cf59f73964f75246781e3d4fa491aca.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/ca/1cf59f73964f75246781e3d4fa491aca.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/f0a825e03ad165767366a45c8b0b91e3.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/e3/f0a825e03ad165767366a45c8b0b91e3.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/_af5486750eaf3801169426f3d1a75b86.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/86/_af5486750eaf3801169426f3d1a75b86.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/_80555f6a2ffec85556f0b5ed56bd2c9e.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/9e/_80555f6a2ffec85556f0b5ed56bd2c9e.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/_6781f7de3151c7266d1c5ed1254b9daa.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/aa/_6781f7de3151c7266d1c5ed1254b9daa.jpeg"">&#10;</var></a></div>
</div>
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>Обложки</span></div>
<div class=""sp-body"">
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>2019</span></div>
<div class=""sp-body""><a href=""https://fastpic.org/view/120/2022/0912/e0700aef610a6d8b47070074700f307b.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/7b/e0700aef610a6d8b47070074700f307b.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/46b98530d7a73b49b61aed7e312d8174.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/74/46b98530d7a73b49b61aed7e312d8174.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/80458c897d6dcff65c161ec561a95bef.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/ef/80458c897d6dcff65c161ec561a95bef.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/de196d829b6cf4443d1da61b14d3638e.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/8e/de196d829b6cf4443d1da61b14d3638e.jpeg"">&#10;</var></a></div>
</div>
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>2020</span></div>
<div class=""sp-body""><a href=""https://fastpic.org/view/120/2022/0912/7e4d986ec41a9ad721cdf6c602e279f5.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/f5/7e4d986ec41a9ad721cdf6c602e279f5.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/ad249187271c3cdaa47c97c714843864.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/64/ad249187271c3cdaa47c97c714843864.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/966e0a5d459c66daf46eedb98e4fbb96.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/96/966e0a5d459c66daf46eedb98e4fbb96.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/c6376c6a507fb2558f489c600d2c464f.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/4f/c6376c6a507fb2558f489c600d2c464f.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/dd7d44429959d2d0802f2c9750ecfbb2.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/b2/dd7d44429959d2d0802f2c9750ecfbb2.jpeg"">&#10;</var></a></div>
</div>
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>2021</span></div>
<div class=""sp-body""><a href=""https://fastpic.org/view/120/2022/0912/4d2aa7f5c59a03408e382e4c8e9054df.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/df/4d2aa7f5c59a03408e382e4c8e9054df.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/0cd63bcd2129ae93c5bd0e8f6731b548.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/48/0cd63bcd2129ae93c5bd0e8f6731b548.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/663aaf247d3bd95e99f4619c95509e21.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/21/663aaf247d3bd95e99f4619c95509e21.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/a47a9889c928d3a91d310c308651f110.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/10/a47a9889c928d3a91d310c308651f110.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/cccb93ef7856d7c940f251107a92bb29.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/29/cccb93ef7856d7c940f251107a92bb29.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/5ef91c723ba9ecc7731ab70314521ac2.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/c2/5ef91c723ba9ecc7731ab70314521ac2.jpeg"">&#10;</var></a></div>
</div>
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>2022</span></div>
<div class=""sp-body""><a href=""https://fastpic.org/view/120/2022/0912/417ba3a3550d391001e3e7df552edc23.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/23/417ba3a3550d391001e3e7df552edc23.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/4b3a10621107cec8044c6d1f2ef9360f.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/0f/4b3a10621107cec8044c6d1f2ef9360f.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/7a17f6fb9eff002ca208eb6f03ae1657.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/57/7a17f6fb9eff002ca208eb6f03ae1657.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/caf4d74f4e12023603ce1e3902f948a8.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/a8/caf4d74f4e12023603ce1e3902f948a8.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/120/2022/0912/6843377d922c41564a477aa4ce16aff8.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/0912/f8/6843377d922c41564a477aa4ce16aff8.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/120/2022/1029/1a12c76c8924e7c55911d6d5fe4cdb75.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/1029/75/1a12c76c8924e7c55911d6d5fe4cdb75.jpeg"">&#10;</var></a></div>
</div>
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>2023</span></div>
<div class=""sp-body""><a href=""https://fastpic.org/view/121/2022/1223/f235cff7ea03666d41bbd0e62425b593.png.html"" class=""postLink""><var class=""postImg"" title=""https://i121.fastpic.org/thumb/2022/1223/93/f235cff7ea03666d41bbd0e62425b593.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/121/2023/0227/40cb5e7663f8ba3e97484dd9c4e2387a.png.html"" class=""postLink""><var class=""postImg"" title=""https://i121.fastpic.org/thumb/2023/0227/7a/40cb5e7663f8ba3e97484dd9c4e2387a.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/122/2023/0628/55b76337d3d95e1667b9d843c453cb5b.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/0628/5b/55b76337d3d95e1667b9d843c453cb5b.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/122/2023/0628/521135c5b281ab33c14b0556a3d514c2.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/0628/c2/521135c5b281ab33c14b0556a3d514c2.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/122/2023/0817/258aea746ea59a2231cac627abc1b9a7.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/0817/a7/258aea746ea59a2231cac627abc1b9a7.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/122/2023/1021/97953658028f69012fa169b18f585e69.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/1021/69/97953658028f69012fa169b18f585e69.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/122/2023/1106/2482594322a2487d2309b29371b1ae52.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/1106/52/2482594322a2487d2309b29371b1ae52.jpeg"">&#10;</var></a></div>
</div>
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>2024</span></div>
<div class=""sp-body""><a href=""https://fastpic.org/view/122/2023/1223/f1a590331f06303a7a25d2c3361893b7.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/1223/b7/f1a590331f06303a7a25d2c3361893b7.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/123/2024/0225/7000fe01c921f43d44b2e34f30fc9268.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0225/68/7000fe01c921f43d44b2e34f30fc9268.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/123/2024/0421/9549058a020c3c1c52f42dd6a6f97db1.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0421/b1/9549058a020c3c1c52f42dd6a6f97db1.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/123/2024/0620/603179cd8cc5cc1b790644304fafabc6.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0620/c6/603179cd8cc5cc1b790644304fafabc6.jpeg"">&#10;</var></a><a href=""https://fastpic.org/view/123/2024/0818/7d4eeef2add9842fd810bde405e61bc9.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0818/c9/7d4eeef2add9842fd810bde405e61bc9.jpeg"">&#10;</var></a></div>
</div>
</div>
</div>
<div class=""sp-wrap"">
<div class=""sp-head folded""><span>Список номеров</span></div>
<div class=""sp-body"">2019 45-48<br>
2020 48-54<br>
2021 55-60<br>
2022 61-66<br>
2023 67-72, Fall se<br>
2024 73-77</div>
</div> <div class=""clear"">&nbsp;</div>
<span class=""post-align"" style=""text-align: center;""><span style=""font-size: 14px; line-height: normal;""><span style=""font-size: 14px; line-height: normal;""><a href=""viewtopic.php?t=3118460"" class=""postLink""><span class=""post-b""><img class=""smile"" src=""https://static.rutracker.cc/smiles/icon_arrow.gif"" alt> Набор в группу «Хранители» - Помогите сохранить редкие раздачи <img class=""smile"" src=""https://static.rutracker.cc/smiles/icon_arrow2.gif"" alt></span></a></span></span></span> </div>
<div class=""clear"" style=""height: 8px;""></div>
<table class=""attach bordered med"">
<tr class=""row3 tCenter"">
<td colspan=""3"" style=""padding: 3px 6px;"">
<ul class=""inlined middot-separated"">
<li><a href=""/go/1"" class=""med"" target=""_blank"">Как качать</a></li>
<li><a href=""http://rutracker.wiki"" class=""med"" target=""_blank"">FAQ</a></li>
<li><a href=""viewtopic.php?t=5403116"" class=""med"" target=""_blank"">Покраснели раздачи?</a></li>
<li><a href=""viewforum.php?f=1649"" class=""med"" target=""_blank"">VPN</a></li>
<li><a href=""viewtopic.php?t=6529617"" class=""med"" target=""_blank"">Как пополнить баланс Steam</a></li>
</ul>
</td>
</tr>
<tr class=""row1"">
<td style=""width: 15%;"">Зарегистрирован:</td>
<td style=""width: 70%; padding: 5px;"">
<ul class=""inlined middot-separated"">
<li>18-Авг-24 09:29</li>
<li>Скачан: 17 раз</li>
</ul>
</td>
<td rowspan=""4"" style=""width: 15%; padding: 10px 6px;"" class=""tCenter"">
<a href=""dl.php?t=6257950"" class=""dl-stub dl-link dl-topic"">
<img src=""https://static.rutracker.cc/templates/v1/images/attach_big.gif"" alt=""Скачать .torrent""><br>
Скачать .torrent
</a>
<p class=""small"">55&nbsp;KB</p>
<div style=""padding-top: 6px;"">
<input id=""tor-filelist-btn"" type=""button"" class=""lite"" style=""width: 120px;"" value=""Список файлов"">
</div>
</td>
</tr>
<tr class=""row1"">
<td>Тип:</td>
<td>
<span class>обычная</span>
</td>
</tr>
<tr class=""row1"">
<td>Статус:</td>
<td style>
<span id=""tor-status-resp"">
<span class=""tor-icon tor-approved"">&radic;</span> <a href=""viewtopic.php?t=211216#torstatus"" class=""med""><b>проверено</b></a>
</span>
</td>
</tr>
<tr class=""row1"">
<td>Размер:</td>
<td style=""padding: 2px 5px 5px;"">
<ul class=""inlined middot-separated"">
<li><span id=""tor-size-humn"" title=""1405477146"">1.31&nbsp;GB</span></li>
<li>
<a href=""magnet:?xt=urn:btih:822D44F7B91FAFEF35603C031D6D6C80F74829B7&tr=http%3A%2F%2Fbt4.t-ru.org%2Fann%3Fmagnet"" class=""med magnet-link"" data-topic_id=""6257950"" title=""822D44F7B91FAFEF35603C031D6D6C80F74829B7"">
<img src=""https://static.rutracker.cc/templates/v1/images/magnet_1.svg"" alt=""magnet"">Скачать по magnet-ссылке
</a>
</li>
</ul>
</td>
</tr>
<tr class=""row3 tCenter"">
<td colspan=""3"" style=""padding: 3px 6px;"">
&nbsp;
<a class=""internal-promo-text-link-1"" href=""go2.php?id=18&pl=6&var=1&txt=1"" rel=""nofollow"" target=""_blank"">Делаешь музыку и не знаешь, где её показать? Покажи на МЫ СЦЕНА!</a>
&nbsp;
</td>
</tr>
</table>
<script>
$(function () {
	var tor_filetree = new FileTree({
		container_id: 'tor-filelist',
		controls_id: 'tor-fl-controls',
		load_from: 'viewtorrent.php',
		post_data: { t: '6257950' },
		cat_id: '25',
	});

	$('#tor-filelist-btn').on('click', function () {
		if (tor_filetree.is_inited) {
			$('#tor-fl-wrap').toggle();
		}
		else {
			$('#tor-fl-wrap').show();
			tor_filetree.init();
		}
	});
		});
</script>
<table id=""cmp-result-tpl"" class=""cmp-tbl"" style=""display: none;"">
<caption class=""cmp-caption"">
Сравнение с раздачей:
<a href=""#"" class=""med bold cmp-topic"" style=""color: #8B0000;"" target=""_blank""></a>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_close.png"" class=""cmp-hide-btn"" alt>
</caption>
<thead>
<tr>
<th style=""width: 50%;"">эта раздача</th>
<th style=""width: 50%;"">сравниваемая</th>
</tr>
</thead>
<tbody class=""cmp-same"">
<tr>
<th colspan=""2"" class=""cmp-title"">
Совпадающие по размеру файлы<span class=""cmp-same-count"" style=""display: none;""> &middot; <b></b> шт.</span>
</th>
</tr>
<tr class=""cmp-same-none"" style=""display: none;"">
<td colspan=""2"">Нет совпадений</td>
</tr>
</tbody>
<tbody class=""cmp-diff"" style=""display: none;"">
<tr>
<th colspan=""2"" class=""cmp-title"">
Несовпадающие файлы<span class=""cmp-diff-count"" style=""display: none;""> &middot; <b></b> шт.</span>
</th>
</tr>
<tr>
<td class=""cmp-this-diff this-f"" style=""width: 50%;""></td>
<td class=""cmp-other-diff other-f"" style=""width: 50%;""></td>
</tr>
</tbody>
</table>
<div id=""tor-fl-wrap"">
<div id=""tor-fl-controls"" class=""med clearfix"">
<ul class=""inlined middot-separated a-like-items floatL"">
<li data-action=""collapse"" title=""Свернуть некорневые директории"">Свернуть</li>
<li data-action=""expand"">Развернуть</li>
<li data-action=""toggle"">Переключить</li>
</ul>
<ul class=""inlined middot-separated a-like-items floatR"">
<li data-action=""sort_by"" data-sort_type=""name_asc"">Имя &darr;</li>
<li data-action=""sort_by"" data-sort_type=""size_desc"">Размер &darr;</li>
<li data-action=""compare"">Сравнить с др. раздачей</li>
<li data-action=""toggle_win_size"">Увел./умен. окно</li>
</ul>
</div>
<div id=""cmp-results"" style=""display: none;""></div>
<div id=""tor-filelist"" class=""med ftree-windowed""><span class=""loading-1"">загружается...</span></div>
</div>
<script>
$(function () {
	function thx_is_visible() {
		return $('#thx-list').is(':visible');
	}

	function open_thx_list() {
		if (!thx_is_visible()) { $thx_head.click(); }
	}

	function close_thx_list() {
		if (thx_is_visible()) { $thx_head.click(); }
	}

	BB.thx_btn_clicked = false;

	ajax.thx = function (mode) {
		ajax.exec({
			action: 'thx',
			mode: mode,
			topic_id: '6257950',
			t_hash: 'f70afc39e7307a420c4ec69a78049ece',
		});
	};
	ajax.callback.thx = function (data) {
		if (data.mode === 'add') {
			$('#thx-btn').hide().after('<h2 style=""color: green;"">Спасибо за благодарность!</h2>');
			BB.thx_btn_clicked = true;
		}
		$('#thx-list').html(data.html);
		var $userElements = $('#thx-list b');
		$userElements.after(' ');
		open_thx_list();
		$userElements.each(function () {
			var uid = $(this).find('u').text();
			if (uid > 0) {
				$(this).wrap('<a href=""profile.php?mode=viewprofile&amp;u=' + uid + '""></a>');
			}
		});
	};
	$(function () {
		var $thx = $('#thx-block');
		BB.initSpoilers($thx);
		window.$thx_head = $thx.find('.sp-head');
		close_thx_list();
				$('#thx-btn').one('click', function () {
			$(this).prop({ disabled: true });
			ajax.thx('add');
		});
				$thx_head.one('click', function () {
			if (!BB.thx_btn_clicked) {
				ajax.thx('get');
			}
		});
	});
});
</script>
<style>
#thx-list a[href$='19487848'] b {
	color: #00f;
}
</style>
<div id=""thx-block"" class=""hide-for-print"">
<div id=""thx-btn-div"">
<input id=""thx-btn"" type=""button"" class=""bold"" style=""width: 200px;"" value=""Сказать &quot;Спасибо&quot;"">
</div>
<div class=""sp-wrap"">
<div class=""sp-head folded sp-no-auto-open""><span>Последние поблагодарившие</span></div>
<div id=""thx-list"" class=""sp-body""></div>
</div>
</div>
<div class=""spacer_12""></div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody>
<tr class=""row5"">
<td colspan=""2"" class=""td2 ext-links"" data-ext_link_data=""{&quot;p&quot;:1,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:1}"">

<style>
.bn-t-728x90 {
	padding: 10px;
	text-align: center;
	display: none;
}
.bn-t-iframe-728x90 {
	display: block;
	margin: 10px auto;
	width: 728px;
	height: 90px;
}
.bn-t-65x100 {
	display: block;
	margin: 0 auto;
	width: 65%;
	height: 100px;
}
</style>
<script>
$(function () {
	var minFrameWidth = Math.min($(window).width() - 50, 728);
	$('#bn-topic-iframe').css({
		'min-width': minFrameWidth + 'px',
	});
	var maxImgWidth = $(window).width() - 50;
	$('#bn-topic-block img').css({
		'max-width': maxImgWidth + 'px',
		'height': 'auto',
	});
	$('#bn-topic-block').show();
});
</script>
<div id=""bn-topic-block"" class=""bn-t-728x90""><a href=""https://atomicheart.vkplay.ru"" target=""_blank"" rel=""nofollow""><img src=""https://cdn.advg.agency/static/offer/1115/banners/106730/728x90.jpg"" style=""width: 728px; height: 90px;"" alt></a></div>
</td>
</tr>
</tbody>
<tbody id=""post_83829800"" class=""row2"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""83829800""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '83829800');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=83829800#83829800"">29-Окт-22 18:34</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 1 месяц 16 дней)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=83829800"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-2"">
<div class=""post_body"" id=""p-83829800"" data-ext_link_data=""{&quot;p&quot;:83829800,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/120/2022/1029/1a12c76c8924e7c55911d6d5fe4cdb75.png.html"" class=""postLink""><var class=""postImg"" title=""https://i120.fastpic.org/thumb/2022/1029/75/1a12c76c8924e7c55911d6d5fe4cdb75.jpeg"">&#10;</var></a> + 66 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_84072680"" class=""row1"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""84072680""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '84072680');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=84072680#84072680"">23-Дек-22 12:30</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 1 месяц 24 дня)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=84072680"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-3"">
<div class=""post_body"" id=""p-84072680"" data-ext_link_data=""{&quot;p&quot;:84072680,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/121/2022/1223/f235cff7ea03666d41bbd0e62425b593.png.html"" class=""postLink""><var class=""postImg"" title=""https://i121.fastpic.org/thumb/2022/1223/93/f235cff7ea03666d41bbd0e62425b593.jpeg"">&#10;</var></a> + 2023-01/02 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_84364198"" class=""row2"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""84364198""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '84364198');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=84364198#84364198"">27-Фев-23 18:36</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 2 месяца 4 дня)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=84364198"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-4"">
<div class=""post_body"" id=""p-84364198"" data-ext_link_data=""{&quot;p&quot;:84364198,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/121/2023/0227/40cb5e7663f8ba3e97484dd9c4e2387a.png.html"" class=""postLink""><var class=""postImg"" title=""https://i121.fastpic.org/thumb/2023/0227/7a/40cb5e7663f8ba3e97484dd9c4e2387a.jpeg"">&#10;</var></a> + 68 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_84891235"" class=""row1"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""84891235""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '84891235');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=84891235#84891235"">28-Июн-23 17:50</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 4 месяца)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=84891235"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-5"">
<div class=""post_body"" id=""p-84891235"" data-ext_link_data=""{&quot;p&quot;:84891235,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/122/2023/0628/55b76337d3d95e1667b9d843c453cb5b.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/0628/5b/55b76337d3d95e1667b9d843c453cb5b.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/122/2023/0628/521135c5b281ab33c14b0556a3d514c2.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/0628/c2/521135c5b281ab33c14b0556a3d514c2.jpeg"">&#10;</var></a> + 69, 70 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_85079846"" class=""row2"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""85079846""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '85079846');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=85079846#85079846"">17-Авг-23 19:04</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 1 месяц 19 дней)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=85079846"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-6"">
<div class=""post_body"" id=""p-85079846"" data-ext_link_data=""{&quot;p&quot;:85079846,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/122/2023/0817/258aea746ea59a2231cac627abc1b9a7.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/0817/a7/258aea746ea59a2231cac627abc1b9a7.jpeg"">&#10;</var></a> + 71 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_85352413"" class=""row1"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""85352413""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '85352413');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=85352413#85352413"">21-Окт-23 10:56</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 2 месяца 3 дня)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=85352413"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-7"">
<div class=""post_body"" id=""p-85352413"" data-ext_link_data=""{&quot;p&quot;:85352413,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/122/2023/1021/97953658028f69012fa169b18f585e69.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/1021/69/97953658028f69012fa169b18f585e69.jpeg"">&#10;</var></a> + 72 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_85431217"" class=""row2"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""85431217""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '85431217');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=85431217#85431217"">06-Ноя-23 13:09</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 16 дней)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=85431217"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-8"">
<div class=""post_body"" id=""p-85431217"" data-ext_link_data=""{&quot;p&quot;:85431217,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/122/2023/1106/2482594322a2487d2309b29371b1ae52.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/1106/52/2482594322a2487d2309b29371b1ae52.jpeg"">&#10;</var></a> + 2023Fall se </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_85640858"" class=""row1"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""85640858""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '85640858');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=85640858#85640858"">23-Дек-23 18:55</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 1 месяц 17 дней)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=85640858"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-9"">
<div class=""post_body"" id=""p-85640858"" data-ext_link_data=""{&quot;p&quot;:85640858,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/122/2023/1223/f1a590331f06303a7a25d2c3361893b7.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/1223/b7/f1a590331f06303a7a25d2c3361893b7.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/122/2023/1223/27278f8147b6966000eda28b7230ff58.png.html"" class=""postLink""><var class=""postImg"" title=""https://i122.fastpic.org/thumb/2023/1223/58/27278f8147b6966000eda28b7230ff58.jpeg"">&#10;</var></a> + 2024-01/02 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_85931138"" class=""row2"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""85931138""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '85931138');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=85931138#85931138"">25-Фев-24 17:58</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 2 месяца 1 день, ред. 25-Фев-24 17:58)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=85931138"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-10"">
<div class=""post_body"" id=""p-85931138"" data-ext_link_data=""{&quot;p&quot;:85931138,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/123/2024/0225/7000fe01c921f43d44b2e34f30fc9268.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0225/68/7000fe01c921f43d44b2e34f30fc9268.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/123/2024/0225/a619e0cf4c3750b065123842dd8e1e47.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0225/47/a619e0cf4c3750b065123842dd8e1e47.jpeg"">&#10;</var></a> + 2024-03/04 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_86166243"" class=""row1"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""86166243""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '86166243');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=86166243#86166243"">21-Апр-24 09:17</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 1 месяц 24 дня)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=86166243"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-11"">
<div class=""post_body"" id=""p-86166243"" data-ext_link_data=""{&quot;p&quot;:86166243,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/123/2024/0421/9549058a020c3c1c52f42dd6a6f97db1.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0421/b1/9549058a020c3c1c52f42dd6a6f97db1.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/123/2024/0421/19185064684c53624c8c40ace2f1b660.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0421/60/19185064684c53624c8c40ace2f1b660.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/123/2024/0421/7955f594cac36d22694e5bce6f4a422e.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0421/2e/7955f594cac36d22694e5bce6f4a422e.jpeg"">&#10;</var></a> + 75 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_86395388"" class=""row2"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""86395388""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '86395388');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=86395388#86395388"">20-Июн-24 18:02</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 1 месяц 29 дней)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=86395388"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-12"">
<div class=""post_body"" id=""p-86395388"" data-ext_link_data=""{&quot;p&quot;:86395388,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/123/2024/0620/603179cd8cc5cc1b790644304fafabc6.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0620/c6/603179cd8cc5cc1b790644304fafabc6.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/123/2024/0620/a0f51114f9e1c9e07fff03e252ad756a.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0620/6a/a0f51114f9e1c9e07fff03e252ad756a.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/123/2024/0620/1d1b7fd4212bff5b3f48117abacf66e0.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0620/e0/1d1b7fd4212bff5b3f48117abacf66e0.jpeg"">&#10;</var></a> + 76 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
<tbody id=""post_86600562"" class=""row1"">
<tr>
<td class=""poster_info td1 hide-for-print"">
<a id=""86600562""></a>
<p class=""nick nick-author"" title=""Вставить выделенный кусок сообщения"" onclick=""bbcode.onclickPoster('shtirts', '86600562');"">
<a href=""#"" onclick=""return false;"">shtirts</a>
</p>
<p class=""rank_img""><img class=""user-rank"" src=""https://static.rutracker.cc/ranks/s_topseed_3.gif"" alt=""Top Seed 03* 160r""></p> <p class=""avatar""><img src=""https://static.rutracker.cc/avatars/1/32/9514032.png"" alt></p> <p class=""joined""><em>Стаж:</em> 15 лет 4 месяца</p> <p class=""posts""><em>Сообщений:</em> 4828</p> <p class=""flag""><img src=""https://static.rutracker.cc/flags/143.gif"" class=""poster-flag"" alt=""flag"" title=""Россия""></p>
</td>
<td class=""message td2"" rowspan=""2"">
<div class=""post_head"">
<p class=""post-time"">
<span class=""hl-scrolled-to-wrap"">
<span class=""show-for-print bold"">shtirts &middot; </span>
<img src=""https://static.rutracker.cc/templates/v1/images/icon_minipost_new.gif"" class=""icon1 hide-for-print"" alt>
<a class=""p-link small"" href=""viewtopic.php?p=86600562#86600562"">18-Авг-24 09:30</a>
</span>
<span class=""posted_since hide-for-print"">(спустя 1 месяц 27 дней)</span>
</p>
<ul class=""inlined t-post-buttons hide-for-print"" style=""float: right; padding: 3px 2px 4px;"">
<li><a class=""txtb"" href=""posting.php?mode=quote&amp;p=86600562"">[Цитировать]</a></li>
</ul>
<div class=""clear""></div>
</div>
<div class=""post_wrap"" id=""p-58484409-13"">
<div class=""post_body"" id=""p-86600562"" data-ext_link_data=""{&quot;p&quot;:86600562,&quot;t&quot;:6257950,&quot;f&quot;:1412,&quot;u&quot;:9514032}"">
<a href=""https://fastpic.org/view/123/2024/0818/7d4eeef2add9842fd810bde405e61bc9.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0818/c9/7d4eeef2add9842fd810bde405e61bc9.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/123/2024/0818/44d258d32b4dfe4b25d90536d586c9a6.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0818/a6/44d258d32b4dfe4b25d90536d586c9a6.jpeg"">&#10;</var></a> <a href=""https://fastpic.org/view/123/2024/0818/992af9a8226961cf4e4071349d948813.jpeg.html"" class=""postLink""><var class=""postImg"" title=""https://i123.fastpic.org/thumb/2024/0818/13/992af9a8226961cf4e4071349d948813.jpeg"">&#10;</var></a> + 77 </div>
<div class=""signature hide-for-print"">
<div class=""sig-body""><a href=""tracker.php?rid=9514032"" class=""postLink""><var class=""postImg"" title=""http://i26.fastpic.ru/big/2011/0708/d3/f049c00165c44c03373d734e60f3a5d3.png"">&#10;</var></a><var class=""postImg"" title=""https://static.rutracker.cc/ranks/oldbie.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_toploader_2.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/s_topbonus_5.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books.gif"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_pressa.png"">&#10;</var><var class=""postImg"" title=""http://static.rutracker.cc/ranks/rg_torrents_books/rg_torrents_books_2.png"">&#10;</var></div>
</div>
</div>
</td>
</tr>
<tr>
<td class=""poster_btn td3 hide-for-print"">
<div style=""padding: 2px 6px 4px;"" class=""post_btn_2"">
<a class=""txtb"" href=""profile.php?mode=viewprofile&amp;u=9514032"">[Профиль]</a>&nbsp;
<a class=""txtb"" href=""privmsg.php?mode=post&amp;u=9514032"">[ЛС]</a>&nbsp;
</div>
</td>
</tr>
</tbody>
</table>
<form id=""post-msg-form"" method=""post"" action=""posting.php?mode=reply&amp;t=6257950"" name=""post"" class=""tokenized"">
<input type=""hidden"" name=""mode"" value=""reply"">
<input type=""hidden"" name=""t"" value=""6257950"">
<table class=""topic w100 hide-for-print"">
<tr>
<th class=""thHead"">Быстрый ответ</th>
</tr>
<tr>
<td class=""row2 quick-reply"">
<script>
ajax.bbcode2html = function (text, preview_box_id) {
	ajax.exec({
		action: 'bbcode2html',
		text: text,
		resultElementId: preview_box_id,
	});
};
ajax.callback.bbcode2html = function (data) {
	var $preview = $('#' + data.resultElementId);
	var $editor = $('#ped-editor');
	var editor_height = Math.max(100, $editor.outerHeight(true));
	var win_height = $(window).height();
	var max_prev_height = Math.max(290, win_height - editor_height - 8);
	$preview.html(data.html).show();
	BB.initPost('#' + data.resultElementId);
	if (BB.hasET()) {
		ET.initPoster($preview);
	}
	if ($preview[0].scrollHeight >= max_prev_height) {
		$preview.css({ 'height': Math.round(max_prev_height) + 'px' });
	} else {
		$preview.css({ 'height': 'auto' });
	}
	var preview_rect = $preview[0].getBoundingClientRect();
	var editor_rect = $editor[0].getBoundingClientRect();
	if (preview_rect.top < 0 || editor_rect.bottom > win_height) {
		var offset = (BB.hasET()) ? -28 : -6;
		$.scrollTo($preview, { offset: offset });
	}
};
$(function () {
	$('#p-quick-preview-btn').on('click', function () {
		ajax.bbcode2html($('#post-textarea').val().to1251(), 'p-quick-preview-box');
	});
});
</script>
<div id=""p-quick-preview-box"" class=""p-quick-preview-box post_body wbr row1 clearfix"" style=""display: none;""></div>
<div id=""ped-editor"" class=""ped-editor input-buttons"">
<div id=""ped-editor-buttons"" class=""ped-editor-buttons"">
<div class=""ped-buttons-row"">
<select name=""fontFace"">
<option value=""-1"" selected=""selected"">Шрифт:</option>
<option class=""post-font-serif1 em"" value=""serif1"">Georgia</option>
<option class=""post-font-serif2"" value=""serif2"">&nbsp;Palatino</option>
<option class=""post-font-sans1 em"" value=""sans1"">Arial</option>
<option class=""post-font-sans2"" value=""sans2"">&nbsp;Trebuchet MS</option>
<option class=""post-font-sans3"" value=""sans3"">&nbsp;Segoe UI</option>
<option class=""post-font-mono1 em"" value=""mono1"">Monospaced</option>
<option class=""post-font-mono2"" value=""mono2"">&nbsp;Consolas</option>
<option class=""post-font-cursive1 em"" value=""cursive1"">Comic Sans MS</option>
<option class=""post-font-impact"" value=""impact"">Impact</option>
</select>
<select name=""codeColor"" class=""text_color"">
<option style=""color: black; background: #fff;"" value=""black"" selected=""selected"">Цвет шрифта:</option>
<option style=""color: darkred;"" value=""darkred"">&nbsp;Тёмно-красный</option>
<option style=""color: brown;"" value=""brown"">&nbsp;Коричневый</option>
<option style=""color: #996600;"" value=""#996600"">&nbsp;Оранжевый</option>
<option style=""color: red;"" value=""red"">&nbsp;Красный</option>
<option style=""color: #993399;"" value=""#993399"">&nbsp;Фиолетовый</option>
<option style=""color: green;"" value=""green"">&nbsp;Зелёный</option>
<option style=""color: darkgreen;"" value=""darkgreen"">&nbsp;Тёмно-Зелёный</option>
<option style=""color: gray;"" value=""gray"">&nbsp;Серый</option>
<option style=""color: olive;"" value=""olive"">&nbsp;Оливковый</option>
<option style=""color: blue;"" value=""blue"">&nbsp;Синий</option>
<option style=""color: darkblue;"" value=""darkblue"">&nbsp;Тёмно-синий</option>
<option style=""color: indigo;"" value=""indigo"">&nbsp;Индиго</option>
<option style=""color: #006699;"" value=""#006699"">&nbsp;Тёмно-Голубой</option>
</select>
<select name=""codeSize"" class=""text_size"">
<option value=""12"" selected=""selected"">Размер:</option>
<option value=""10"" class=""em"">Маленький</option>
<option value=""11"">&nbsp;size=11</option>
<option value=""12"" class=""em"" disabled=""disabled"">Обычный</option>
<option value=""14"">&nbsp;size=14</option>
<option value=""16"">&nbsp;size=16</option>
<option value=""18"" class=""em"">Большой</option>
<option value=""20"">&nbsp;size=20</option>
<option value=""22"">&nbsp;size=22</option>
<option value=""24"" class=""em"">Огромный</option>
</select>
<select name=""align"">
<option value=""-1"" selected=""selected"">Выравнивание:&nbsp;</option>
<option value=""left"">По левому краю</option>
<option value=""right"">По правому краю</option>
<option value=""center"">По центру</option>
<option value=""justify"">По ширине</option>
</select>
<select name=""imgOpt"">
<option value=""-1"" selected=""selected"">Картинка:&nbsp;</option>
<option value=""left"">Слева</option>
<option value=""right"">Справа</option>
<option value=""10"">10% экрана</option>
<option value=""15"">15%</option>
<option value=""20"">20%</option>
<option value=""25"">25%</option>
<option value=""30"">30%</option>
<option value=""40"">40%</option>
<option value=""50"">50%</option>
<option value=""60"">60%</option>
<option value=""1em"">По высоте строки</option>
</select>
<input type=""button"" value=""&para;"" name=""codeBR"" title=""Новая строка"" style=""width: 30px;"">
<input type=""button"" value=""&#8667;"" name=""codeIndent"" title=""Отступ"" style=""width: 30px;"">
<input type=""button"" value=""pre"" name=""codePre"" title=""Форматированный текст"" style=""width: 40px;"">
<input type=""button"" value=""box"" name=""codeBox"" title=""Рамка"" style=""width: 40px;"">
<input type=""button"" value=""nfo"" name=""codeNfo"" title=""NFO"" style=""width: 40px;"">
<input type=""button"" value=""1-L"" name=""codeOneLine"" title=""В одну строку"" style=""width: 30px;"">
</div>
<div class=""ped-buttons-row"">
<input type=""button"" value="" B "" name=""codeB"" title=""Жирный (Ctrl+B)"" style=""font-weight: bold; width: 30px;"">
<input type=""button"" value="" i "" name=""codeI"" title=""Курсив (Ctrl+I)"" style=""width: 30px; font-style: italic;"">
<input type=""button"" value="" u "" name=""codeU"" title=""Подчеркнутый (Ctrl+U)"" style=""width: 30px; text-decoration: underline;"">
<input type=""button"" value="" S "" name=""codeS"" title=""Перечеркнутый"" style=""width: 30px; text-decoration: line-through;"">
&nbsp;
<input type=""button"" value=""Цитата"" name=""codeQuote"" title=""Цитата (Ctrl+Q)"" style=""width: 70px;"">
<input type=""button"" value=""Картинка"" name=""codeImg"" title=""Картинка (Ctrl+R)"" style=""width: 70px;"">
<input type=""button"" value=""Ссылка"" name=""codeUrl"" title=""Ссылка (Ctrl+Y) Пример: [url=http://...]текст[/url]"" style=""width: 70px;""><input type=""hidden"" name=""codeUrl2"">
&nbsp;
<input type=""button"" value=""Список"" name=""codeList"" title=""Список (Ctrl+L)"" style=""width: 70px;"">
<input type=""button"" value=""1."" name=""codeOpt"" title=""Элемент списка (Ctrl+0)"" style=""width: 30px;"">
&nbsp;
<input type=""button"" value=""&#8212;"" name=""codeHR"" title=""Горизонтальная линия (Ctrl+8)"" style=""font-weight: bold; width: 30px;"">
<input type=""button"" value=""Код"" name=""codeCode"" title=""Код (Ctrl+K)"" style=""width: 60px;"">
<input type=""button"" value=""Спойлер"" name=""codeSpoiler"" title=""Спойлер (Ctrl+S)"" style=""width: 80px;"">
<input type=""button"" value=""Цитир. выделен."" name=""quoteselected"" title=""Цитировать выделенный текст"" style=""width: 120px;"" onclick=""bbcode.onclickQuoteSel();"">
&nbsp;
<input type=""button"" value=""x"" title=""Очистить окно ввода"" style=""width: 25px;"" onclick=""$('#post-textarea').val('').focus();"">
</div>
</div>
<div>
<textarea id=""post-textarea"" class=""editor"" name=""message"" rows=""12"" cols=""92""></textarea>
</div>
<div id=""ped-submit-buttons"" class=""ped-buttons-row ped-submit-buttons"" style=""display: none;"">
<input id=""submit-mode"" name=""submit_mode"" type=""hidden"" value>
<input id=""load-pic-btn"" type=""button"" value=""Загрузить картинку"" onclick=""window.open('http://fastpic.org', '_blank');"">
<input id=""p-ext-preview-btn"" type=""button"" title=""Расширенное редактирование"" value=""Расшир. редактир."">
<input id=""p-quick-preview-btn"" type=""button"" title=""Shift+Enter"" value=""Предв. просмотр"" accesskey=""p"">
<input id=""post-submit-btn"" type=""button"" title=""Ctrl+Enter"" class=""bold"" value=""Отправить"" accesskey=""s"">
</div>
<div id=""post-js-warn"">Для отправки сообщений необходимo включить JavaScript</div>
</div>
<script>
window.bbcode = new BBCode(document.post.message);
//@formatter:off
bbcode.addTag('codeB', 'b', null, 'B');
bbcode.addTag('codeI', 'i', null, 'I');
bbcode.addTag('codeU', 'u', null, 'U');
bbcode.addTag('codeS', 's', null, '');

bbcode.addTag('codeQuote', 'quote', null,   'Q', true);
bbcode.addTag('codeImg',   'img',   null,   'R');
bbcode.addTag('codeUrl',   'url=',  '/url', 'Y');
bbcode.addTag('codeUrl2',  'url=',  '/url', 'W');

bbcode.addTag('codeHR',      'hr',      '',   '8');
bbcode.addTag('codeList',    'list',    null, 'L', true);
bbcode.addTag('codeSpoiler', 'spoiler', null, 'S', true);
bbcode.addTag('codeCode',    'code',    null, 'K', true);
bbcode.addTag('codeOneLine', 'oneline', null, '', true);

bbcode.addTag('codeBR',    'br',         '',     '');
bbcode.addTag('codePre',   'pre',        null,   '', true);
bbcode.addTag('codeNfo',   'nfo',        null,   '', true);
bbcode.addTag('codeIndent','indent',     null,   '', true);
bbcode.addTag('codeBox',   'box',        null,   '');

bbcode.addTag('fontFace',  function(e) { var v=e.value; e.selectedIndex=0; return 'font='+v; }, '/font');
bbcode.addTag('codeColor', function(e) { var v=e.value; e.selectedIndex=0; return 'color='+v; }, '/color');
bbcode.addTag('codeSize',  function(e) { var v=e.value; e.selectedIndex=0; return 'size='+v; }, '/size');
bbcode.addTag('align',     function(e) { var v=e.value; e.selectedIndex=0; return 'align='+v; }, '/align');
bbcode.addTag('imgOpt',    function(e) { var v=e.value; e.selectedIndex=0; return 'img='+v; }, '/img');
//@formatter:on
bbcode.addTag('codeOpt', '*', '', '0', function (text) {
	return text.split(/\r?\n/).map(function (str, i) {
		return !i ? str : '[*]' + str;
	}).join('\n');
});

$(function () {
	$('#post-msg-form').on('submit', function () {
		var inQuickReply = $('.quick-reply').length;
		if (!$('#submit-mode').val()) {
			return false;
		}
		if ($('#post-textarea').val().trim().length < 2) {
			if (!inQuickReply) {
				return bb_alert('Вы должны ввести текст сообщения');
			}
		}
		if ($('#post-msg-subj').length && $('#post-msg-subj').val().trim().length < 2) {
			return bb_alert('Вы должны указать заголовок');
		}
				$('#post-submit-btn').prop({ disabled: true });
	});
	$('#post-submit-btn').on('click', function (e) {
		return submit_post(e);
	});
	$('#p-ext-preview-btn').on('click', function (e) {
		return preview_post(e);
	});
	$('#post-textarea').on('keypress', function (e) {
		if (e.which == 10 || e.which == 13 /* Enter */) {
			if (e.shiftKey) {
				e.preventDefault();
								$('#p-quick-preview-btn').click();
							} else if (e.ctrlKey) {
				submit_post(e);
			}
		}
	});
	$('#post-js-warn').hide();
	$('#ped-submit-buttons').show();
	$('#post-submit-btn').prop({ disabled: false });
});

function submit_post(e) {
		$('#submit-mode').val('submit');
	$('#post-msg-form').submit();
}

function preview_post() {
	$('#submit-mode').val('preview');
	$('#post-msg-form').submit();
}
</script>
</td>
</tr>
</table>
</form>
<table class=""topic hide-for-print"">
<tr>
<td class=""catBottom med"">
&nbsp;
</td>
</tr>
</table>
<table class=""w100 hide-for-print"" style=""padding-top: 2px;"">
<tr>
<td class=""vTop"">
<a href=""posting.php?mode=reply&amp;t=6257950""><img src=""https://static.rutracker.cc/templates/v1/images/reply.gif"" alt=""Ответить""></a>
</td>
<td class=""nav w100"" style=""padding-left: 8px;"">
<a href=""index.php"">Главная</a>
<em>&raquo;</em> <a href=""index.php?c=25"">Книги и журналы</a>
<em>&raquo;</em> <a href=""viewforum.php?f=2033"">Коллекционирование, увлечения и хобби</a>
<em>&raquo;</em> <a href=""viewforum.php?f=1412"">Коллекционирование и вспомогательные ист. дисциплины</a>
</td>
</tr>
</table>
<div class=""bottom_info hide-for-print"">
<div class=""tRight"">
<span id=""jumpbox-wrap""></span>
</div>
<table class=""w100"">
<tr>
<td class=""tRight med vTop"">
</td>
</tr>
</table>
</div>
</div>
</td>
</tr>
</table>
</div>

<div id=""page_footer"" class=""hide-for-print"">
<script>
$(function () {
	//var imgMaxWidth = $(window).width() - 50;
	//$('#bn-page-bottom-block img').css({
	//	'max-width': imgMaxWidth + 'px',
	//	'height': 'auto',
	//	'max-height': '160px',
	//});
});
</script>
<div class=""ext-links"" style=""padding: 6px; text-align:center;""><a href=""https://r.advg.agency/t/zrd3f/"" target=""_blank"" rel=""nofollow""><img src=""https://rutrk.org/728x90/ref/Crossout_1.jpg"" style=""width: 728px; height: auto;"" alt></a></div>
<div class=""clear""></div>
<nav id=""footer-info-links"">
<div>
<a href=""info.php?show=user_agreement"" rel=""nofollow"">Условия использования</a>
&middot;
<a href=""info.php?show=advert"" rel=""nofollow"">Реклама на сайте</a>
&middot;
<a href=""info.php?show=copyright_holders"" rel=""nofollow"">Для правообладателей</a>
&middot;
<a href=""info.php?show=press"" rel=""nofollow"">Для прессы</a>
&middot;
<a href=""viewtopic.php?t=2234744"">Для провайдеров</a>


&middot;
<a href=""http://rutracker.wiki"">Торрентопедия</a>
</div>
<div>
<a href=""viewtopic.php?t=1045""><b>Правила</b></a>
&middot;
<a href=""/go/8"" rel=""nofollow"">Кому задать вопрос</a>
&middot;
<a href=""viewforum.php?f=1538"">Авторские раздачи</a>
&middot;
<a href=""viewforum.php?f=1289"">Конкурсы</a>
&middot;
<a href=""viewforum.php?f=2332"">Новости &quot;Хранителей&quot; и &quot;Антикваров&quot;</a>
&middot;
<a href=""#"" onclick=""return post2url('index.php', {rand_rel: 1});"" rel=""nofollow"">Случайная раздача</a>
</div>
</nav>
<div class=""tCenter nowrap"" style=""margin: 18px 4px 4px 4px;"">
</div>
<div class=""footer-bottom-links"">
<ul class=""inlined middot-separated"">
<li><a href=""groupcp.php?g=104792"" rel=""nofollow"" target=""_blank"">Администрация</a></li>
<li><a href=""groupcp.php?g=104787"" rel=""nofollow"" target=""_blank"">Модераторы</a></li>
<li><a href=""groupcp.php?g=104841"" rel=""nofollow"" target=""_blank"">Тех. помощь</a></li>
<li><a href=""https://t.me/rutracker_news"" rel=""nofollow"" target=""_blank"">Telegram-канал</a></li>
</ul>
<div class=""wide"">
<script>
					$(function () {
						var title = """";
						var src = ""https://counter.yadro.ru/hit?t44.1;r"" + encodeURIComponent(document.referrer) +
							((typeof (screen) == ""undefined"") ? """" : "";s"" + screen.width + ""*"" + screen.height + ""*"" + (screen.colorDepth ? screen.colorDepth : screen.pixelDepth)) +
							"";u"" + encodeURIComponent(document.URL) + "";h"" + encodeURIComponent(title.substring(0, 80)) + "";"" + Math.random();
						$('<img src=""' + src + '"" alt="""">').on('load', function () {
							$('#liveinternet').append(this);
						});
					});
					</script>
<a id=""liveinternet"" href=""https://www.liveinternet.ru/stat/rutracker.org/index.html?lang=ru"" target=""_blank""></a>
</div>
<ul class=""inlined middot-separated"">
</ul>
</div>
</div>
</div>
<div id=""ajax-loading""><b>Loading...</b></div>
<div id=""ajax-error""><b>Error</b></div>
<style>
#bb-alert-box {
	width: auto;
	max-width: 800px;
	line-height: 18px;
	display: none;
}
#bb-alert-msg {
	min-width: 400px;
	max-height: 400px;
	margin: 50px 20px;
	padding: 10px;
	overflow: auto;
	text-align: center;
}
.bb-alert-err {
	color: #7E0000;
	background: #FFEEEE;
	box-shadow: 0 0 20px #B85353;
	font-weight: bold;
}
</style>
<div id=""bb-alert-box"">
<div id=""bb-alert-msg""></div>
</div>
<div id=""modal-blocker""></div>
<script>
$(function () {
	if (!BB.hasET() && BB.getUrlParam('view') !== 'print') {
		BB.navbar.init();
	}
});
</script>
<div id=""nav-panel"" class=""nav-hidden-arrow hide-for-print"">
<div id=""nav-up"" class=""nav-btn"" title=""Вверх"">
<span class=""nav-icon""></span>
</div>
<div id=""nav-settings"" class=""nav-btn"">
<span class=""nav-icon"" title=""Настройки""></span>
<ul id=""nav-opt-menu"">
<li class=""nav-event"" data-event=""click"">Показывать по клику</li>
<li class=""nav-event"" data-event=""mouseenter"">Показывать по наведению</li>
</ul>
</div>
<div id=""nav-down"" class=""nav-btn"" title=""Вниз"">
<span class=""nav-icon""></span>
</div>
<div class=""nav-hidden-overlay""></div>
</div>
</div>
<script defer src=""https://static.cloudflareinsights.com/beacon.min.js/vcd15cbe7772f49c399c6a5babf22c1241717689176015"" integrity=""sha512-ZpsOmlRQV6y907TI0dKBHq9Md29nnaEIPlkf84rnaERnq6zvWvPUqr2ft8M1aS28oN72PdrCzSjY4U6VaAw1EQ=="" data-cf-beacon='{""rayId"":""8b6887f18cdfbeba"",""version"":""2024.8.0"",""r"":1,""token"":""644a095bdbc6472da3072c1512cdb737"",""serverTiming"":{""name"":{""cfL4"":true}}}' crossorigin=""anonymous""></script>
</body>
</html>";
}