using DataLayer.Users.ClientModels;
using DataLayer.Users.ClientModels.Enams;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Services;
using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer.BotBehavior
{
    public class StartBehavior : IBehavior<IClientChat>
    {
        public IBehavior<IClientChat> NextBehavior { get; }

        private readonly Action<IMassage, IClientChat, IReplyMarkup> communicationMethod;

        private readonly IBotService botService;

        public StartBehavior(Action<IMassage, IClientChat, IReplyMarkup> communicationMethod, IBotService botService, IBehavior<IClientChat> nextBehavior = null)
        {
            this.communicationMethod = communicationMethod;
            this.botService = botService;
            this.NextBehavior = nextBehavior;
        }

        public void ExecuteBehavior(IClientChat clientChat)
        {
            communicationMethod.Invoke(new WelcomeMessage(), clientChat, null);

            clientChat.State = ClientState.NotRegistered;

            new RegistrationService(botService, clientChat).Register();

            NextBehavior?.ExecuteBehavior(clientChat);
        }
    }
}
