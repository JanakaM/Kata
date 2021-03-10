using System;
using System.Collections.Generic;
using System.Linq;
using HarryPotterBook;
using HarryPotterBook.Model;
using Xunit;

namespace HarryPotterBookTests
{
    public class BasketAddBookTests
    {
        private readonly Basket _basket; 
        public BasketAddBookTests()
        {
            _basket = new Basket();
        }

        [Fact]
        public void GivenEmptyBookSetWithBookAddToBookSet()
        {
            var books = new[] {"A"};

            _basket.AddBooks(CreateBookList(books));
            
            Assert.Equal(1, _basket.BookSets[0].Books.Count);
        }
        
        [Fact]
        public void GivenBookSetWithOneBookAddToBookSet()
        {
            var books = new[] {"A", "B"};

            _basket.AddBooks(CreateBookList(books));
            
            Assert.Equal(1, _basket.BookSets.Count);
            Assert.Equal(2, _basket.BookSets[0].Books.Count);
            Assert.Equal("B", _basket.BookSets[0].Books[1].Title);
        }
        
        [Fact]
        public void GivenBookSetWithTwoBooksAddToBookSet()
        {
            var books = new[] {"A", "B","C"};

            _basket.AddBooks(CreateBookList(books));
            
            Assert.Equal(1, _basket.BookSets.Count);
            Assert.Equal(3, _basket.BookSets[0].Books.Count);
            Assert.Equal("C", _basket.BookSets[0].Books[2].Title);
        }

        [Fact]
        public void GivenBookSetWithTwoBooksAndAddSameTitleAnotherBookThenCreateNewBookSet()
        {
            var books = new[] {"A", "B","B"};

            _basket.AddBooks(CreateBookList(books));
            
            Assert.Equal(2, _basket.BookSets.Count);
            Assert.Equal(2, _basket.BookSets[0].Books.Count);
            Assert.Equal(1, _basket.BookSets[1].Books.Count);
            Assert.Equal("B", _basket.BookSets[1].Books[0].Title);
        }
        
        [Fact]
        public void GivenBookSetWithMultipleTitleBooksAndAddSameTitleAnotherBookThenCreateNewBookSet()
        {
            var books = new[] {"A","A","B","B","C","C","D","E"};

            _basket.AddBooks(CreateBookList(books));
            
            Assert.Equal(2, _basket.BookSets.Count);
            Assert.Equal(5, _basket.BookSets[0].Books.Count);
            Assert.Equal(3, _basket.BookSets[1].Books.Count);
        }
        
        private List<Book> CreateBookList(IEnumerable<string> books)
        {
            return books.Select(b => new Book() {Cost = 8, Title = b}).ToList();
        }
    }
}