using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary;

namespace BookstoreLibrary.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="BookStoreManager"/> class.
    /// </summary>
    [TestClass]
    public class BookStoreManagerTests
    {
        /// <summary>
        /// Tests if adding a book increases the inventory.
        /// </summary>
        [TestMethod]
        public void AddBook_ShouldIncreaseInventory()
        {
            // Arrange
            var bookstore = new BookStoreManager();
            var book = new Book("Framework Design Guidelines", "Kryzsztof Cwalina", "9876", 39.99m);

            // Act
            bookstore.AddBook(book);
            var result = bookstore.FindBook("9876");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Framework Design Guidelines", result.Title);
        }

        /// <summary>
        /// Tests whether the <see cref="BookStoreManager.FindBook"/> method correctly retrieves a book by ISBN.
        /// </summary>
        [TestMethod]
        public void FindBook_ShouldReturnBookByISBN()
        {
            // Arrange
            var bookstore = new BookStoreManager();
            var book = new Book("Professional C# and .NET", "Christian Nagel", "1234", 45.99m);

            // Act
            bookstore.AddBook(book);
            var result = bookstore.FindBook("1234");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Professional C# and .NET", result.Title);
        }

        /// <summary>
        /// Tests whether purchasing a book returns a success message when the book exists.
        /// </summary>
        [TestMethod]
        public void PurchaseBook_ShouldReturnSuccessMessage()
        {
            // Arrange
            var bookstore = new BookStoreManager();
            var book = new Book("Framework Design Guidelines", "Kryzsztof Cwalina", "9876", 39.99m);
            var customer = new Customer("Thomas", "thomas@example.com");

            bookstore.AddBook(book);

            // Act
            string purchaseMessage = bookstore.PurchaseBook("9876", customer, "Credit Card");

            // Assert
            Assert.AreEqual($"Purchase successful! Thomas bought 'Framework Design Guidelines' for $39.99 using Credit Card.", purchaseMessage);
        }

        /// <summary>
        /// Tests whether an attempt to purchase a book that does not exist results in an appropriate failure message.
        /// </summary>
        [TestMethod]
        public void PurchaseBook_ShouldFailIfBookNotFound()
        {
            // Arrange
            var bookstore = new BookStoreManager();
            var customer = new Customer("Bob", "bob@example.com");

            // Act
            string purchaseMessage = bookstore.PurchaseBook("3691", customer, "Credit Card");

            // Assert
            Assert.AreEqual("Book not found.", purchaseMessage);
        }

        /// <summary>
        /// Tests whether a percentage discount is correctly applied to a book purchase.
        /// </summary>
        [TestMethod]
        public void ApplyDiscount_ShouldReducePrice()
        {
            // Arrange
            var bookstore = new BookStoreManager();
            var book = new Book("Clean Code", "Robert C. Martin", "1111", 50.00m);
            var customer = new Customer("Alice", "alice@example.com");

            bookstore.AddBook(book);

            // Apply a 20% discount
            var discount = new PercentageDiscount(20);
            decimal finalPrice = discount.ApplyDiscount(book.Price);

            // Act
            string purchaseMessage = bookstore.PurchaseBook("1111", customer, "Credit Card", discount);

            // Assert
            Assert.AreEqual(40.00m, finalPrice); // 20% off from $50
            Assert.AreEqual("Purchase successful! Alice bought 'Clean Code' for $40.00 using Credit Card.", purchaseMessage);
        }

        /// <summary>
        /// Tests whether an attempt to purchase a book with an invalid payment method returns an appropriate error message.
        /// </summary>
        [TestMethod]
        public void PurchaseBook_ShouldFailForInvalidPaymentMethod()
        {
            // Arrange
            var bookstore = new BookStoreManager();
            var book = new Book("The Pragmatic Programmer", "Andy Hunt", "2222", 55.00m);
            var customer = new Customer("David", "david@example.com");

            bookstore.AddBook(book);

            // Act
            string purchaseMessage = bookstore.PurchaseBook("2222", customer, "Bitcoin"); // Unsupported payment method

            // Assert
            Assert.AreEqual("Invalid payment method.", purchaseMessage);
        }

        /// <summary>
        /// Tests whether adding a book with a duplicate ISBN is prevented.
        /// </summary>
        [TestMethod]
        public void AddBook_ShouldNotAllowDuplicateISBN()
        {
            // Arrange
            var bookstore = new BookStoreManager();
            var book1 = new Book("Design Patterns", "Erich Gamma", "3333", 60.00m);
            var book2 = new Book("Refactoring", "Martin Fowler", "3333", 45.00m); // Same ISBN

            // Act
            bool firstAdd = bookstore.AddBook(book1);
            bool secondAdd = bookstore.AddBook(book2); // Should return false

            // Assert
            Assert.IsTrue(firstAdd, "First book should be added successfully.");
            Assert.IsFalse(secondAdd, "Duplicate ISBN should not be allowed.");
        }

    }
}
