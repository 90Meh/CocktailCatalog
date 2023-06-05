using CocktailCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal static class SuppotrMhetods
    {
        public static Cocktail SearchInCollection(List<Cocktail> list, List<Ingredient> ingredients)
        {
            var cocktail = new Cocktail(1, string.Empty, string.Empty, ingredients, 1);
            Console.WriteLine("Введите Id для поиска");
            bool stop;
            do
            {
                stop = uint.TryParse(Console.ReadLine(), out uint id);
                if (stop)
                {
                    foreach (var item in list)
                    {
                        if (item.Id == id)
                        {
                            cocktail = item;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Введено не число! Повторите ввод.");
                }

            } while (!stop);
            return cocktail;
        }
    }
}
