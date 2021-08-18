using DataLayer.Repository.Abstract;
using DataLayer.SQLite.Entities;
using ServiceLayer.BotBehavior.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BotBehavior.AdminBehavior
{
    public class CreateEventBehavior : IBehavior<string>
    {
        private readonly IRepository<EventEntity> repository;

        public IBehavior<string> NextBehavior => throw new NotImplementedException();

        public void ExecuteBehavior(string parameter)
        {
            repository
        }
    }
}
