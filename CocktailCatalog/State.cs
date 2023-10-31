

namespace CocktailCatalog
{
    internal enum State
    {
        start,
        add,
        search,
        change,
        all,
        del
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
