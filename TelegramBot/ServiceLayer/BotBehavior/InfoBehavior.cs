using DataLayer;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Extension;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.BotBehavior
{
    public class InfoBehavior : IBehavior<IClientChat>
    {
        private readonly Action<IMassage, IClientChat> communicationMethod;

        private readonly IRepository<IClientChat> repository;

        public InfoBehavior(Action<IMassage, IClientChat> communicationMethod, IRepository<IClientChat> repository)
        {
            this.communicationMethod = communicationMethod;
            this.repository = repository;
        }

        public void ExecuteBehavior(IClientChat parameter)
        {
            bool successful;

            var colonsName = new List<string> { "Им'я; Фамілія; Компанія; Посада; Чи були раніше?" };

            var ClientColection = repository.Get(new SelectAllSpecification<IClientChat>()).Select(s => s.Client);

            var newColection = new SortService().TrySelectionProperties(ClientColection.AsQueryable(), "FirstName, LastName", out successful);

            if (successful)
            {
                colonsName.AsQueryable().WriteToFile("D:\\Test.csv");

                newColection.ToStringList().AsQueryable().WriteToFile("D:\\Test.csv");
            }

            foreach (var prop in parameter.Client)
            {
                if (prop.IsDefault())
                {
                    communicationMethod.Invoke(new Massage("Не заповнив"), parameter);
                }
                else
                {
                    communicationMethod.Invoke(new Massage(prop), parameter);
                }
                
            }
        }
    }
}
