using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace CocktailCatalog.Telegram
{
    internal static class MethodMMenu
    {
        public static void AddCocktail(uint Id, string Name, string Description, string Compound, int Vol)
        {
            var query = $"INSERT INTO public.\"Cocktail\"(\r\n\t\"Id\", \"Name\", \"Description\", \"Compound\", \"Vol\")\r\n\tVALUES" +
                                                                $" ({Id}, '{Name}', '{Description}', '{Compound}', {Vol});";
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                connection.Execute(query);              
            }

        }

        public static Cocktail SearchCocktail()
        {
            var query = $"SELECT \"Id\", \"Name\", \"Description\", \"Compound\", \"Vol\"\r\n\tFROM public.\"Cocktail\"";
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                return connection.Query<Cocktail>(query).ToList()[1];                
            }
        }
    }
}
