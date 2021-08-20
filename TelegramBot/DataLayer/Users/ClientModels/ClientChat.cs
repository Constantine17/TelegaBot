using DataLayer.Users.Abstract;
using DataLayer.Users.ClientModels.Enams;
using Telegram.Bot.Types;

namespace DataLayer.Users.ClientModels
{
    public class ClientChat : IClientChat
    {
        public Chat Chat { get; set; }
        public ClientState State { get; set; }
        public IClient User { get; set; }
        public Message LastMessage { get; set; }
        IUser IUserChat.User { get => User; set => User = (IClient)value; }

        public ClientChat(Chat chat)
        {
            Chat = chat;
            User = new Client(chat);
        }
    }
}
