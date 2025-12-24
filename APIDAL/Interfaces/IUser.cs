using APIDAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Interfaces
{
    public interface IUser
    {
        Task AddUser(Models.Users obj);

        Task<IEnumerable<Models.Users>> GetUsers();
    }
}
