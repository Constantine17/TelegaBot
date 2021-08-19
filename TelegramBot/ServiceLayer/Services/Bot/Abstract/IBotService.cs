using DataLayer.Users.ClientModels;
using System;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer
{
    public interface IBotService
    {
        public event Action<object, MessageEventArgs> OnMassage;
        void SayAsync(IMassage masage, IClientChat chat, IReplyMarkup buttons = null);
        void SendFileAsync(string path, IClientChat chat);
        void StartReceiving();

        void StopReceiving();
    }
}
