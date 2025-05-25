namespace BookstoreLibrary;

/// <summary>
/// Represents a customer in the bookstore system.
/// </summary>
public class Customer
{
    /// <summary>
    /// Gets the name of the customer.
    /// </summary>
    public string Name { get; private init; }

    /// <summary>
    /// Gets the email address of the customer.
    /// </summary>
    public string Email { get; private init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Customer"/> class.
    /// </summary>
    /// <param name="name">The name of the customer.</param>
    /// <param name="email">The email address of the customer.</param>
    /// <exception cref="ArgumentException">Thrown when the name or email is null or empty.</exception>
    public Customer(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Customer name and email cannot be empty.");
        }

        Name = name;
        Email = email;
    }
}
