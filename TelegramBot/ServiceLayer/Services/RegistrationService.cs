using DataLayer;
using DataLayer.Client;
using DataLayer.Client.Enams;
using ServiceLayer.Massages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ServiceLayer.Services
{
    public class RegistrationService: IRegistrationService
    {
        private readonly IBotService botService;

        public RegistrationService(IBotService botService)
        {
            this.botService = botService;
        }


        public IClient StartRegistration(IClientChat chat, string massage)
        {
            switch (chat.State)
            {
                case ClientState.NotRegistered:
                    botService.SayAsync(new Massage("Скажіть Ваше ім'я"), chat);
                    chat.State = ClientState.GetFirstName;
                    break;

                case ClientState.GetFirstName:
                    botService.SayAsync(new Massage("Скажіть Вашу фамілію"), chat);
                    chat.State = ClientState.GetLastName;
                    chat.Client.FirstName = massage;
                    break;

                case ClientState.GetLastName:
                    botService.SayAsync(new Massage("Скажіть Вашу компанію"), chat);
                    chat.State = ClientState.GetCompany;
                    chat.Client.LastName = massage;
                    break;

                case ClientState.GetCompany:
                    botService.SayAsync(new Massage("Скажіть Вашу позицію"), chat);
                    chat.State = ClientState.GetPosition;
                    chat.Client.Company = massage;
                    break;

                case ClientState.GetPosition:
                    botService.SayAsync(new Massage("Чи були Ви у нас раніше?"), chat);
                    chat.State = ClientState.GetMemberBefore;
                    chat.Client.Position = massage;
                    break;

                case ClientState.GetMemberBefore:
                    botService.SayAsync(new Massage("Дякую, Вас зарегистрованно!"), chat);
                    chat.State = ClientState.Registered;
                    chat.Client.MemberBefore = massage;
                    break;
            }
           
            return chat.Client;
        }
    }
}
