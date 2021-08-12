using DataLayer.SQLite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mappers
{
    public static class ClientMapper
    {
        public static ClientEntity ToEntity(this IClient client)
        {
            return new ClientEntity
            {
                Id = client.Chat.Id,
                Company = client.Company,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Position = client.Position,
                MemberBefore = client.MemberBefore,
                Role = client.Role,
                RigistrationDate = client.RigistrationDate
            };
        }
    }
}
