using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    //interface is used instead of class (this is an instance that forces it to use this template) 
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
