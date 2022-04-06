using BmiPlugin.Exceptions;
using System.Reflection;

namespace BmiPlugin
{
    public class BiometricData
    {
        public double Height { get; set; }
        public double Weigth { get; set; }
        public double Age { get; set; }


        internal PropertyInfo[] GetProperties() =>
            new BiometricData().GetType().GetProperties();

        internal int GetPropertiesCount() =>
            GetProperties().Length;

        internal void CheckBmiProperties(double Height, double Weigth, double Age)
        {
            if (Height <= 0.0d || Height > short.MaxValue)
            {
                throw new BiometricDataException(nameof(Height), Height);
            }
            else if (Weigth <= 0.0d || Weigth > short.MaxValue)
            {
                throw new BiometricDataException(nameof(Weigth), Weigth);
            }
            else if (Age <= 0.0d || Age > short.MaxValue)
            {
                throw new BiometricDataException(nameof(Age), Age);
            }
        }

        internal void CheckAllProperties()
        {
            for (int i = 0; i < GetPropertiesCount(); i++)
            {
                var x = (double)GetProperties()[i].GetValue(this, null);
                if (x <= 0.0d || x > short.MaxValue)
                {
                    throw new BiometricDataException(GetProperties()[i].Name, x);
                }
            }
        }
    }
}
