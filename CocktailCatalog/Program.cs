using CocktailCatalog;

internal class Program
{
    private static void Main(string[] args)
    {
        // Счётчик коктейлей
        uint idNumber = 1;

        var testList = new List<Ingredient>
        {
            AssemblyObject.CreateIngredient("voda", "opisanie", 0),
            AssemblyObject.CreateIngredient("vodka", "opisanie vodki", 40)
        };

        //Лист коктейлей
        var cocktails = new List<Cocktail> { };
        

       //Цикл создающий 350 коктейлей
        do
        {
           

            var testCocktail = AssemblyObject.CreateCocktail(idNumber, "name", "opisanie", testList, 5);
            cocktails.Add(testCocktail);

            Console.WriteLine($"{testCocktail.Id}, {testCocktail.Name} {testCocktail.Compound[1].Name}");
            idNumber++;
            Console.WriteLine(idNumber);

        } while (idNumber != 351);

        Console.WriteLine("xxxxxxxxxxxxxxxxxxxxx");
        Console.WriteLine(cocktails.Count);
        foreach (var item in cocktails)
        {
            Console.Write($"{item.Id}");
        }
        
    }
}