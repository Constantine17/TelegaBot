using DataLayer.Users.AdminModels.Abstract;
using System.Collections;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace DataLayer.Users.AdminModels
{
    public class Admin : IAdmin
    {
        public string Nickname { get; set; }
        public string ActionToken { get; set; }
        public Chat Chat { get; set; }

        public Admin(Chat chat)
        {
            Chat = chat;
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return Nickname;
        }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this;
    }
}
