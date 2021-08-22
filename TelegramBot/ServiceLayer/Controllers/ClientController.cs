using DataLayer.Repository;
using DataLayer.Users.ClientModels;
using DataLayer.Users.ClientModels.Enams;
using ServiceLayer.BotBehavior;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.BotBehavior.AdminBehavior;
using ServiceLayer.Extension;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class ClientController
    {
        private readonly Dictionary<string, IBehavior<IClientChat>> actionFromCommand;
        private readonly IBotService botService;
        private readonly IClientChat clientChat;
        public ClientController(IBotService botService, IClientChat clientChat)
        {
            this.clientChat = clientChat;
            this.botService = botService;
            actionFromCommand = new()
            {
                { "/info", new InfoBehavior(botService.SayAsync, new ClientEntityRepository()) },
                //{ "/start", new SendMailBehavior() },
                { "/superpass228", new AddNewAdminBehavior(botService.SayAsync, clientChat) },
                { "/registration", new StartBehavior(botService.SayAsync, botService) },
            };
        }

        public void Start()
        {
            GetRegistrStatus(clientChat);
            GetCommand(clientChat.LastMessage.Text);
        }

        private void GetRegistrStatus(IClientChat clientChat)
        {
            foreach (var prop in clientChat.User.GetType().GetProperties())
            {
                if (prop.GetValue(clientChat.User).IsDefault())
                {
                    clientChat.State = prop.Name switch
                    {
                        "RigistrationDate" => ClientState.NotRegistered,
                        "FirstName" => ClientState.GetFirstName,
                        "LastName" => ClientState.GetLastName,
                        "Company" => ClientState.GetCompany,
                        "Position" => ClientState.GetPosition,
                        "MemberBefore" => ClientState.GetMemberBefore,
                        _ => ClientState.Registered,
                    };
                    break;
                }
            }
        }

        private void GetCommand(string text)
        {
            var isFound = actionFromCommand.TryGetValue(text, out var behavior);

            if (isFound)
            {
                behavior.ExecuteBehavior(clientChat);
            }

            else if (clientChat.State != ClientState.Registered) new RegistrationService(botService, clientChat).Register();

            else
            {
                botService.SayAsync(new UnknownСommandMassage(), clientChat);
            }
        }
    }
}
