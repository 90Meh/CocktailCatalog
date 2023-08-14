using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot;
using static CocktailCatalog.Telegram.UsersStateService;

namespace CocktailCatalog.Telegram
{
    internal class TelegramBotService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly UsersStateService _usersStateService;

        public TelegramBotService(ITelegramBotClient botClient)
        {
            _botClient = botClient;
            _usersStateService = new();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is null)
                return;
            Message message = update.Message;

            var fromUser = message.From;


            if (message.Text is not { } messageText)
                return;

            long chatId = message.Chat.Id;
            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            if (messageText.StartsWith("/"))
            {
                await HandleCommands(chatId, messageText, cancellationToken);
            }
            else
            {
                await HandleMessageByState(fromUser, botClient, chatId, cancellationToken);
            }
        }

        async Task HandleCommands(long chatId, string command, CancellationToken cancellationToken)
        {
            switch (command)
            {
                case "/start":
                    await _botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Добро пожаловать в бота для OpenAI",
                        cancellationToken: cancellationToken
                    );
                    break;
                case "/help":
                    await _botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Доступные команды:\n" +
                              "/start - начало работы с ботом\n" +
                              "/help - список доступных команд\n" +
                              "/chatgpt - начать работу с ChatGPT\n" +
                              "/dalle - генерация изображений с помощью DALL-E",
                        cancellationToken: cancellationToken
                    );
                    break;
                case "/chatgpt":
                    _usersStateService.SetState(chatId, UserState.ChatGPT);
                    await _botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "ChatGPT на связи! Что хотите сказать?",
                        cancellationToken: cancellationToken
                    );
                    break;
                case "/dalle":
                    _usersStateService.SetState(chatId, UserState.DALLE);
                    await _botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "DALL-E на связи! Чтто хотите сгенерировать?",
                        cancellationToken: cancellationToken
                    );
                    break;
                default:
                    _usersStateService.SetState(chatId, UserState.NoState);
                    await _botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Неизвестная команда",
                        cancellationToken: cancellationToken
                    );
                    break;
            }
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);
            return Task.CompletedTask;
        }

        async Task HandleMessageByState(
            User? user,
            ITelegramBotClient telegramBotClient,
            long chatId,
            CancellationToken cancellationToken)
        {
            UserState userState = _usersStateService.GetState(chatId);
            switch (userState)
            {
                case UserState.ChatGPT:
                    await telegramBotClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Имитирую человека...",
                        cancellationToken: cancellationToken
                    );
                    break;
                case UserState.DALLE:
                    await telegramBotClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Это всего лишь заглушка Dalle",
                        cancellationToken: cancellationToken
                    );
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(userState));
            }
        }
    }
}
