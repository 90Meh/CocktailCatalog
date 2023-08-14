using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Xml;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace CocktailCatalog.Telegram
{
    internal class MyTelegramBot
    {

        public static async void StartTelegramBot()
        {
           var botClient = new TelegramBotClient(SuppotrMhetods.GetMyTToken());

            using CancellationTokenSource cts = new();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            var service = new TelegramBotService(botClient);

            botClient.StartReceiving(
                updateHandler: service.HandleUpdateAsync,
                pollingErrorHandler: service.HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot            
            cts.Cancel();

        }
    }
}
