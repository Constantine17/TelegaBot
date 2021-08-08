using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Client.Enams
{
    public enum ClientState
    {
        NotRegistered,
        GetFirstName,
        GetLastName,
        GetCompany,
        GetPosition,
        GetStatus,
        GetMemberBefore,
        Registered
    }
}
