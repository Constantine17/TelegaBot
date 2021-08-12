﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DataLayer
{
    public interface IClient : IEnumerable<string>
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        string Position { get; set; }
        string MemberBefore { get; set; }
        string Role { get; set; }
        string RigistrationDate { get; set; }
        Chat Chat { get; set; }
    }
}
