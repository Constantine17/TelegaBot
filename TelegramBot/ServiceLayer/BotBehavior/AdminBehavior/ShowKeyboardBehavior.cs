using DataLayer.Users.Abstract;
using DataLayer.Users.AdminModels.Abstract;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Massages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer.BotBehavior.AdminBehavior
{
    public class ShowKeyboardBehavior : IBehavior<IUserChat>
    {
        public IBehavior<IUserChat> NextBehavior { get; }

        private readonly IAdminChat adminChat;

        private readonly Action<IMassage, IUserChat, IReplyMarkup> communicationMethod;

        public ShowKeyboardBehavior(Action<IMassage, IUserChat, IReplyMarkup> communicationMethod, IAdminChat adminChat, IBehavior<IUserChat> nextBehavior = null)
        {
            this.NextBehavior = nextBehavior;
            this.communicationMethod = communicationMethod;
            this.adminChat = adminChat;
        }

        public void ExecuteBehavior(IUserChat chat)
        {
            communicationMethod(new Massage("Оберіть дію"), chat, adminChat.Keyboard);

            NextBehavior?.ExecuteBehavior(adminChat);
        }
    }
}
