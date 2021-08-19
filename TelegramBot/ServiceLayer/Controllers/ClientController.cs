using DataLayer.Repository;
using DataLayer.Users.ClientModels;
using ServiceLayer.BotBehavior;
using ServiceLayer.BotBehavior.Abstract;
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
        public ClientController(IBotService botService)
        {
            this.botService = botService;
            actionFromCommand = new()
            {
                { "/info", new InfoBehavior(botService.SayAsync, new ClientEntityRepository(), new SendTableBehavior(botService.SendFileAsync, @".\ClientTable.csv")) },
                { "/start", new StartBehavior(botService.SayAsync, botService) },
                { "/registration", new StartBehavior(botService.SayAsync, botService) },
            };
        }
    }
}
