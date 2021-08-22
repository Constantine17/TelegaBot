using DataLayer.Repository;
using DataLayer.Users.ClientModels;
using DataLayer.Users.ClientModels.Enams;
using ServiceLayer.BotBehavior;
using ServiceLayer.Massages;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IClientChat chat;

        private readonly Dictionary<ClientState, Action<IClientChat>> actionFromState;
        public RegistrationService(IBotService botService, IClientChat chat)
        {
            this.chat = chat;

            actionFromState = new()
            {
                {
                    ClientState.NotRegistered,
                    new RegistrationBehavior(chat, new Massage("Скажіть Ваше ім'я"), ClientState.GetFirstName, botService.SayAsync,
                    nextBehavior: new SaveToDBBehavior(new ClientEntityRepository())).ExecuteBehavior
                },
                {
                    ClientState.GetFirstName,
                    new RegistrationBehavior(chat, new Massage("Скажіть Вашу фамілію"), ClientState.GetLastName, botService.SayAsync, "FirstName",
                    nextBehavior: new SaveToDBBehavior(new ClientEntityRepository())).ExecuteBehavior
                },
                {
                    ClientState.GetLastName,
                    new RegistrationBehavior(chat, new Massage("Скажіть Вашу компанію"), ClientState.GetCompany, botService.SayAsync, "LastName",
                    nextBehavior: new SaveToDBBehavior(new ClientEntityRepository())).ExecuteBehavior
                },
                {
                    ClientState.GetCompany,
                    new RegistrationBehavior(chat, new Massage("Скажіть Вашу позицію"), ClientState.GetPosition, botService.SayAsync, "Company",
                    nextBehavior: new SaveToDBBehavior(new ClientEntityRepository())).ExecuteBehavior
                },
                {
                    ClientState.GetPosition,
                    new RegistrationBehavior(chat, new Massage("Чи були Ви у нас раніше?"), ClientState.GetMemberBefore, botService.SayAsync, "Position",
                    nextBehavior: new SaveToDBBehavior(new ClientEntityRepository())).ExecuteBehavior
                },
                {
                    ClientState.GetMemberBefore,
                    new RegistrationBehavior(chat, new Massage("Дякую, Вас зарегистрованно!"), ClientState.Registered, botService.SayAsync, "MemberBefore",
                    nextBehavior: new SaveToDBBehavior(new ClientEntityRepository(),
                    nextBehavior: new SendMailBehavior())).ExecuteBehavior
                },
            };
        }
        public IClient Register()
        {
            actionFromState[chat.State].Invoke(chat);
            return chat.User;
        }
    }
}

