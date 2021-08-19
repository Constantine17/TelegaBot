using DataLayer.ClientModels.Enams;
using Telegram.Bot.Types;

namespace DataLayer.Users.ClientModels
{
    public interface IClientChat
    {
        Chat Chat { get; set; }

        Message LastMessage { get; set; }

        ClientState State { get; set; }

        IClient Client { get; set; }
    }
}
