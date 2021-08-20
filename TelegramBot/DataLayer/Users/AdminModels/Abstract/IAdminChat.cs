using DataLayer.Users.Abstract;
using Telegram.Bot.Types.ReplyMarkups;

namespace DataLayer.Users.AdminModels.Abstract
{
    public interface IAdminChat : IUserChat
    {
        IReplyMarkup Keyboard { get; }

        new IAdmin User { get; set; }
    }
}
