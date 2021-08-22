using Telegram.Bot.Types;

namespace DataLayer.Users.Abstract
{
    public interface IUserChat
    {
        Message LastMessage { get; set; }

        IUser User { get; set; }
    }
}
