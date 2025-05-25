public abstract class PaymentProcessor
{
    /// <summary>
    /// Gets the payment method name.
    /// </summary>
    public string PaymentMethodName { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentProcessor"/> class.
    /// </summary>
    protected PaymentProcessor(string paymentMethodName)
    {
        if (string.IsNullOrWhiteSpace(paymentMethodName))
        {
            throw new ArgumentException("Payment method name cannot be empty.", nameof(paymentMethodName));
        }

        PaymentMethodName = paymentMethodName;
    }

    /// <summary>
    /// Processes the payment.
    /// </summary>
    public abstract bool ProcessPayment(decimal amount);
}
