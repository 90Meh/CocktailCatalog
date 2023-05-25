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
        public static (Cocktail,uint) CreateCocktail(uint id, string name, string description, List<Ingredient> compound, int vol, uint count)
        {
            var coctail = new Cocktail(id, name, description, compound, vol);
            count++;
            return (coctail,count);
        }
        //Метод порождающий ингредиент
        public static Ingredient CreateIngredient(string name, string description, int vol)
        {
            var ingredient = new Ingredient(name, description, vol);
            return ingredient;
        }
    }
}
