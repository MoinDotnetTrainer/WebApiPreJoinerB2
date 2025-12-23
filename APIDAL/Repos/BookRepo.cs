using APIDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Repos
{
    public class BookRepo :IBook
    {
        private readonly Models.AppDatabase _context;
        public BookRepo(Models.AppDatabase context)
        {
            _context = context;
        }
        public async Task<Models.Books> AddBookAsync(Models.Books book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Models.Books>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Models.Books?> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<Models.Books?> UpdateBookAsync(int id, Models.Books book)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
                return null;
            existingBook.BookName = book.BookName;
            existingBook.BookCode = book.BookCode;
            existingBook.Quantity = book.Quantity;
            existingBook.price = book.price;
            await _context.SaveChangesAsync();
            return existingBook;
        }
    }
}
