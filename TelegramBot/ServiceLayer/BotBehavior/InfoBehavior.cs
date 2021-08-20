using DataLayer.Mappers;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.SQLite.Entities;
using DataLayer.Users.Abstract;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Extension;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using ServiceLayer.Services.Writers;
using System;
using System.IO;
using System.Linq;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer.BotBehavior
{
    public class InfoBehavior : IBehavior<IUserChat>
    {
        public IBehavior<IUserChat> NextBehavior { get; }

        private readonly Action<IMassage, IUserChat, IReplyMarkup> communicationMethod;

        private readonly IRepository<ClientEntity> repository;

        public InfoBehavior(Action<IMassage, IUserChat, IReplyMarkup> communicationMethod, IRepository<ClientEntity> repository, IBehavior<IUserChat> nextBehavior = null)
        {
            this.communicationMethod = communicationMethod;
            this.repository = repository;
            this.NextBehavior = nextBehavior;
        }

        public void ExecuteBehavior(IUserChat clientChat)
        {
            bool successful;

            File.Delete(@".\ClientTable.csv");

            var ClientColection = repository.Get(new SelectAllSpecification<ClientEntity>()).Select(s => s.ToClient(clientChat.Chat)).ToList();

            var newColection = new SortService().TrySelectionProperties(ClientColection.AsQueryable(), "FirstName, LastName, Company, Position, MemberBefore, RigistrationDate", out successful);
            new CSVWriter<IQueryable>().Write(newColection.ToStringColection(), @".\ClientTable.csv");

            foreach (var prop in clientChat.User)
            {
                if (prop.IsDefault())
                {
                    communicationMethod.Invoke(new Massage("Не заповнив"), clientChat, null);
                }
                else
                {
                    communicationMethod.Invoke(new Massage(prop), clientChat, null);
                }
            }

            NextBehavior?.ExecuteBehavior(clientChat);
        }
    }
}
