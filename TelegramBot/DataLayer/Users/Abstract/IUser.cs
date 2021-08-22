using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DataLayer.Users.Abstract
{
    public interface IUser : IEnumerable<string>
    {
        Chat Chat { get; set; }
    }
}
