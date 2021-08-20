using DataLayer.Repository;
using DataLayer.Users.ClientModels;
using DataLayer.Users.ClientModels.Enams;
using ServiceLayer.BotBehavior;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
                { "/info", new InfoBehavior(botService.SayAsync, new ClientEntityRepository(), new SendTableBehavior(botService.SendFileAsync, @".\ClientTable.csv")) },
                { "/start", new StartBehavior(botService.SayAsync, botService) },
                { "/registration", new StartBehavior(botService.SayAsync, botService) },
            };
        }

        public void Start()
        {
            GetCommand(clientChat.LastMessage.Text);
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
