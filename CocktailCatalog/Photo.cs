using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal class Photo
    {       
        public Photo(uint id, string path)
        {
            Id = id;
            PhotoPath = path;
        }

        public uint Id { get; }        
        public string PhotoPath { get; }
    }
}
