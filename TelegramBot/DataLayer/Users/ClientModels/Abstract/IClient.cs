using DataLayer.Users.Abstract;
using Telegram.Bot.Types;

namespace DataLayer.Users.ClientModels
{
    public interface IClient : IUser
    {
        string RigistrationDate { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        string Position { get; set; }
        string MemberBefore { get; set; }
    }
}
