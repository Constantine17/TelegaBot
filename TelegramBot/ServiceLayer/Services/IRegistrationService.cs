using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IRegistrationService
    {
        IClient StartRegistration(IClientChat chat, string massage);
    }
}
