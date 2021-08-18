using DataLayer.ClientModels;
using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

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

        public async void SayAsync(IMassage masage, IClientChat chat, IReplyMarkup buttons = null)
        {
            await botClient.SendTextMessageAsync(chat.Chat.Id, masage.Text, replyMarkup: buttons);
        }

        public async void SendFileAsync(string path, IClientChat chat)
        {
            using (var resource = File.OpenRead(path))
            {
                await botClient.SendDocumentAsync(chat.Chat.Id, new InputOnlineFile(resource, "Table.csv"));
            }
            
        }


        public void StartReceiving()
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
