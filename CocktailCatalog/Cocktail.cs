
namespace CocktailCatalog
{
    internal class Cocktail : Interfaces.ICocktail
    {
       

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

    }
}
