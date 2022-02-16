using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace Mission7.Models
{
    public class BookContext : DbContext
    {
        public BookContext()
        {
        }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public  DbSet<Book> Books { get; set; }

      
    }
}
