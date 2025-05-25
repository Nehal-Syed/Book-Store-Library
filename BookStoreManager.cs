namespace BookstoreLibrary;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Manages bookstore operations such as adding books, searching for books, and processing purchases.
/// </summary>
public class BookStoreManager
{
    /// <summary>
    /// A list that holds the bookstore's inventory of books.
    /// </summary>
    private readonly List<Book> _inventory = new();

    /// <summary>
    /// Adds a book to the inventory if it does not already exist.
    /// </summary>
    /// <param name="book">The book to be added to the inventory.</param>
    /// <returns>True if the book was added successfully, false if the ISBN already exists.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the book parameter is null.</exception>
    public bool AddBook(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        if (_inventory.Any(b => b.ISBN == book.ISBN))
            return false; // Prevent adding duplicate ISBNs

        _inventory.Add(book);
        return true; // Book successfully added
    }


    /// <summary>
    /// Finds a book in the inventory by ISBN or title.
    /// </summary>
    /// <param name="query">The ISBN or title of the book to search for.</param>
    /// <returns>The matching book if found; otherwise, null.</returns>
    /// <exception cref="ArgumentException">Thrown when the query is null or empty.</exception>
    public Book? FindBook(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException("Query cannot be null or empty.", nameof(query));

        return _inventory.FirstOrDefault(b => b.ISBN == query ||
                                              b.Title.Equals(query, StringComparison.InvariantCultureIgnoreCase));
    }

    /// <summary>
    /// Processes the purchase of a book for a customer.
    /// </summary>
    /// <param name="isbn">The ISBN of the book to purchase.</param>
    /// <param name="customer">The customer making the purchase.</param>
    /// <param name="paymentProcessor">The payment processor handling the transaction.</param>
    /// <returns>A message confirming the purchase if successful; otherwise, a failure message.</returns>
    /// <exception cref="ArgumentException">Thrown when the ISBN is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the customer or payment processor is null.</exception>
    /// 
    /// 
    /// <summary>
    /// Processes the purchase of a book with an optional discount strategy.
    /// </summary>
    /// <param name="isbn">The ISBN of the book to purchase.</param>
    /// <param name="customer">The customer making the purchase.</param>
    /// <param name="paymentProcessor">The payment method used.</param>
    /// <param name="discountStrategy">An optional discount strategy to apply.</param>
    /// <returns>A success message if the purchase is successful, otherwise an error message.</returns>
    /// <exception cref="ArgumentException">Thrown when ISBN or paymentProcessor is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the customer is null.</exception>
    public string PurchaseBook(string isbn, Customer customer, string paymentProcessor, DiscountStrategy? discountStrategy = null)
    {
        if (string.IsNullOrWhiteSpace(isbn))
            throw new ArgumentException("ISBN cannot be null or empty.", nameof(isbn));
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));
        if (string.IsNullOrWhiteSpace(paymentProcessor))
            throw new ArgumentException("Payment processor cannot be null or empty.", nameof(paymentProcessor));

        var book = _inventory.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null)
            return "Book not found.";

        // Apply discount if a strategy is provided
        decimal finalPrice = book.Price;
        if (discountStrategy != null)
        {
            finalPrice = discountStrategy.ApplyDiscount(book.Price);
            if (finalPrice < 0)
                finalPrice = 0; // Ensure the price does not go negative
        }

        // Validate payment method
        var validPaymentMethods = new HashSet<string> { "credit card", "paypal", "bank transfer" };
        if (!validPaymentMethods.Contains(paymentProcessor.ToLower()))
            return "Invalid payment method.";

        // Process payment
        bool paymentSuccess = ProcessPayment(paymentProcessor, finalPrice);
        if (!paymentSuccess)
            return "Payment failed.";

        return $"Purchase successful! {customer.Name} bought '{book.Title}' for {finalPrice:C} using {paymentProcessor}.";
    }

    /// <summary>
    /// Simulates processing a payment using different payment processors.
    /// </summary>
    /// <param name="paymentProcessor">The payment method used.</param>
    /// <param name="amount">The amount to be charged.</param>
    /// <returns>True if the payment is successful, otherwise false.</returns>
    private bool ProcessPayment(string paymentProcessor, decimal amount)
    {
        var validPaymentMethods = new HashSet<string> { "credit card", "paypal", "bank transfer" };

        // Check if payment method is valid before proceeding
        if (!validPaymentMethods.Contains(paymentProcessor.ToLower()))
            return false; // Invalid payment method

        // Simulate successful payment processing
        return true;
    }

}
