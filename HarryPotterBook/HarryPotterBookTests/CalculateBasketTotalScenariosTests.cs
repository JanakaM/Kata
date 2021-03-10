using System.Collections.Generic;
using System.Linq;
using HarryPotterBook;
using Xunit;

namespace HarryPotterBookTests
{
    public class CalculateBasketTotalScenariosTests
    {
        private readonly Basket _basket;
        
        public CalculateBasketTotalScenariosTests()
        {
            _basket = new Basket();
        }

        [Theory]
        [InlineData(8, new object[]{"A"})]
        [InlineData(16, new object[]{"A","A"})]
        [InlineData(23.20, new object[]{"A","A","B"})]
        [InlineData(29.60, new object[]{"A","A","B","C"})]
        [InlineData(51.60, new object[]{"A","A","B","B","C","C","D","E"})]
        public void GivenBasketWithListOfBooksReturnTotalCost(double expectedTotalCost, string[] books)
        {
            _basket.AddBooks(CreateBookList(books));
 
            var actualTotalCost = _basket.TotalCost();
            Assert.Equal(expectedTotalCost, actualTotalCost);
        }
        
        private List<Book> CreateBookList(IEnumerable<string> books)
        {
            return books.Select(b => new Book() {Cost = 8, Title = b}).ToList();
        }
    }
}