using System;

namespace MorningCoffee.Shared.Exceptions
{
    public class ProcessStartException : Exception
    {
        public readonly string FileName;

        public ProcessStartException(string fileName, string? message = null, Exception? innerException = null) : base(message, innerException)
        {
            FileName = fileName;
        }
    }
}