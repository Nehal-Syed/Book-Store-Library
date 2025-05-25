using System;

namespace BookstoreLibrary
{
    /// <summary>
    /// Custom exception for handling out-of-stock errors.
    /// </summary>
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string message) : base(message) { }
    }
}
