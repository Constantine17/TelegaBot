using DataLayer.Users.Abstract;
using Telegram.Bot.Types;

namespace DataLayer.Users.ClientModels
{
    public interface IClient : IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        string Position { get; set; }
        string MemberBefore { get; set; }
        string Role { get; set; }
        string RigistrationDate { get; set; }
        Chat Chat { get; set; }
    }
}
