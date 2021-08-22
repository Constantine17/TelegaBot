using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DataLayer.Users.ClientModels
{
    public class Client : IClient
    {
        public string RigistrationDate { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Company { get; set; } = "";
        public string Position { get; set; } = "";
        public string MemberBefore { get; set; } = "";
        public Chat Chat {get; set; }

        public Client(Chat chat)
        {
            Chat = chat;
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return FirstName;
            yield return LastName;
            yield return Company;
            yield return Position;
            yield return MemberBefore;
            yield return RigistrationDate;
        }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this;
    }
}
