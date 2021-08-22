using DataLayer.Users.Abstract;
using Telegram.Bot.Types;

namespace DataLayer.Users.AdminModels.Abstract
{
    public interface IAdmin: IUser
    {
        string Nickname { get; set; }
    }
}
