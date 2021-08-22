using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SQLite.Entities.Abstract
{
    public interface IUserEntity
    {
        long ChatId { get; set; }

        string FirstName { get; set; }
    }
}
