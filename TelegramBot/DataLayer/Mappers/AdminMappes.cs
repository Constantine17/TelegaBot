using DataLayer.SQLite.Entities;
using DataLayer.Users.AdminModels;
using DataLayer.Users.AdminModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DataLayer.Mappers
{
    public static class AdminMappes
    {
        public static AdminEntity ToEntity(this IAdmin client)
        {
            return new AdminEntity
            {
                ChatId = client.Chat.Id,
                FirstName = client.Chat.FirstName,
            };
        }
        public static IAdmin ToModel (this AdminEntity adminEntity, Chat chat)
        {
            return new Admin(chat)
            {
                Nickname = adminEntity.FirstName
            };
        }
    }
}
