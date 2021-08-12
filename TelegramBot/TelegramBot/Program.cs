using DataLayer;
using ServiceLayer;
using ServiceLayer.Controllers;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            var botClient = new TelegramBotClient(bot.Token);
            var botService = new BotService(botClient);
            new BotConroller(botService).StartBot();
            botClient.SetMyCommandsAsync(bot.Commands);
            Console.ReadLine();
        }


    }
}
