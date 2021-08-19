using DataLayer.Users.AdminModels.Abstract;
using Telegram.Bot.Types;

namespace DataLayer.Users.AdminModels
{
    public class Admin : IAdmin
    {
        public string Nickname { get; set; }
        public Chat Chat { get; set; }
    }
}
