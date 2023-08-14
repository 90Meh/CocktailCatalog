using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace CocktailCatalog.Telegram
{
    internal class BotTest
    {
        public static async Task BotStart(string tokenBot)
        {
            var bot = new TelegramBotClient(tokenBot);
            bot.StartReceiving((
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions: new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>()},
                cancellationToken: cts.Token
            );


        }

        private static Task HandleUpdateAsync(ITelegramBotClient bot, UpdateType update, CancellationToken cts)
        {
            throw new NotImplementedException();
        }

        private static Task HandleErrorAsync(ITelegramBotClient bot, UpdateType update, CancellationToken cts)
        {
            throw new NotImplementedException();
        }
    }
}
