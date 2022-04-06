using System;

namespace BmiPlugin.Exceptions
{
    internal class BiometricDataException : ArgumentException
    {
        public BiometricDataException(string name, double value) : base(name)
        {
            if (value == 0.0d)
            {
                throw new BiometricDataException($"The '{name}' value is not specified.");
            }
            else if (value < 0.0d)
            {
                throw new BiometricDataException($"The '{name}' value is less than zero.");
            }
            else if (value > short.MaxValue)
            {
                throw new BiometricDataException($"The '{name}' value is very big.");
            }
        }

        public BiometricDataException()
        {
            throw new ArgumentException();
        }

        public BiometricDataException(string message) : base(message)
        {
            throw new ArgumentException(message);
        }

        public BiometricDataException(string message, Exception innerException) : base(message, innerException)
        {
            throw new ArgumentException(message, innerException);
        }
    }
}
