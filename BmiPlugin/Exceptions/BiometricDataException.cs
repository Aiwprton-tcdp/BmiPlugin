namespace BmiPlugin.Exceptions
{
    public class BiometricDataException : Exception
    {
        public BiometricDataException(string name, double value) : base(name)
        {
            if (value == 0.0d)
            {
                throw new($"The '{name}' value is not specified.");
            }
            else if (value < 0.0d)
            {
                throw new($"The '{name}' value is less than zero.");
            }
            else if (value > short.MaxValue)
            {
                throw new($"The '{name}' value is very big.");
            }
        }

        public BiometricDataException()
        {
        }

        public BiometricDataException(string message) : base(message)
        {
        }

        public BiometricDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
