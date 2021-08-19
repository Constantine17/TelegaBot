using Telegram.Bot.Types;

namespace DataLayer.Users.Abstract
{
    public interface IUserChat
    {
        Chat Chat { get; set; }

        Message LastMessage { get; set; }
    }
}
