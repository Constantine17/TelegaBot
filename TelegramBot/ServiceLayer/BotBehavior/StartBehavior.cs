using DataLayer;
using DataLayer.Client.Enams;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Services;
using System;

namespace ServiceLayer.BotBehavior
{
    public class StartBehavior : IBehavior<IClientChat>
    {
        private readonly Action<IMassage, IClientChat> communicationMethod;

        private readonly IBotService botService;

        public StartBehavior(Action<IMassage, IClientChat> communicationMethod, IBotService botService)
        {
            this.communicationMethod = communicationMethod;
            this.botService = botService;
        }

        public void ExecuteBehavior(IClientChat parameter)
        {
            communicationMethod.Invoke(new WelcomeMessage(), parameter);

            parameter.State = ClientState.NotRegistered;

            new RegistrationService(botService, parameter).Register();
        }
    }
}
