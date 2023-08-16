
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace CocktailCatalog.Telegram
{
    internal class MyTelegramBot
    {

        //Метод вызова и создания бота
        public static async Task BotStart(string tokenBot)
        {
            using var cts = new CancellationTokenSource();

            var bot = new TelegramBotClient(tokenBot);

            var me = await bot.GetMeAsync();

            Console.Title = me.Username ?? "My awesome Bot";
            Console.WriteLine($"My bot: {me.Username}");

            bot.StartReceiving(updateHandler: HandleUpdateAsync,
                   pollingErrorHandler: HandleErrorAsync,
                   receiverOptions: new ReceiverOptions()
                   {
                       AllowedUpdates = Array.Empty<UpdateType>()
                   },
                   cancellationToken: cts.Token);

            Console.WriteLine($"Start listening for @{me.Username}");           

            Console.ReadLine();

            cts.Cancel();


        }

        //Позволяет принимать сообщения
        private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cts)
        {
            try
            {                
                switch (update.Type)
                {
                    case UpdateType.Message:
                        await BotOnMessageReceived(bot, update.Message!);
                        break;
                }
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(bot, exception, cts);
            }

        }

        //Обработка принятых сообщений
        private static async Task BotOnMessageReceived(ITelegramBotClient botClient, Message message)
        {
            Console.WriteLine($"Receive message type: {message.Type}");
           

            if (message.Type != MessageType.Text)
                return;

            var action = message.Text!.Split(' ')[0];
            switch (action)
            {
                case "/start":
                    await StartMessage(botClient, message);
                    break;
                case "/startgame":
                    await StartGame(botClient, message);
                    break; 
                default:
                    await Echo(botClient, message);
                    break;
            }

        }

        private static async Task StartGame(ITelegramBotClient botClient, Message message)
        {
            var game = new QuizGame(botClient, message.Chat);
            await game.StartAsync();
           
        }

        //Отправка сообщений
        private static async Task StartMessage(ITelegramBotClient botClient, Message message)
        {
            var userName = $"{message.From.LastName} {message.From.FirstName}";
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Hello {userName}");
        }
        //"Эхо" бот. Отвечает повтором
         private static async Task Echo(ITelegramBotClient botClient, Message message)
        {
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"{message.Text}");
        }

        //Обработка ошибок
        private static Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cts)
        {
            var ErrorMessage = exception.ToString();

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;

        }
    }
}
