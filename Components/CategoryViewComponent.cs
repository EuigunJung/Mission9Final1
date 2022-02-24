using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        //load up the data set
        private IBookRepository repo { get; set; }

        public CategoryViewComponent (IBookRepository temp)
        {
            repo = temp;
        }

       //filtering and returning the database view 
        public IViewComponentResult Invoke()
        {
            //This enables to highlight the selected component
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            
            return View(types);
        }

    }
}
