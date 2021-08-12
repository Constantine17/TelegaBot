using DataLayer.Client.Enams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DataLayer.Client
{
    public class ClientChat : IClientChat
    {
        public Chat Chat { get; set; }
        public ClientState State { get; set; }
        public IClient Client { get; set; }

        public ClientChat(Chat chat)
        {
            Chat = chat;
            Client = new Client(chat);
        }
    }
}
