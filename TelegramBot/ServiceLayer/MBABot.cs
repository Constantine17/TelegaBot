using DataLayer;
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
                ConsolLogger.SetMassage("Bot is started");
                var bot = new Bot();
                var botClient = new TelegramBotClient(bot.Token);
                var botService = new BotService(botClient);
                new BotConroller(botService).StartBot();
                botClient.SetMyCommandsAsync(bot.Commands);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                ConsolLogger.SetMassage(e.Message);
            }
            finally
            {
                ConsolLogger.SetMassage("Bot is stopped");
            }
        }
    }
}
