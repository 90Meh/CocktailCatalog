using Telegram.Bot;
using Telegram.Bot.Types;
using System.Xml;
using System.Xml.Linq;
using CocktailCatalog.Telegram;

internal class Program
{
    private static void Main(string[] args)
    {
        //Тестим ветку dev в GIT///      

        MyTelegramBot.StartTelegramBot();
        Console.ReadLine();
       // MainMenu.StartMainMenu();
    }
}