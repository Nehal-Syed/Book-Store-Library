using System;
using BookstoreLibrary;

/// <summary>
/// Entry point for the Bookstore application.
/// </summary>
class Program
{
    /// <summary>
    /// Main method to execute the bookstore functionality.
    /// </summary>
    static void Main()
    {
        var bookstore = new BookStoreManager();
        var customer = new Customer("Thomas", "thomas@example.com");

        Console.WriteLine("=== Welcome to the Bookstore ===");

        // Creating and adding books
        var book1 = new Book("Framework Design Guidelines book", "Kryzsztof Cwalina", "9876", 39.99m);
        var book2 = new Book("Fake Book", "Random Guy", "2468", 55.99m);
        var book3 = new Book("Professional C# and .NET", "Christian Nageln", "1234", 45.99m);

        bookstore.AddBook(book1);
        bookstore.AddBook(book2);
        bookstore.AddBook(book3);

        Console.WriteLine("Books added to the store.\n");

        // Searching for a book
        string searchQuery = "9876";
        var foundBook = bookstore.FindBook(searchQuery);

        if (foundBook != null)
        {
            Console.WriteLine($"Found: {foundBook.Title} by {foundBook.AuthorName}, Price: {foundBook.Price:C}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }

        // Simulating a purchase
        string purchaseIsbn = "9876";
        string paymentMethod = "Credit Card"; // Provide a valid payment method (e.g., "Credit Card", "PayPal")

        string purchaseResult = bookstore.PurchaseBook(purchaseIsbn, customer, paymentMethod);
        Console.WriteLine(purchaseResult);

        Console.WriteLine("\n=== Thank you for visiting the Bookstore! ===");
    }
}
