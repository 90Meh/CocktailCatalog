
using Dapper;
using Npgsql;

namespace CocktailCatalog.Telegram
{
    internal static class MethodMMenu
    {

        //Метод добавляет коктейль
        public static bool AddCocktail(uint Id, string Name, string Description, string Compound, string Vol)
        {
            var alc = int.TryParse(Vol, out int X);
            if (alc)
            {
                var query =
                           $@"INSERT INTO public.""Cocktail""(""Id"", ""Name"", ""Description"", ""Compound"", ""Vol"")
	                        VALUES ({Id}, '{Name}', '{Description}', '{Compound}', {Vol});";

                using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
                {
                    connection.Execute(query);
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        //Поиск коктейля по имени
        public static List<Cocktail> SearchCocktail(string name)
        {
            var query = $"SELECT \"Id\", \"Name\", \"Description\", \"Compound\", \"Vol\"\r\n\tFROM public.\"Cocktail\" as c\r\n\t" +
                $"WHERE c.\"Name\" = '{name}';";
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                return connection.Query<Cocktail>(query).ToList();                
            }
        }

        //Изменение коктейля
        public static void ChangeCocktail(string name, string newName, string newDescription, string newCompound, string newVol)
        {
            var query = $@"UPDATE public.""Cocktail""
	            SET ""Name""= '{newName}', ""Description""= '{newDescription}', ""Compound""= '{newCompound}', ""Vol""= '{newVol}'
	            WHERE ""Name"" = '{name}';";
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                connection.Execute(query);
            }

        }

        //Выводит список всех коктейлей
        public static List<Cocktail> AllCocktail()
        {
            var query = $"SELECT \"Id\", \"Name\", \"Description\", \"Compound\", \"Vol\"\r\n\tFROM public.\"Cocktail\"";
            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                return connection.Query<Cocktail>(query).ToList();
            }
        }

    }
}
