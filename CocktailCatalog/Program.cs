using CocktailCatalog;

internal class Program
{
    private static void Main(string[] args)
    {
        // Счётчик коктейлей
        uint idNumber = 1;

        //Лист коктейлей
        var cocktails = new List<Cocktail> { };

        //Ингредиенты добавление

        var testList = new List<Ingredient>
        {
            AssemblyObject.CreateIngredient("voda", "opisanie", 0),
            AssemblyObject.CreateIngredient("vodka", "opisanie vodki", 40)
        };
       
        Console.WriteLine("Программа Каталог Коктейлей запущена");
        do
        {

            Console.WriteLine("Выберите действие");
            Console.WriteLine("Добавить коктейль Add XXXX Найти Коктейль Search XXXX Изменить коктейль Change XXXXX Работать с ингредиентами Ingr");
            //Выбор пользователя
            var input = Console.ReadLine().ToLower();
            Console.WriteLine(input);
            switch (input)
            {
                case "add":
                    cocktails.Add(AssemblyObject.CreateCocktail(idNumber, testList));
                    idNumber++;
                    break;
                case "search":
                    var foundCocktail = UserInOut.SearchCocktail(cocktails, testList);
                    Console.WriteLine($"Имя - {foundCocktail.Name}");
                    Console.WriteLine($"Id - {foundCocktail.Id}");
                    Console.WriteLine($"Описание - {foundCocktail.Description}");
                    Console.WriteLine($"Крепость - {foundCocktail.Vol}");
                    break;
                case "Change":
                    Console.WriteLine("Выберите коктейль для изменения");
                    
                    break;
                case "Ingr":
                    Console.WriteLine("Меню управление инградиентами");

                    break;
                default:
                    break;
            }

        } while (true);

    }
}