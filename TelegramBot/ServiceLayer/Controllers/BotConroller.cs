using DataLayer.Repository;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.Users.Abstract;
using DataLayer.Users.AdminModels.Abstract;
using DataLayer.Users.ClientModels;
using DataLayer.Users.ClientModels.Enams;
using ServiceLayer.BotBehavior;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Loggers;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Args;

namespace ServiceLayer.Controllers
{
    public class BotConroller
    {
        private readonly IRepository<IClientChat> сlientRepository;
        private readonly IRepository<IAdminChat> adminRepository;
        private readonly IBotService botService;
        public BotConroller(IBotService botService)
        {
            this.adminRepository = new AdminChatRepository();
            this.сlientRepository = new ClientChatRepository();
            this.botService = botService;


        }

        public void StartBot()
        {
            botService.StartReceiving();
            botService.OnMassage += BotService_OnMassage;
        }

        private void BotService_OnMassage(object sender, MessageEventArgs arg)
        {
            var message = arg.Message;

            var chat = GetChat(message);

            chat.LastMessage = message;

            if (chat is IClientChat clientChat)
            {
                LoggerService.SetMassage($"User {chat.Chat.FirstName} is admin", new ConsoelLogger());
                new ClientController(botService, clientChat).Start();
            }

            else if (chat is IAdminChat adminChat)
            {
                LoggerService.SetMassage($"User {chat.Chat.FirstName} is client", new ConsoelLogger());
                new AdminController(botService, adminChat).Start();
            }

            else botService.SayAsync(new UnknownСommandMassage(), chat);

        }

        private IUserChat GetChat(Telegram.Bot.Types.Message message)
        {
            IUserChat chat = сlientRepository.Get(new GetByIdSpecification(message)).FirstOrDefault();

            if (chat is null)
            {
                chat = adminRepository.Get(new GetByIdSpecification(message)).FirstOrDefault();

                if (chat is null)
                {
                    var newChat = new ClientChat(message.Chat);

                    сlientRepository.Create(newChat);

                    chat = сlientRepository.Get(new GetByIdSpecification(message)).FirstOrDefault();
                }
            }

            return chat;
        }

        
    }
}
