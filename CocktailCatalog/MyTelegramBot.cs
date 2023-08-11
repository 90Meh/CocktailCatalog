using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Xml;

namespace CocktailCatalog
{
    internal class MyTelegramBot
    {        

        public static async void StartTelegramBot(string tokenTelegram)
        {
            //Токен телеграмм бота 
            
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
            var botClient = new TelegramBotClient(tokenTelegram);
            User me = await botClient.GetMeAsync();            
            Console.WriteLine($"Hello, World! I am user {me.Id} " +
                             $"and my name is {me.FirstName}.");
        }
    }
}
