using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal static class AssemblyObject
    {
        //Метод порождающий коктейль.
        public static Cocktail CreateCocktail(uint id)
        {
            Console.WriteLine("Введите название коктеля");
            var name = Console.ReadLine();
            Console.WriteLine("Введите описание коктейля");
            var description = Console.ReadLine();
            Console.WriteLine("Выберите ингредиенты");
            var compound = Console.ReadLine();
            Console.WriteLine("Укажите крепость алкоголя");            
            int vol = SuppotrMhetods.CheckInt(Console.ReadLine());            
            var coctail = new Cocktail(id, name, description, compound, vol);
            return coctail;
        }
        //Метод порождающий ингредиент
        public static Ingredient CreateIngredient()
        {
            Console.WriteLine("Введите название ингредиента");
            var name = Console.ReadLine();
            Console.WriteLine("Введите описание ингредиента");
            var description = Console.ReadLine();           
            Console.WriteLine("Укажите крепость ингредиента");
            int vol = SuppotrMhetods.CheckInt(Console.ReadLine()); 
            var ingredient = new Ingredient(name, description, vol);
            return ingredient;
        }
    }
}
