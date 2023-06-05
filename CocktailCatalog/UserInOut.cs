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

            do
            {
                switch (input)
                {
                    case "name":
                        Console.WriteLine("Введите имя для поиска");
                        var name = Console.ReadLine().ToLower();
                        foreach (var item in cocktails)
                        {
                            if (item.Name == name.ToLower())
                            {
                                cocktail = item;
                                break;
                            }
                        }
                        break;
                    case "id":
                        Console.WriteLine("Введите Id для поиска");
                        bool stop;
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
                        Console.WriteLine("Введите Id для поиска");
                        bool stop;
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
                        cocktail = cocktails[1];
                        break;
                    case "Ingr":
                        cocktail = cocktails[2];
                        break;
                    default:
                        break;
                }
            } while (true);

            return cocktail;
        }

    }

}
