using System;

namespace MorningCoffee.Shared.Exceptions
{
    public class ProcessNotFoundException : ProcessStartException
    {
        public ProcessNotFoundException(string fileName, string? message = null, Exception? innerException = null) : base(fileName, message, innerException)
        {
        }
    }
}