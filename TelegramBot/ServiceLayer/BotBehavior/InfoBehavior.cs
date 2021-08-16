using DataLayer.ClientModels;
using DataLayer.Mappers;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.SQLite.Entities;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Extension;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using ServiceLayer.Services.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServiceLayer.BotBehavior
{
    public class InfoBehavior : IBehavior<IClientChat>
    {
        public IBehavior<IClientChat> NextBehavior { get; }

        private readonly Action<IMassage, IClientChat> communicationMethod;

        private readonly IRepository<ClientEntity> repository;

        public InfoBehavior(Action<IMassage, IClientChat> communicationMethod, IRepository<ClientEntity> repository, IBehavior<IClientChat> nextBehavior = null)
        {
            this.communicationMethod = communicationMethod;
            this.repository = repository;
            this.NextBehavior = nextBehavior;
        }

        public void ExecuteBehavior(IClientChat clientChat)
        {
            bool successful;

            File.Delete(@".\ClientTable.csv");

            var ClientColection = repository.Get(new SelectAllSpecification<ClientEntity>()).Select(s => s.ToClient(clientChat.Chat)).ToList();
            
            var newColection = new SortService().TrySelectionProperties(ClientColection.AsQueryable(), "FirstName, LastName, Company, Position, MemberBefore, RigistrationDate", out successful);
            new CSVWriter<IQueryable>().Write(newColection.ToStringColection(), @".\ClientTable.csv");
            
            foreach (var prop in clientChat.Client)
            {
                if (prop.IsDefault())
                {
                    communicationMethod.Invoke(new Massage("Не заповнив"), clientChat);
                }
                else
                {
                    communicationMethod.Invoke(new Massage(prop), clientChat);
                }
            }

            NextBehavior?.ExecuteBehavior(clientChat);
        }
    }
}
