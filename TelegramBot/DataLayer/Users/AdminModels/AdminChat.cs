using DataLayer.Users.AdminModels.Abstract;
using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace DataLayer.Users.AdminModels
{
    public class AdminChat : IAdminChat
    {
        public Chat Chat { get; set; }
        public Message LastMessage { get; set; }
        public IReplyMarkup Keyboard
        {
            get => new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
            {
                new() { new("Додати зустріч"), new("Список зустрічей"), new("Список участників") },
                new() { new("Додати сповіщення"), new("Додади адміна"), new("Список адмінів") },
            }
            };
        }
        public IAdmin Admin { get; set; }
    }
}
