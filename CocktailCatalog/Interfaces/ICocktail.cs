using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog.Interfaces
{
    internal interface ICocktail
    {
        //Номер
        uint Id { get; set; }
        //Имя
        string Name { get; set; }
        //Описание
        string Description { get; set; }
        //Лист игредиентов
        string Compound { get; set; }
        //Крепость
        int Vol { get; set; }


    }
}
