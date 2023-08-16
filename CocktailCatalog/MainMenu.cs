﻿using CocktailCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal class MainMenu
    {
        public static List<Cocktail> StartMainMenu(List<Cocktail> cocktails)
        {
            uint idNumber = 1;            
            
            //Ингредиенты добавление
            var ingredients = new List<Ingredient> { };

            Console.WriteLine("Программа Каталог Коктейлей запущена");
            try
            {
                do
                {


                    Console.WriteLine("Выберите действие");
                    Console.WriteLine("XXXX Добавить коктейль Add XXXX Найти Коктейль Search XXXX\n " +
                        "XXXX Изменить коктейль Change XXXXX Работать с ингредиентами Ingr XXXX" +
                        "\n XXXXX  Показать все коктейли All XXXX");
                    //Выбор пользователя
                    var input = Console.ReadLine().ToLower();
                    Console.WriteLine(input);
                    switch (input)
                    {
                        case "add":
                            cocktails.Add(AssemblyObject.CreateCocktail(idNumber));
                            idNumber++;
                            break;
                        case "search":
                            var foundCocktail = Cocktail.SearchCocktail(cocktails);
                            Console.WriteLine($"Имя - {foundCocktail.Name}");
                            Console.WriteLine($"Id - {foundCocktail.Id}");
                            Console.WriteLine($"Описание - {foundCocktail.Description}");
                            Console.WriteLine($"Крепость - {foundCocktail.Vol}");
                            break;
                        case "change":
                            Console.WriteLine("Выберите коктейль для изменения");
                            cocktails = Cocktail.ChangeCoctail(cocktails);
                            break;
                        case "ingr":
                            Console.WriteLine("Меню управление ингредиентами");
                            ingredients = Ingredient.IngredientMenu(ingredients);
                            break;
                        case "all":
                            foreach (var item in cocktails)
                            {
                                Console.WriteLine(item.Name);
                            }
                            break;
                        case "exit":
                            return cocktails;

                        default:
                            Console.WriteLine("Действие не найдено");
                            break;
                    }

                } while (true);

            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка приложения!");
            }

            return cocktails;
        }
    }
}
