using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InlineQueryResults;
using TolokaSearcher.Toloka;

namespace TolokaSearcher.Telegram
{
    public class Bot
    {
        private TelegramBotClient bot;

        public Bot()
        {
            bot = new TelegramBotClient(Config.Token);

            bot.OnInlineQuery += Bot_OnInlineQuery;
        }

        private void Bot_OnInlineQuery(object sender, InlineQueryEventArgs e)
        {
            List<InlineQueryResultBase> inlineQueryResults = new List<InlineQueryResultBase>();

            if (e.InlineQuery.Query != string.Empty)
            {
                List<TolokaResult> tolokaResults = Searcher.search(e.InlineQuery.Query);

                foreach (var tr in tolokaResults)
                {
                    var inputContent = new InputTextMessageContent(tr.ToString());
                    var article = new InlineQueryResultArticle(tolokaResults.IndexOf(tr).ToString(), tr.title, inputContent);

                    inlineQueryResults.Add(article);
                }
            }

            else
            {
                var inputContent = new InputTextMessageContent("Enter a query to search Toloka.to");
                var article = new InlineQueryResultArticle("1", "Search", inputContent);

                inlineQueryResults.Add(article);
            }

            bot.AnswerInlineQueryAsync(e.InlineQuery.Id, inlineQueryResults);
        }
    }
}
