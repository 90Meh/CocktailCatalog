using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal class Cocktail : Interfaces.ICocktail
    {
        public Cocktail(uint id, string name, string description, string compound, int vol)
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
        public string Compound { get; set; }
        public int Vol { get; set; }

        //Метод присвоения пустых значений
        public void Empty()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Compound = string.Empty;
            Vol = 0;
        }

        //Поиск коктейля
        public static Cocktail SearchCocktail(List<Cocktail> cocktails)
        {
            Console.WriteLine("Вы можете найти коктейль по его имени, id номеру, крепости");
            Console.WriteLine("Выберите параметр для поиска: Name/Id/Vol");
            var cocktail = new Cocktail(1, string.Empty, string.Empty, string.Empty, 1);
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
                    default:
                        Console.WriteLine("Команда не распознана. Повторите ввод");
                        stop = false;
                        break;
                }
            } while (!stop);

            return cocktail;
        }

        //Изменение коктейля

        public static List<Cocktail> ChangeCoctail(List<Cocktail> cocktails)
        {
            var cocktail = SearchCocktail(cocktails);

            foreach (var item in cocktails)
            {
                if (cocktail.Id == item.Id)
                {
                    Console.WriteLine("Название коктейля");
                    item.Name = Console.ReadLine();
                    Console.WriteLine("Описание Коктейля");
                    item.Description = Console.ReadLine();
                    Console.WriteLine("Ингредиенты");
                    item.Compound = Console.ReadLine();                    
                    Console.WriteLine("Крепость");
                    item.Vol = SuppotrMhetods.CheckInt(Console.ReadLine());

                }
            }

            return cocktails;

        }
    }
}
