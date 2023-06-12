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
        //Меняем содержимое кокейля
        public static void ChangeCocktail(Cocktail cocktail)
        {
            var input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "name":
                    break;
                case "vol":
                    break;
                case "ing":
                    break;
                case "descr":
                    break;
                default:
                    break;
            }
        }

    }
}
