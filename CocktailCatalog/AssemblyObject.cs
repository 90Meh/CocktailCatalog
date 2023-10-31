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
            int vol = SuppotrMethods.CheckInt(Console.ReadLine());            
            var cocktail = AssemblyObject.CreateCocktail(id);
            return cocktail;
        }        
    }
}
