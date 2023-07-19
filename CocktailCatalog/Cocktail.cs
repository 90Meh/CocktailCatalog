using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal class Cocktail : Interfaces.ICocktail
    {
        public Cocktail(uint id, string name, string description, List<Ingredient> compound, int vol)
        {
            Id = id;
            Name = name;
            Description = description;
            Compound = compound;
            Vol = vol;
        }

        //Свойства описаны в интерфесе
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Compound { get; set; }
        public int Vol { get; set; }

        //Метод присвоения пустых значений
        public void Empty()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Compound = new List<Ingredient>();
            Vol = 0;
        }

        //Поиск коктейля
        public static Cocktail SearchCocktail(List<Cocktail> cocktails, List<Ingredient> ingredients)
        {
            Console.WriteLine("Вы можете найти коктейль по его имени, id номеру, крепости, компонентам которые в нём содержатся");
            Console.WriteLine("Выберите параметр для поиска: Name/Id/Vol/Ingr");
            var cocktail = new Cocktail(1, string.Empty, string.Empty, ingredients, 1);
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
                        var id = SuppotrMhetods.CheckInt(Console.ReadLine());
                        foreach (var item in cocktails)
                        {
                            if (item.Id == id)
                            {
                                cocktail = item;
                                break;
                            }
                        }
                        break;
                    case "Vol":
                        Console.WriteLine("Введите Крепость для поиска");
                        var vol = SuppotrMhetods.CheckInt(Console.ReadLine());
                        foreach (var item in cocktails)
                        {
                            if (item.Vol == vol)
                            {
                                cocktail = item;
                                break;
                            }
                        }                        
                        break;
                    case "Ingr":
                        Console.WriteLine("Введите имя ингредиента для поиска");
                        //Реализовать поиск по ингредиенту пока возвращает пустой коктейль
                        break;
                    default:
                        Console.WriteLine("Команда не распознана. Повторите ввод");
                        stop = false;
                        break;
                }
            } while (!stop);

            return cocktail;
        }

        //Изменение коктейля

        public static Cocktail ChangeCoctail(List<Cocktail> cocktails, List<Ingredient> ingredients)
        {
            var cocktail = SearchCocktail(cocktails, ingredients);

            Console.WriteLine("Название коктейля");
            cocktail.Name = Console.ReadLine();
            Console.WriteLine("Описание Коктейля");
            cocktail.Description = Console.ReadLine();
            Console.WriteLine("Ингредиенты");
            //Вызов метода выбора ингредиентов
            Console.WriteLine("Крепость");
            cocktail.Vol = SuppotrMhetods.CheckInt(Console.ReadLine());

            return cocktail;

        }
    }
}
