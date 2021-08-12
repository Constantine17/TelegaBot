using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DataLayer
{
    public class Bot : IBot
    {
        public string Token => "1905117894:AAGaN1o3SdS9zSqYtmGEArbMZrm05lT9HNM";

        public string Name => "Test";

        public List<BotCommand> Commands = new() 
        {
            new BotCommand { Command = "/start", Description = "Починає роботу с ботом"},
            new BotCommand { Command = "/info", Description = "Видає інформацію" },
            new BotCommand { Command = "/registration", Description = "Починає регістрацію" },
        };
        public Bot()
        {
        }
    }
}
