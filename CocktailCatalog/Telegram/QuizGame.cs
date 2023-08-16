using Telegram.Bot;
using Telegram.Bot.Types;
using System.Collections.Generic;

namespace CocktailCatalog.Telegram
{
    internal class QuizGame
    {
        private ITelegramBotClient _botClient;
        private Chat _chat;
        private int _step = 0;


        private readonly List<QuizItem> _questions = new List<QuizItem>()
        {

        };

        public QuizGame(ITelegramBotClient botClient, Chat chat)
        {
            this._botClient = botClient;
            this._chat = chat;
        }

        internal async Task StartAsync()
        {
            await _botClient.SendTextMessageAsync(_chat.Id, "Начинаем игру");
            await NextQuestion();
        }

        private Task NextQuestion()
        {
            return Task.CompletedTask;
        }
    }

    internal class QuizItem
    {
        public string Quest { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }

    }
}