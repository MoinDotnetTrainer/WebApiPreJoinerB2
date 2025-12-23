using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Models
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // some validations and configurations can be added here
            modelBuilder.Entity<Books>()
       .HasIndex(b => b.BookName)
       .IsUnique();
        }


        public DbSet<Books> Books { get; set; }
    }
}
