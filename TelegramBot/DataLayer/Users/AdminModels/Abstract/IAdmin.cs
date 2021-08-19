using Telegram.Bot.Types;

namespace DataLayer.Users.AdminModels.Abstract
{
    public interface IAdmin
    {
        string Nickname { get; set; }
        Chat Chat { get; set; }
    }
}
