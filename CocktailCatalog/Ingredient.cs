using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal class Ingredient : Interfaces.IIngredient
    {

        public Ingredient(string name, string description, int vol)
        {
            Name = name;
            Description = description;
            Vol = vol;
        }

        //Свойства описаны в интерфесе
        public string Name { get ; set ; }
        public string Description { get ; set ; }
        public int Vol { get; set; }

        //Поиск ингредиента
        public static Ingredient SearchIngredient(List<Ingredient> ingredients)
        {
            Console.WriteLine("Вы можете найти ингредиент по его имени или крепости");
            Console.WriteLine("Выберите параметр для поиска: Name/Vol");
            var ingredient = new Ingredient("","",0);
            bool stop = true;

            do
            {
                var input = Console.ReadLine().ToLower();
                stop = true;
                switch (input)
                {
                    case "name":
                        Console.WriteLine("Введите имя для поиска");
                        var name = Console.ReadLine().ToLower();
                        foreach (var item in ingredients)
                        {
                            if (item.Name.ToLower() == name.ToLower())
                            {
                                ingredient = item;
                                break;
                            }
                        }
                        break;                    
                    case "Vol":
                        Console.WriteLine("Введите Крепость для поиска");
                        var vol = SuppotrMhetods.CheckInt(Console.ReadLine());
                        foreach (var item in ingredients)
                        {
                            if (item.Vol == vol)
                            {
                                ingredient = item;
                                break;
                            }
                        }
                        break;                    
                    default:
                        Console.WriteLine("Команда не распознана. Повторите ввод");
                        stop = false;
                        break;
                }
            } while (!stop);

            return ingredient;
        }

        //Изменение ингредиента

        public static List<Ingredient> ChangeIngredient(List<Ingredient> ingredients)
        {
            var ingredient = Ingredient.SearchIngredient(ingredients);            

            foreach (var item in ingredients)
            {
                if (ingredient.Name == item.Name)
                {
                    Console.WriteLine("Название ингредиента");
                    item.Name = Console.ReadLine();
                    Console.WriteLine("Описание ингредиента");
                    item.Description = Console.ReadLine();
                    Console.WriteLine("Крепость");
                    item.Vol = SuppotrMhetods.CheckInt(Console.ReadLine());

                }
            }

            return ingredients;

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
