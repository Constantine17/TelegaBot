using DataLayer;
using DataLayer.Client.Enams;
using ServiceLayer.Services.Registration.Abstract;
using System;

namespace ServiceLayer.Services.Registration
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

        public void ExecuteBehavior(string clientAnsver)
        {
            communicationMethod.Invoke(massage, chat);
            chat.State = newState;

            if (modifiablePropertyName != null)
            {
                chat.Client.GetType().GetProperty(modifiablePropertyName).SetValue(chat.Client, clientAnsver);
            }
        }
    }
}
