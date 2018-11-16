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

            bot.StartReceiving();
        }

        private void Bot_OnInlineQuery(object sender, InlineQueryEventArgs e)
        {
            List<InlineQueryResultBase> inlineQueryResults = new List<InlineQueryResultBase>();

            if (e.InlineQuery.Query != string.Empty)
            {
                List<TolokaResult> tolokaResults = Searcher.search(e.InlineQuery.Query);
                List<InlineQueryResultBase> inlineResults = new List<InlineQueryResultBase>();

                if (tolokaResults.Count > 0)
                {
                    foreach (var result in tolokaResults)
                    {
                        var inputContent = new InputTextMessageContent(result.ToString());
                        var article = new InlineQueryResultArticle(tolokaResults.IndexOf(result).ToString(), result.title, inputContent)
                        {
                            Description = $"{result.seeders}/{result.leechers}/{result.complete} ({result.size})"
                        };

                        inlineResults.Add(article);
                    }
                }

                else
                {
                    var inputContent = new InputTextMessageContent($"No results found for {e.InlineQuery.Query}.");
                    var article = new InlineQueryResultArticle("1", "Not found", inputContent)
                    {
                        Description = $"Nothing found by {e.InlineQuery.Query}"
                    };

                    inlineResults.Add(article);
                }

                bot.AnswerInlineQueryAsync(e.InlineQuery.Id, inlineResults);
            }
        }
    }
}
