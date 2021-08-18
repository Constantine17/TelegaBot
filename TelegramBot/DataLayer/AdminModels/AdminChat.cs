using DataLayer.AdminModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace DataLayer.AdminModels
{
    public class AdminChat : IAdminChat
    {
        public Chat Chat { get; set; }
        public Message LastMessage { get; set; }
        public IReplyMarkup Keyboard { get; set; }
        public IAdmin Admin { get; set; }
    }
}
