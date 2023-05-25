using CocktailCatalog;

internal class Program
{
    private static void Main(string[] args)
    {

        var testList = new List<Ingredient>
        {
            AssemblyObject.CreateIngredient("voda", "opisanie", 0),
            AssemblyObject.CreateIngredient("vodka", "opisanie vodki", 40)
        };

        AssemblyObject.CreateCocktail(1, "name", "opisanie", testList, 5);
                
    }
}