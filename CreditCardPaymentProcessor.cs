public class CreditCardPaymentProcessor : PaymentProcessor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreditCardPaymentProcessor"/> class.
    /// </summary>
    public CreditCardPaymentProcessor() : base("Credit Card")
    {
    }

    /// <summary>
    /// Processes a credit card payment.
    /// </summary>
    public override bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount}");
        return true;
    }
}
