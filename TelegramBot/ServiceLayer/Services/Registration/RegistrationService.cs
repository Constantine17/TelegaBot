using DataLayer;
using DataLayer.Client;
using DataLayer.Client.Enams;
using ServiceLayer;
using ServiceLayer.Massages;
using ServiceLayer.Services.Registration;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ServiceLayer.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IClientChat chat;

        private readonly Dictionary<ClientState, Action<string>> actionFromState;
        public RegistrationService(IBotService botService, IClientChat chat)
        {
            this.chat = chat;

            actionFromState = new()
            {
                { ClientState.NotRegistered, new RegistrationBehavior(chat, new Massage("Скажіть Ваше ім'я"), ClientState.GetFirstName, botService.SayAsync).ExecuteBehavior },
                { ClientState.GetFirstName, new RegistrationBehavior(chat, new Massage("Скажіть Вашу фамілію"), ClientState.GetLastName, botService.SayAsync, "FirstName").ExecuteBehavior },
                { ClientState.GetLastName, new RegistrationBehavior(chat, new Massage("Скажіть Вашу компанію"), ClientState.GetCompany, botService.SayAsync, "LastName").ExecuteBehavior },
                { ClientState.GetCompany, new RegistrationBehavior(chat, new Massage("Скажіть Вашу позицію"), ClientState.GetPosition, botService.SayAsync, "Company").ExecuteBehavior },
                { ClientState.GetPosition, new RegistrationBehavior(chat, new Massage("Чи були Ви у нас раніше?"), ClientState.GetMemberBefore, botService.SayAsync, "Position").ExecuteBehavior },
                { ClientState.GetMemberBefore, new RegistrationBehavior(chat, new Massage("Дякую, Вас зарегистрованно!"), ClientState.Registered, botService.SayAsync, "MemberBefore").ExecuteBehavior },
            };
        }
        public IClient Register(string massage)
        {
            actionFromState[chat.State].Invoke(massage);
            return chat.Client;
        }
    }
}

