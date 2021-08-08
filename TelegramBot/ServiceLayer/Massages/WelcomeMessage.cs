using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ServiceLayer
{
    public class WelcomeMessage : IMassage
    {
        public string Text => "Вітаю Вас!";
    }
}
