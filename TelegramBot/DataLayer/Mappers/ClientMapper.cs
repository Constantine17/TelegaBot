using DataLayer.SQLite.Entities;
using DataLayer.Users.ClientModels;
using Telegram.Bot.Types;

namespace DataLayer.Mappers
{
    public static class ClientMapper
    {
        public static ClientEntity ToEntity(this IClient client)
        {
            return new ClientEntity
            {
                ChatId = client.Chat.Id,
                Company = client.Company,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Position = client.Position,
                MemberBefore = client.MemberBefore,
                RigistrationDate = client.RigistrationDate
            };
        }
        public static IClient ToModel(this ClientEntity clientEntity, Chat chat)
        {
            return new Client(chat)
            {
                Company = clientEntity.Company,
                FirstName = clientEntity.FirstName,
                LastName = clientEntity.LastName,
                Position = clientEntity.Position,
                MemberBefore = clientEntity.MemberBefore,
                RigistrationDate = clientEntity.RigistrationDate
            };
        }
    }
}
