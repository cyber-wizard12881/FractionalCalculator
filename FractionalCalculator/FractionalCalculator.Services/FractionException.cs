using System;
using System.Runtime.Serialization;

namespace FractionalCalculator.Services
{
    [Serializable]
    public class FractionException : Exception
    {
        public FractionException()
        {
        }

        public FractionException(string message) : base(message)
        {
        }

        public FractionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FractionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}