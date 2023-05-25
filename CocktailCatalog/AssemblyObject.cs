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
        public static Cocktail CreateCocktail(uint id, string name, string description, List<Ingredient> compound, int vol)
        {
            var coctail = new Cocktail(id, name, description, compound, vol);
            return coctail;
        }
        //Метод порождающий ингредиент
        public static Ingredient CreateIngredient(string name, string description, int vol)
        {
            var ingredient = new Ingredient(name, description, vol);
            return ingredient;
        }
    }
}
