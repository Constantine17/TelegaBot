using DataLayer.AdminModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DataLayer.AdminModels
{
    public class Admin : IAdmin
    {
        public string Nickname { get; set; }
        public Chat Chat { get; set; }
    }
}
