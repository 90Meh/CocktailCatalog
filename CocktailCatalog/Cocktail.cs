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

        //Свойства прописаны в интерфесе
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Compound { get; set; }
        public int Vol { get; set; }

    }
}
