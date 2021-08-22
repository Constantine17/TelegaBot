using DataLayer.Mappers;
using DataLayer.Repository;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.SQLite.Entities;
using DataLayer.SQLite.Entities.Abstract;
using DataLayer.Users.Abstract;
using DataLayer.Users.AdminModels;
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
        private readonly IRepository<ClientEntity> сlientRepository;
        private readonly IRepository<AdminEntity> adminRepository;
        private readonly IBotService botService;
        public BotConroller(IBotService botService)
        {
            this.adminRepository = new AdminEntityRepository();
            this.сlientRepository = new ClientEntityRepository();
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

            var user = GetUser(message);

            if (user is ClientEntity clientEntity)
            {
                var clientChat = new ClientChat(clientEntity.ToModel(message.Chat))
                {
                    LastMessage = message
                };

                LoggerService.SetMassage($"User {user.FirstName} is client", new ConsoelLogger());
                new ClientController(botService, clientChat).Start();
            }
            else if (user is AdminEntity adminEntity)
            {
                var adminChat = new AdminChat(adminEntity.ToModel(message.Chat))
                {
                    LastMessage = message
                };

                LoggerService.SetMassage($"User {user.FirstName} is admin", new ConsoelLogger());
                new AdminController(botService, adminChat).Start();
            }
            else LoggerService.SetMassage("Couldn't define the role of the chat", new ConsoelLogger());
        }

        private IUserEntity GetUser(Telegram.Bot.Types.Message message)
        {
            IUserEntity chat = сlientRepository.Get(new GetByIdSpecification(message)).FirstOrDefault();

            if (chat is null)
            {
                chat = adminRepository.Get(new GetByIdSpecification(message)).FirstOrDefault();

                if (chat is null)
                {
                    var newChat = new ClientChat(new Client(message.Chat));

                    сlientRepository.Create(newChat.User.ToEntity());

                    chat = сlientRepository.Get(new GetByIdSpecification(message)).FirstOrDefault();
                }
            }

            return chat;
        }


    }
}
