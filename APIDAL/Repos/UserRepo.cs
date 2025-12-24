using APIDAL.Interfaces;
using APIDAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Repos
{
    public class UserRepo : IUser
    {
        public readonly AppDatabase _db;
        public UserRepo(AppDatabase db)
        {
            _db = db;
        }
        public async Task AddUser(Models.Users obj)
        {
            //  _db.Users.Add(obj);
            //  await _db.SaveChangesAsync();

            string Sql = "Exec sp_insertUsers @Name, @Email";
            List<SqlParameter> para = new List<SqlParameter>() { 
            new SqlParameter("@Name", obj.Name),    
            new SqlParameter("@Email", obj.Email)
            };
            await _db.Database.ExecuteSqlRawAsync(Sql, para.ToArray());
        }

        public async Task<IEnumerable<Models.Users>> GetUsers()
        {
            //return await _db.Users.ToListAsync();

            return _db.Users.FromSqlRaw<Models.Users>("Exec sp_GetUsers").ToList();
        }   
    }
}
