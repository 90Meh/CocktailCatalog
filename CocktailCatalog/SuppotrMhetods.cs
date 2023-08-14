using CocktailCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CocktailCatalog
{
    internal static class SuppotrMhetods
    {

        //Повторный запрос числа при ошибке
        public static int CheckInt(string input)
        {
            var succes = int.TryParse(input, out var vol);
            if (!succes)
            {
                Console.WriteLine("Ввод некорректен");
                CheckInt(Console.ReadLine());
            }
            return vol;
        }

       //Токен Телеграм
       public static string GetMyTToken()
        {
            var tokenTelegram = "|";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\\bot\token.xml");
            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    // получаем атрибут value
                    XmlNode? attr = xnode.Attributes.GetNamedItem("value");
                    tokenTelegram = attr?.Value;
                }
            }
            return tokenTelegram;
        }

    }
}
