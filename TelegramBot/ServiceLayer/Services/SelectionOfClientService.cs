using DataLayer.Repository.Abstract;
using DataLayer.SQLite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SelectionOfClientService
    {
        private readonly IRepository<ClientEntity> clientRepository;

        private readonly IRepository<EventEntity> eventRepository;

        private readonly IRepository<ClientWithEventsEntity> clientWithEventsRepository;

        public SelectionOfClientService(IRepository<ClientEntity> clientRepository, IRepository<EventEntity> eventRepository, IRepository<ClientWithEventsEntity> clientWithEventsRepository)
        {
            this.clientRepository = clientRepository;
            this.eventRepository = eventRepository;
            this.clientWithEventsRepository = clientWithEventsRepository;
        }
    }
}
