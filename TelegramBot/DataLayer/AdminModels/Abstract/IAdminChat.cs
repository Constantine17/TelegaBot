using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace DataLayer.AdminModels.Abstract
{
    public interface IAdminChat
    {
        Chat Chat { get; set; }

        Message LastMessage { get; set; }

        IReplyMarkup Keyboard { get; set; }

        IAdmin Admin { get; set; }
    }
}
