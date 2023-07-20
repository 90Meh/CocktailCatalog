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

        //Управление инградиентами
        public static List<Ingredient> IngredientMenu (List<Ingredient> ingredients)
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("XXXX Добавить ингредиент Add XXXX Найти ингредиент Search XXXX\n " +
                "XXXX Изменить ингредиент Change XXXXX " +
                "\n XXXXX  Показать все ингредиент All XXXX Выход из меню - Exit");
            do
            {
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "add":
                        
                        break;
                    case "search":
                        
                        break;
                    case "change":
                        
                        break;
                    case "all":
                       
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Действие не найдено");
                        break;
                }
            } while (true);
        }
      
    }
}
