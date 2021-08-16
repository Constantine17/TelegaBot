using DataLayer.ClientModels;
using System;
using Telegram.Bot.Args;

namespace ServiceLayer
{
    public interface IBotService
    {
        public event Action<object, MessageEventArgs> OnMassage;
        void SayAsync(IMassage masage, IClientChat chat);
        void SendFileAsync(string path, IClientChat chat);
        void StartReceiving();

        void StopReceiving();
    }
}
