
using CocktailCatalog.Telegram;
using CocktailCatalog;


internal class Program
{
    //Лист коктейлей и има файла сохранённого листа
    private static List<Cocktail> _cocktails = new List<Cocktail> { };
    private static string _fileName = "baseCocktails.json";

    private static async Task Main(string[] args)
    {
        //Ветка dev в GIT//
        await MyTelegramBot.BotStart(SuppotrMethods.GetMyTToken());

    }
}