using DataLayer.Users.Abstract;
using DataLayer.Users.ClientModels;
using System;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer
{
    public interface IBotService
    {
        public event Action<object, MessageEventArgs> OnMassage;
        void SayAsync(IMassage masage, IUserChat chat, IReplyMarkup buttons = null);
        void SendFileAsync(string path, IUserChat chat);
        void StartReceiving();

        void StopReceiving();
    }
}
