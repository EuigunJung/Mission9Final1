using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission7.Infrastructure;
using Mission7.Models;

namespace Mission7.Pages
{
    public class ShopModel : PageModel
    {
       private IBookRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public ShopModel(IBookRepository temp)
        {
            repo = temp;
        }


        public void OnGet(string returnUrl)
        {
            //this enables the user to go back to the main index page
            ReturnUrl = returnUrl ?? "/";

            // when the object key is basket, make sure to get the json data or create an instance of the basket model:
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

        }


        public IActionResult OnPost(int bookId, string returnUrl)
        {
            // grab a specific book data matching to the id 
            Book b = repo.Books.FirstOrDefault(x => x.BookID == bookId);
            
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(b, 1);

            //set the json file with the added item
            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
