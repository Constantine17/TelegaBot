using DataLayer.Repository;
using DataLayer.Users.AdminModels.Abstract;
using DataLayer.Users.ClientModels;
using ServiceLayer.BotBehavior;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Massages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class AdminController
    {
        private readonly Dictionary<string, IBehavior<IAdminChat>> actionFromCommand;
        private readonly IBotService botService;
        private readonly IAdminChat adminChat;

        public AdminController(IBotService botService, IAdminChat adminChat)
        {
            this.adminChat = adminChat;
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
            GetCommand(adminChat.LastMessage.Text);
        }

        private void GetCommand(string text)
        {
            var isFound = actionFromCommand.TryGetValue(text, out var behavior);

            if (isFound)
            {
                behavior.ExecuteBehavior(adminChat);
            }
            else
            {
                botService.SayAsync(new UnknownСommandMassage(), adminChat);
            }
        }
    }
}
