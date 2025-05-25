namespace BookstoreLibrary
{
    /// <summary>
    /// Applies a fixed amount discount to the book price.
    /// </summary>
    public class FixedDiscount : DiscountStrategy
    {
        private readonly decimal _discountAmount;

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedDiscount"/> class.
        /// </summary>
        /// <param name="discountAmount">The fixed discount amount to be applied.</param>
        public FixedDiscount(decimal discountAmount)
        {
            if (discountAmount < 0)
                throw new ArgumentException("Discount amount cannot be negative.", nameof(discountAmount));

            _discountAmount = discountAmount;
        }

        /// <summary>
        /// Applies the fixed discount to the given price.
        /// </summary>
        /// <param name="price">The original price of the item.</param>
        /// <returns>The discounted price, ensuring it does not go below zero.</returns>
        public override decimal ApplyDiscount(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.", nameof(price));

            return Math.Max(price - _discountAmount, 0);
        }
    }
}
