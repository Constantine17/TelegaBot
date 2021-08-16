using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ClientModels.Enams
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
