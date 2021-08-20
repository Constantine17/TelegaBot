using DataLayer.Mappers;
using DataLayer.Repository.Abstract;
using DataLayer.SQLite.Entities;
using DataLayer.Users.ClientModels;
using ServiceLayer.BotBehavior.Abstract;

namespace ServiceLayer.BotBehavior
{
    public class SaveToDBBehavior : IBehavior<IClientChat>
    {
        public IBehavior<IClientChat> NextBehavior { get; }

        private IRepository<ClientEntity> repository;

        public SaveToDBBehavior(IRepository<ClientEntity> repository, IBehavior<IClientChat> nextBehavior = null)
        {
            NextBehavior = nextBehavior;
            this.repository = repository;
        }

        public void ExecuteBehavior(IClientChat clientChat)
        {
            clientChat.User.RigistrationDate = clientChat.LastMessage.Date.ToString();
            var clientEntity = clientChat.User.ToEntity();

            repository.Create(clientEntity);

            NextBehavior?.ExecuteBehavior(clientChat);
        }
    }
}
