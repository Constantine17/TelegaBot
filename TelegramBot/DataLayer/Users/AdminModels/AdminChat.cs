using DataLayer.Users.Abstract;
using DataLayer.Users.AdminModels.Abstract;
using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace DataLayer.Users.AdminModels
{
    public class AdminChat : IAdminChat
    {
        public Message LastMessage { get; set; }
        public IReplyMarkup Keyboard
        {
            get {
                var keyboard = new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
            {
                new() { new("Додати зустріч"), new("Список зустрічей"), new("Список участників") },
                new() { new("Додати сповіщення"), new("Додади адміна"), new("Список адмінів") },
            }
                };
                keyboard.Selective = true;
                keyboard.OneTimeKeyboard = true;
                return keyboard;
            }
        }

        public IAdmin User { get; set; }
        IUser IUserChat.User { get => User; set => User = (IAdmin)value; }

        public AdminChat(IAdmin user)
        {
            User = user;
        }
    }
}
