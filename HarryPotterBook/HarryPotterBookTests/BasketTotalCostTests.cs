using System.Collections.Generic;
using HarryPotterBook;
using HarryPotterBook.Model;
using Xunit;

namespace HarryPotterBookTests
{
    public class BasketTotalCostTests
    {
        private const int Cost = 8;
        private Basket _basket;

        public BasketTotalCostTests()
        {
            _basket = new Basket();
        }

        [Fact]
        public void GivenABookThenReturnCost()
        {
            var book = new Book(){Cost = 8};

            _basket.BookSets = new List<BookSet>()
            {
                new BookSet()
                {
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            Cost = 8,
                            Title = "A"
                        }
                    }
                }
            };
            Assert.Equal(Cost, _basket.TotalCost());
        }
        
        [Fact]
        public void GivenTwoBooksThenReturnCostWithDiscount()
        {
            var expectedCost = 15.20;
            
            _basket.BookSets = new List<BookSet>()
            {
                new BookSet()
                {
                    Books = new List<Book>()
                    {
                        new Book() { Cost = Cost, Title = "A" },
                        new Book() { Cost = Cost, Title = "B" }
                    }
                }
            };
            Assert.Equal(expectedCost, _basket.TotalCost());
        }
        
        [Fact]
        public void GivenFourBooksThenReturnCostWithDiscount()
        {
            var expectedCost = 25.60;
            
            _basket.BookSets = new List<BookSet>()
            {
                new BookSet()
                {
                    Books = new List<Book>()
                    {
                        new Book() { Cost = Cost, Title = "A" },
                        new Book() { Cost = Cost, Title = "B" },
                        new Book() { Cost = Cost, Title = "C" },
                        new Book() { Cost = Cost, Title = "D" }
                    }
                }
            };
            Assert.Equal(expectedCost, _basket.TotalCost());
        }

        [Fact]
        public void GivenFiveBooksThenReturnCostWithDiscount()
        {
            var expectedCost = 30.00;
            
            _basket.BookSets = new List<BookSet>()
            {
                new BookSet()
                {
                    Books = new List<Book>()
                    {
                        new Book() { Cost = Cost, Title = "A" },
                        new Book() { Cost = Cost, Title = "B" },
                        new Book() { Cost = Cost, Title = "C" },
                        new Book() { Cost = Cost, Title = "D" },
                        new Book() { Cost = Cost, Title = "E" },
                    }
                }
            };
            Assert.Equal(expectedCost, _basket.TotalCost());
        }
    }
}