using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal enum State
    {
        start,
        add,
        search,
        change,
        all
    }

    internal enum StateAdd
    {        
        id,
        name,
        description,
        compound,
        vol
    }
}
