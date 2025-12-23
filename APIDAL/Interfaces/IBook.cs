using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Interfaces
{
    public interface IBook
    {
        Task<List<Models.Books>> GetAllBooksAsync();
        Task<Models.Books?> GetBookByIdAsync(int id);
        Task<Models.Books> AddBookAsync(Models.Books book);
        Task<Models.Books?> UpdateBookAsync(int id, Models.Books book);
        Task<bool> DeleteBookAsync(int id);
    }
}
