using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models.ViewModels
{
    public class PageInfo
    {

        public int TotalNumBooks { get; set; }
        public int BooksPerpage { get; set; }
        public int CurrentPage { get; set; }

        //This (TotalPage) is to figure out how many pages we need, and the result should come out as (int) so we need to *cast it into double
        public int TotalPages => (int) Math.Ceiling((double)TotalNumBooks / BooksPerpage);
    }
}
