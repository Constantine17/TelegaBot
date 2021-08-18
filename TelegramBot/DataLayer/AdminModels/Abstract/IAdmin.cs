using Telegram.Bot.Types;

namespace DataLayer.AdminModels.Abstract
{
    public interface IAdmin
    {
        string Nickname { get; set; }
        Chat Chat { get; set; }
    }
}
