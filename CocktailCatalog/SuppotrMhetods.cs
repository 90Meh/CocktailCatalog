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
        public static List<Ingredient> IngredientMenu(List<Ingredient> ingredients)
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("XXXX Добавить ингредиент Add XXXX Найти ингредиент Search XXXX\n " +
                "XXXX Изменить ингредиент Change XXXXX " +
                "\n XXXXX  Показать все ингредиент All XXXX Выход из меню - Exit");
            do
            {
                var exit = false;
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "add":
                        ingredients.Add(AssemblyObject.CreateIngredient());
                        break;
                    case "search":
                        Console.WriteLine(Ingredient.SearchIngredient(ingredients).Name);                        
                        break;
                    case "change":
                        ingredients = Ingredient.ChangeIngredient(ingredients);
                        break;
                    case "all":
                        foreach (var item in ingredients)
                        {
                            Console.WriteLine("Название" + item.Name);
                        }
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Действие не найдено");
                        break;
                }
                if (exit)
                {
                    return ingredients;
                }
            } while (true);
        }

    }
}
