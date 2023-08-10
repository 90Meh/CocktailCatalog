using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace CocktailCatalog
{
    internal class MyTelegramBot
    {        

        public static async void StartTelegramBot(string tokenTelegram)
        {
            var botClient = new TelegramBotClient(tokenTelegram);
            User me = await botClient.GetMeAsync();            
            Console.WriteLine($"Hello, World! I am user {me.Id} " +
                             $"and my name is {me.FirstName}.");
        }
    }
}
