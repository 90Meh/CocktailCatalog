
using CocktailCatalog.Telegram;
using CocktailCatalog;


internal class Program
{    
    private static async Task Main(string[] args)
    {
        //Ветка dev в GIT//
        await MyTelegramBot.BotStart(SuppotrMethods.GetMyTToken());
    }
}