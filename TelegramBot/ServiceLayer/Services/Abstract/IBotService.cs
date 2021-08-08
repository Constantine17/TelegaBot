using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ServiceLayer
{
    public interface IBotService
    {
        public event Action<object, MessageEventArgs> OnMassage;
        void SayAsync(IMassage masage, IClientChat chat);

        void StartReceiving();

        void StopReceiving();
    }
}
