using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class EFBookRepository : IBookRepository
    {
        public BookContext context {get; set;}
        public EFBookRepository (BookContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
