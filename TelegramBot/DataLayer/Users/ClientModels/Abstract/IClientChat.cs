using DataLayer.Users.Abstract;
using DataLayer.Users.ClientModels.Enams;
using Telegram.Bot.Types;

namespace DataLayer.Users.ClientModels
{
    public interface IClientChat : IUserChat
    {
        ClientState State { get; set; }

        new IClient User { get; set; }
    }
}
