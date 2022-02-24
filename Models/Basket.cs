using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        //Adding items to the basket
        public void AddItem (Book book, int qty)
        {
            //Get the lineitem that matches the bookid
            BasketLineItem line = Items
                .Where(p => p.Book.BookID == book.BookID)
                .FirstOrDefault();

            //condition: if the line is null create a new instance of Basketlineitem with the information
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
                double sum = Items.Sum(x => x.Quantity * x.Book.Price);
                return sum;
        }

           
        public class BasketLineItem
        {
            public int LineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }

        }
    }
}
