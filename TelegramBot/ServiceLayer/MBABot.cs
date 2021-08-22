using DataLayer;
using Microsoft.EntityFrameworkCore.Migrations;
using ServiceLayer.Controllers;
using ServiceLayer.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ServiceLayer
{
    public class MBABot
    {
        public void Start()
        {
            try
            {
                LoggerService.SetMassage("Bot is started", new ConsoelLogger());
                var bot = new Bot();
                var botClient = new TelegramBotClient(bot.Token);
                var botService = new BotService(botClient);
                new BotConroller(botService).StartBot();
                botClient.SetMyCommandsAsync(bot.Commands);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                LoggerService.SetMassage(e.Message, new ConsoelLogger());
            }
            finally
            {
                LoggerService.SetMassage("Bot is stopped", new ConsoelLogger());
            }
        }
    }
}
