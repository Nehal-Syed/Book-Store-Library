namespace BookstoreLibrary
{
    /// <summary>
    /// Represents a book in the bookstore.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets the title of the book.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Gets the name of the book's author.
        /// </summary>
        public string AuthorName { get; init; }

        /// <summary>
        /// Gets the ISBN (International Standard Book Number) of the book.
        /// </summary>
        public string ISBN { get; init; }

        /// <summary>
        /// Gets the price of the book.
        /// </summary>
        public decimal Price { get; init; }

        private readonly DiscountStrategy? _discountStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="authorName">The name of the author.</param>
        /// <param name="isbn">The ISBN of the book.</param>
        /// <param name="price">The price of the book.</param>
        /// <param name="discountStrategy">An optional discount strategy.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when any of the required parameters (title, authorName, or ISBN) are null or empty.
        /// </exception>
        public Book(string title, string authorName, string isbn, decimal price, DiscountStrategy? discountStrategy = null)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("Title, Author Name, and ISBN cannot be empty.");
            }

            Title = title;
            AuthorName = authorName;
            ISBN = isbn;
            Price = price;
            _discountStrategy = discountStrategy;
        }

        /// <summary>
        /// Gets the final price after applying discounts (if any).
        /// </summary>
        public decimal GetFinalPrice()
        {
            return _discountStrategy?.ApplyDiscount(Price) ?? Price;
        }
    }
}
