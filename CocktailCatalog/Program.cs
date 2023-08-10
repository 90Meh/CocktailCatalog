using CocktailCatalog;
using Telegram.Bot;
using Telegram.Bot.Types;

internal class Program
{
    private static void Main(string[] args)
    {
        //Тестим ветку в GIT///
        // Счётчик коктейлей
        uint idNumber = 1;

        //Убрать в файлы
        var tokenTelegram = "6571711315:AAGjvDK6aapilBuwCGhyrbf3d6khq6pBKmw";

        //Лист коктейлей
        var cocktails = new List<Cocktail> { };

        //Ингредиенты добавление

        var ingredients = new List<Ingredient> { };

        MyTelegramBot.StartTelegramBot(tokenTelegram);


        Console.WriteLine("Программа Каталог Коктейлей запущена");        
        try
        {
            do
            {
                

                Console.WriteLine("Выберите действие");
                Console.WriteLine("XXXX Добавить коктейль Add XXXX Найти Коктейль Search XXXX\n " +
                    "XXXX Изменить коктейль Change XXXXX Работать с ингредиентами Ingr XXXX" +
                    "\n XXXXX  Показать все коктейли All XXXX");
                //Выбор пользователя
                var input = Console.ReadLine().ToLower();
                Console.WriteLine(input);
                switch (input)
                {
                    case "add":
                        cocktails.Add(AssemblyObject.CreateCocktail(idNumber, ingredients));
                        idNumber++;
                        break;
                    case "search":
                        var foundCocktail = Cocktail.SearchCocktail(cocktails, ingredients);
                        Console.WriteLine($"Имя - {foundCocktail.Name}");
                        Console.WriteLine($"Id - {foundCocktail.Id}");
                        Console.WriteLine($"Описание - {foundCocktail.Description}");
                        Console.WriteLine($"Крепость - {foundCocktail.Vol}");
                        break;
                    case "change":
                        Console.WriteLine("Выберите коктейль для изменения");
                        cocktails = Cocktail.ChangeCoctail(cocktails, ingredients);
                        break;
                    case "ingr":
                        Console.WriteLine("Меню управление ингредиентами");
                        ingredients = SuppotrMhetods.IngredientMenu(ingredients);
                        break;
                    case "all":
                        foreach (var item in cocktails)
                        {
                            Console.WriteLine(item.Name);
                        }
                        break;
                    default:
                        Console.WriteLine("Действие не найдено");
                        break;
                }

            } while (true);

        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка приложения!");
        }


    }
}