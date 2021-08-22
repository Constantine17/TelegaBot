using DataLayer.Repository;
using DataLayer.Repository.Abstract;
using DataLayer.SQLite.Entities;
using DataLayer.Users.Abstract;
using DataLayer.Users.AdminModels.Abstract;
using ServiceLayer.BotBehavior.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceLayer.BotBehavior.AdminBehavior
{
    public class CreateEventBehavior : IBehavior<IAdminChat>
    {
        private readonly IRepository<EventEntity> eventRepository;

        private readonly Action<IMassage, IUserChat, IReplyMarkup> communicationMethod;

        public IBehavior<IAdminChat> NextBehavior { get; }

        public CreateEventBehavior(Action<IMassage, IUserChat, IReplyMarkup> communicationMethod, EventEntityRepository eventEntityRepository)
        {
            this.communicationMethod = communicationMethod;
            this.eventRepository = eventEntityRepository;
        }

        public void ExecuteBehavior(IAdminChat adminChat)
        {
            NextBehavior?.ExecuteBehavior(adminChat);
        }
    }
}
