
using CocktailCatalog.TelegramM;
using CocktailCatalog;


internal class Program
{    
    private static async Task Main(string[] args)
    {
        //Ветка dev в GIT//
        await MyTelegramBot.BotStart(SuppotrMethods.GetMyTToken());
    }
}