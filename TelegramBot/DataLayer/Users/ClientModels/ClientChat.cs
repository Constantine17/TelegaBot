using Telegram.Bot.Types;

namespace DataLayer.Users.ClientModels
{
    public class ClientChat : IClientChat
    {
        public Chat Chat { get; set; }
        public ClientState State { get; set; }
        public IClient Client { get; set; }
        public Message LastMessage { get; set; }

        public ClientChat(Chat chat)
        {
            Chat = chat;
            Client = new Client(chat);
        }
    }
}
