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

        //Свойства прописаны в интерфесе
        public string Name { get ; set ; }
        public string Description { get ; set ; }
        public int Vol { get; set; }

       
    }
}
