using DataLayer;
using ServiceLayer;
using ServiceLayer.Controllers;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using Telegram.Bot;
namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            var botClient = new TelegramBotClient(bot.Token);
            botClient.SetMyCommandsAsync(bot.Commands);
            var botService = new BotService(botClient);
            new BotConroller(botService).StartBot();
            Console.ReadLine();
        }

    }
}
