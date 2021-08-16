using DataLayer.ClientModels;
using DataLayer.SQLite.Entities;
using Telegram.Bot.Types;

namespace DataLayer.Mappers
{
    public static class ClientMapper
    {
        public static ClientEntity ToEntity(this IClient client)
        {
            return new ClientEntity
            {
                Id = client.Chat.Id,
                ChatId = client.Chat.Id,
                Company = client.Company,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Position = client.Position,
                MemberBefore = client.MemberBefore,
                Role = client.Role,
                RigistrationDate = client.RigistrationDate
            };
        }
        public static IClient ToClient(this ClientEntity clientEntity, Chat chat)
        {
            return new Client(chat)
            {
                Company = clientEntity.Company,
                FirstName = clientEntity.FirstName,
                LastName = clientEntity.LastName,
                Position = clientEntity.Position,
                MemberBefore = clientEntity.MemberBefore,
                Role = clientEntity.Role,
                RigistrationDate = clientEntity.RigistrationDate
            };
        }
    }
}
