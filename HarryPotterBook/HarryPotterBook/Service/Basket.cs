using System.Collections.Generic;
using System.Linq;
using HarryPotterBook.Model;

namespace HarryPotterBook
{
    public class Basket
    {
        private Dictionary<int, double> _discountTable;
        public Basket()
        {
            _discountTable = new Dictionary<int, double>()
            {
                {1, 0},
                {2, 0.05},
                {3, 0.10},
                {4, 0.20},
                {5, 0.25},
            };
            BookSets = new List<BookSet>();
        }

        public List<BookSet> BookSets { get; set; }

        public double TotalCost()
        {
            var totalCost = 0.0;

            foreach (var bookSet in BookSets)
            {
                var costBeforeDiscount = bookSet.Books.Count() * 8;

                totalCost += costBeforeDiscount - (costBeforeDiscount * _discountTable[bookSet.Books.Count()]);
            }

            return totalCost;
        }

        public void AddBooks(List<Book> books)
        {
            GenerateBookSets(books);

            foreach (var book in books)
            {
                AddBook(book);
            }
        }

        private void GenerateBookSets(IEnumerable<Book> books)
        {
            var numberBookSet = books.GroupBy(x => x.Title).Select(g => new
            {
                Length = g.Count(),
            }).OrderByDescending(c => c.Length).First();

            for (var i = 0; i < numberBookSet.Length; i++)
            {
                BookSets.Add(new BookSet()
                {
                    Books = new List<Book>()
                });
            }
        }

        private void AddBook(Book book)
        {
            foreach (var bookSet in BookSets.ToList())
            {
                if (!bookSet.Books.Exists(x => x.Title == book.Title))
                {
                    bookSet.Books.Add(book);
                    return;
                }
            }
        }
    }
}