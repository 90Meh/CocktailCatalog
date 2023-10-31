using Telegram.Bot;
using Telegram.Bot.Types;
using System.Xml;
using System.Xml.Linq;
using CocktailCatalog.Telegram;
using CocktailCatalog;
using System.Text.Json;

internal class Program
{
    //Лист коктейлей и има файла сохранённого листа
    private static List<Cocktail> _cocktails = new List<Cocktail> { };
    private static string _fileName = "baseCocktails.json";

    private static async Task Main(string[] args)
    {
        //Ветка dev в GIT//

        

        ////Проверяем наличие файла c коктейлями и создаём если нет.
        //if (System.IO.File.Exists(_fileName))
        //{
        //    string json = System.IO.File.ReadAllText(_fileName);
        //    _cocktails = JsonSerializer.Deserialize<List<Cocktail>>(json);

        //}
        //else using (System.IO.File.Create(_fileName));


        await MyTelegramBot.BotStart(SuppotrMethods.GetMyTToken());
        //_cocktails = MainMenu.StartMainMenu(_cocktails);


        ////Сохраняем все данные в файл json        
        //string jsonString = JsonSerializer.Serialize(_cocktails);
        //System.IO.File.WriteAllText(_fileName, jsonString);


    }
}