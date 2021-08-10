using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IClient: IEnumerable<string>
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        string Position { get; set; }
        string MemberBefore { get; set; }
    }
}
