using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using Mission7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        
        private IBookRepository repo;

        public HomeController (IBookRepository temp)
        {
            repo = temp;
        }

       
        //The default dispaly item is 10 per page. We are getting data from the book database and display it on index file. 
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

        //This is a BooksViewModel instance, and it has book and pageinfo models. 
            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerpage = pageSize,
                    CurrentPage = pageNum
                }
            };
            //This allows to return a view that has 
            return View(x);
        }
    }
}
