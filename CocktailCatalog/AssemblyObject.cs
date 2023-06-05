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
        public static Cocktail CreateCocktail(uint id, List<Ingredient> compound)
        {
            Console.WriteLine("Введите название коктеля");
            var name = Console.ReadLine();
            Console.WriteLine("Введите описание коктейля");
            var description = Console.ReadLine();
            Console.WriteLine("Выберите ингредиенты");
            //Написать логику для ингредиентов, с возможностью добавления или изменения отсюда и выводом списка ингредиентов.
            //Пока получаем готовый список
            Console.WriteLine("Укажите крепость алкоголя");
            bool success;
            int vol;
            do
            {
                success = int.TryParse(Console.ReadLine(), out vol);
                if (!success)
                {
                    Console.WriteLine("Число введено некорректно! Повторите ввод");
                }
            } while (!success);
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
