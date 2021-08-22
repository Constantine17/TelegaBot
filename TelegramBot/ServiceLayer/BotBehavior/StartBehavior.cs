using DataLayer.Users.Abstract;
using DataLayer.Users.AdminModels.Abstract;
using DataLayer.Users.ClientModels;
using DataLayer.Users.ClientModels.Enams;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Services;
using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer.BotBehavior
{
    public class StartBehavior : IBehavior<IUserChat>
    {
        public IBehavior<IUserChat> NextBehavior { get; }

        private readonly Action<IMassage, IUserChat, IReplyMarkup> communicationMethod;

        private readonly IBotService botService;

        public StartBehavior(Action<IMassage, IUserChat, IReplyMarkup> communicationMethod, IBotService botService, IBehavior<IUserChat> nextBehavior = null)
        {
            this.communicationMethod = communicationMethod;
            this.botService = botService;
            this.NextBehavior = nextBehavior;
        }

        public void ExecuteBehavior(IUserChat clientChat)
        {
            communicationMethod.Invoke(new WelcomeMessage(), clientChat, null);

            NextBehavior?.ExecuteBehavior(clientChat);
        }
    }
}
