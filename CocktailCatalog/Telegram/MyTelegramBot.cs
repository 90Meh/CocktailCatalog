
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using LinqToDB.Data;
using LinqToDB;

namespace CocktailCatalog.Telegram
{
    internal class MyTelegramBot
    {
        //Enum хранят состояния
        private static State state = State.start;
        private static StateAdd stateAdd = StateAdd.id;

        static DataConnection db = new LinqToDB.Data.DataConnection(ProviderName.PostgreSQL, Config.SqlConnectionString);

        //Переменные для методов
        private static uint id = 0;
        private static string nameAdd = string.Empty;
        private static string decriptionAdd = string.Empty;
        private static string compoundAdd = string.Empty;
        private static string volAdd = string.Empty;
        private static string changeName = string.Empty;

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

            var action = message.Text!.Split(' ')[0].ToLower();


            //Основное меню
            if (state == State.start)
            {
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"\"XXXX Добавить коктейль /Add XXXX " +
              $"Найти Коктейль /Search" +
              $"\"XXXX Изменить коктейль /Change XXXXX \" +\r\n" +
              $"\"\\n XXXXX  Показать все коктейли /All XXXX\"  Вернуться в начало /Start");
                switch (action)
                {
                    case "/add":
                        state = State.add;
                        await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Вы хотите создать коктейль?:)");
                        break;
                    case "/search":
                        state = State.search;
                        await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите имя коктейля");
                        break;
                    case "/change":
                        state = State.change;
                        await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите имя коктейля для изменения");
                        break;
                    case "/all":
                        var cocktailAll = MethodMMenu.AllCocktail();
                        foreach (var item in cocktailAll)
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"{item.Id} {item.Name}, {item.Description}, {item.Compound} ,{item.Vol}");
                        }
                        break;
                    case "/start":
                        state = State.start;
                        break;
                    default:
                        await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Действие не найдено");
                        break;
                }

            }

            //Вызов методов для работы с БД
            else if (state == State.add)
            {
                uint id = SuppotrMethods.GetMeId();
                if (stateAdd == StateAdd.id)
                {
                    stateAdd = StateAdd.name;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите название коктейля");
                }
                else if (stateAdd == StateAdd.name)
                {
                    nameAdd = message.Text;
                    stateAdd = StateAdd.description;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите описание коктейля");
                }
                else if (stateAdd == StateAdd.description)
                {
                    decriptionAdd = message.Text;
                    stateAdd = StateAdd.compound;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите состав коктейля");
                }
                else if (stateAdd == StateAdd.compound)
                {
                    compoundAdd = message.Text;
                    stateAdd = StateAdd.vol;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите крепость коктейля");
                }
                else if (stateAdd == StateAdd.vol)
                {
                    volAdd = message.Text;
                    var add = MethodMMenu.AddCocktail(id, nameAdd, decriptionAdd, compoundAdd, volAdd);
                    stateAdd = StateAdd.id;
                    state = State.start;
                    if (add)
                    {await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Коктейль добавлен");}
                    else { await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Неверно указана крепость"); }
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"\"XXXX Добавить коктейль /Add XXXX " +
                    $"Найти Коктейль /Search" +
                    $"\"XXXX Изменить коктейль /Change XXXXX \" +\r\n" +
                    $"\"\\n XXXXX  Показать все коктейли /All XXXX\"  Вернуться в начало /Start");
                }

            }

            else if (state == State.search)
            {
                List<Cocktail> cocktails = MethodMMenu.SearchCocktail(message.Text);
                if (cocktails.Count > 0)
                {                    foreach (var item in cocktails)
                    {
                        await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"{item.Id} {item.Name}, {item.Description}, {item.Compound} ,{item.Vol}");
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Коктейль не найден");
                }
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"\"XXXX Добавить коктейль /Add XXXX " +
                    $"Найти Коктейль /Search" +
                    $"\"XXXX Изменить коктейль /Change XXXXX \" +\r\n" +
                    $"\"\\n XXXXX  Показать все коктейли /All XXXX\"  Вернуться в начало /Start");
                state = State.start;
            }

            else if (state == State.change)
            {
                if (stateAdd == StateAdd.id)
                {
                    changeName = message.Text;
                    stateAdd = StateAdd.name;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите название коктейля");
                }
                else if (stateAdd == StateAdd.name)
                {
                    nameAdd = message.Text;
                    stateAdd = StateAdd.description;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите описание коктейля");
                }
                else if (stateAdd == StateAdd.description)
                {
                    decriptionAdd = message.Text;
                    stateAdd = StateAdd.compound;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите состав коктейля");
                }
                else if (stateAdd == StateAdd.compound)
                {
                    compoundAdd = message.Text;
                    stateAdd = StateAdd.vol;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Введите крепость коктейля");
                }
                else if (stateAdd == StateAdd.vol)
                {
                    volAdd = message.Text;
                    MethodMMenu.ChangeCocktail(changeName, nameAdd, decriptionAdd, compoundAdd, volAdd);
                    stateAdd = StateAdd.id;
                    state = State.start;
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Коктейль изменён");
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"\"XXXX Добавить коктейль /Add XXXX " +
                    $"Найти Коктейль /Search" +
                    $"\"XXXX Изменить коктейль /Change XXXXX \" +\r\n" +
                    $"\"\\n XXXXX  Показать все коктейли /All XXXX\"  Вернуться в начало /Start");
                }                
            }

            else if (state == State.all)
            {
                MethodMMenu.AllCocktail();
            }


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
