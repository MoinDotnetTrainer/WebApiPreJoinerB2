using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.AuthScheme.PoP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Models
{
    [Table("tbl_books")]
    [Index(nameof(BookCode),IsUnique =true)]
    public class Books
    {
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? BookCode { get; set; } // unique code for each book
        public int Quantity { get; set; }
        public int price { get; set; }
    }
}
