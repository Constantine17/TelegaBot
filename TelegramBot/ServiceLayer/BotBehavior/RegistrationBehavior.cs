using DataLayer;
using DataLayer.Client.Enams;
using DataLayer.Mappers;
using DataLayer.Repository;
using ServiceLayer.BotBehavior.Abstract;
using System;

namespace ServiceLayer.BotBehavior
{
    record RegistrationBehavior : IBehavior<string>
    {
        private readonly IClientChat chat;

        private readonly IMassage massage;

        private readonly ClientState newState;

        private readonly Action<IMassage, IClientChat> communicationMethod;

        private readonly string modifiablePropertyName;

        public RegistrationBehavior(IClientChat chat, IMassage massage, ClientState newState, Action<IMassage, IClientChat> communicationMethod, String modifiablePropertyName = null)
        {
            this.chat = chat;
            this.massage = massage;
            this.newState = newState;
            this.communicationMethod = communicationMethod;
            this.modifiablePropertyName = modifiablePropertyName;
        }

        public void ExecuteBehavior(string clientAnswer)
        {
            communicationMethod.Invoke(massage, chat);
            chat.State = newState;

            if (modifiablePropertyName != null)
            {
                chat.Client.GetType().GetProperty(modifiablePropertyName).SetValue(chat.Client, clientAnswer);
            }

            if (chat.State == ClientState.GetMemberBefore)
            {
                new ClientEntityRepository().Create(chat.Client.ToEntity());
            }
        }
    }
}
