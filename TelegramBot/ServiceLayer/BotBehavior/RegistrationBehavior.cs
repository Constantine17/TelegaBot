using DataLayer.Users.ClientModels;
using DataLayer.Users.ClientModels.Enams;
using ServiceLayer.BotBehavior.Abstract;
using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer.BotBehavior
{
    record RegistrationBehavior : IBehavior<IClientChat>
    {
        public IBehavior<IClientChat> NextBehavior { get; }

        private readonly IClientChat chat;

        private readonly IMassage massage;

        private readonly ClientState newState;

        private readonly Action<IMassage, IClientChat, IReplyMarkup> communicationMethod;

        private readonly string modifiablePropertyName;

        public RegistrationBehavior(IClientChat chat, IMassage massage, ClientState newState, Action<IMassage, IClientChat, IReplyMarkup> communicationMethod, string modifiablePropertyName = null, IBehavior<IClientChat> nextBehavior = null)
        {
            this.chat = chat;
            this.massage = massage;
            this.newState = newState;
            this.communicationMethod = communicationMethod;
            this.modifiablePropertyName = modifiablePropertyName;
            this.NextBehavior = nextBehavior;
        }

        public void ExecuteBehavior(IClientChat ClientChat)
        {
            communicationMethod.Invoke(massage, chat, null);
            chat.State = newState;
            if (modifiablePropertyName != null)
            {
                chat.User.GetType().GetProperty(modifiablePropertyName).SetValue(chat.User, ClientChat.LastMessage.Text);
            }

            NextBehavior?.ExecuteBehavior(ClientChat);
        }
    }
}
