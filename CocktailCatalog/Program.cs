using Telegram.Bot;
using Telegram.Bot.Types;
using System.Xml;
using System.Xml.Linq;
using CocktailCatalog.Telegram;
using CocktailCatalog;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //Тестим ветку dev в GIT//  


        //MyTelegramBot.StartTelegramBot();

         await BotTest.BotStart(SuppotrMhetods.GetMyTToken());
         MainMenu.StartMainMenu();
    }
}