using DataLayer.Repository;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.SQLite.Entities;
using DataLayer.Users.Abstract;
using DataLayer.Users.ClientModels;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Massages;
using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer.BotBehavior.AdminBehavior
{
    public class AddNewAdminBehavior : IBehavior<IClientChat>
    {
        public IBehavior<IClientChat> NextBehavior { get; }

        private readonly IRepository<AdminEntity> adminRepository;
        private readonly IRepository<ClientEntity> clientRepository;
        private readonly Action<IMassage, IUserChat, IReplyMarkup> communicationMethod;
        private readonly IClientChat clientChat;

        public AddNewAdminBehavior(Action<IMassage, IUserChat, IReplyMarkup> sayAsync, IClientChat clientChat)
        {
            this.adminRepository = new AdminEntityRepository();
            this.clientRepository = new ClientEntityRepository();
            this.communicationMethod = sayAsync;
            this.clientChat = clientChat;
        }

        public void ExecuteBehavior(IClientChat clientToAdmin)
        {
            clientRepository.Delete(new GetByIdSpecification(clientToAdmin.User.Chat.Id));

            adminRepository.Create(new AdminEntity()
            { 
                ChatId = clientToAdmin.User.Chat.Id, 
                FirstName = clientToAdmin.User.FirstName
            });

            communicationMethod(new Massage($"{clientToAdmin.User.FirstName} тепер адмін"), clientChat, null);
            NextBehavior?.ExecuteBehavior(clientToAdmin);
        }
    }
}
