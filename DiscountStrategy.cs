namespace BookstoreLibrary
{
    /// <summary>
    /// Abstract class for discount strategies.
    /// </summary>
    public abstract class DiscountStrategy
    {
        /// <summary>
        /// Applies the discount logic to a given price.
        /// </summary>
        /// <param name="price">The original price of the book.</param>
        /// <returns>The price after applying the discount.</returns>
        public abstract decimal ApplyDiscount(decimal price);
    }
}
