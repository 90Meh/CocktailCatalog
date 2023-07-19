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

        //Повторный запрос числа при ошибке
        public static int CheckInt(string input)
        {
            var succes = int.TryParse(input, out var vol);
            if (!succes)
            {
                Console.WriteLine("Ввод некорректен");
                CheckInt(Console.ReadLine());
            }
            return vol;
        }
    }
}
