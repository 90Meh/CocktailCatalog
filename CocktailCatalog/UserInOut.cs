using CocktailCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal static class UserInOut
    {
        public static Cocktail SearchCocktail(List<Cocktail> cocktails, List<Ingredient> ingredients)
        {
            Console.WriteLine("Вы можете найти коктейль по его имени, id номеру, крепости, компонентам которые в нём содержатся");
            Console.WriteLine("Выберите параметр для поиска: Name/Id/Vol/Ingr");
            var cocktail = new Cocktail(1, string.Empty, string.Empty, ingredients, 1);
            var input = Console.ReadLine().ToLower();
            bool stop = true;

            do
            {
                stop = true;                 
                switch (input)
                {
                    case "name":
                        Console.WriteLine("Введите имя для поиска");
                        var name = Console.ReadLine().ToLower();
                        foreach (var item in cocktails)
                        {
                            if (item.Name.ToLower() == name.ToLower())
                            {
                                cocktail = item;
                                break;
                            }
                        }
                        break;
                    case "id":
                        Console.WriteLine("Введите Id для поиска");
                        do
                        {
                            stop = uint.TryParse(Console.ReadLine(), out uint id);
                            if (stop)
                            {
                                foreach (var item in cocktails)
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
                        break;
                    case "Vol":
                        Console.WriteLine("Введите Крепость для поиска");
                        do
                        {
                            stop = uint.TryParse(Console.ReadLine(), out uint id);
                            if (stop)
                            {
                                foreach (var item in cocktails)
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
                        break;
                    case "Ingr":
                        Console.WriteLine("Введите имя инградиента для поиска");
                        //Реализовать поиск по инградиенту пока возвращает пустой коктейль
                        break;
                    default:
                        Console.WriteLine("Команда не распознана. Повторите ввод");
                        stop = false;
                        break;
                }
            } while (!stop);
            
            return cocktail;
        }

    }

}
