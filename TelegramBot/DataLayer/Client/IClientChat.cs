using DataLayer.Client.Enams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DataLayer
{
    public interface IClientChat
    {
        Chat Chat { get; set; }

        ClientState State { get; set; }

        IClient Client { get; set; }
    }
}
