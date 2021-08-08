using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace ServiceLayer
{
    public class BotService : IBotService
    {
        private readonly TelegramBotClient botClient;

        public event Action<object, MessageEventArgs> OnMassage;

        public BotService(TelegramBotClient botClient)
        {
            this.botClient = botClient;
        }

        public async void SayAsync(IMassage masage, IClientChat chat)
        {
           await botClient.SendTextMessageAsync(chat.Chat.Id, masage.Text);
        }

        public async void StartReceiving()
        {
            botClient.StartReceiving();
            botClient.OnMessage += BotClient_OnMessage;
        }

        public void StopReceiving()
        {
            botClient.StopReceiving();
        }

        private void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            OnMassage?.Invoke(sender, e);
        }
    }
}
