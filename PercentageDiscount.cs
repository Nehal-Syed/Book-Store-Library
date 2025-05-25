namespace BookstoreLibrary
{
    /// <summary>
    /// A discount strategy that applies a percentage discount.
    /// </summary>
    public class PercentageDiscount : DiscountStrategy
    {
        private readonly decimal _percentage;

        /// <summary>
        /// Initializes a new instance of the <see cref="PercentageDiscount"/> class.
        /// </summary>
        /// <param name="percentage">The discount percentage (e.g., 10 for 10%).</param>
        /// <exception cref="ArgumentException">Thrown when percentage is not between 0 and 100.</exception>
        public PercentageDiscount(decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentException("Discount percentage must be between 0 and 100.");
            }

            _percentage = percentage;
        }

        /// <summary>
        /// Applies the percentage discount to the given price.
        /// </summary>
        public override decimal ApplyDiscount(decimal price)
        {
            return price - (price * (_percentage / 100));
        }
    }
}
