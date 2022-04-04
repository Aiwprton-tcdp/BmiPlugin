namespace BmiPlugin.Services
{
    internal class BmiService
    {
        public static double Get(double h, double w, double a)
        {
            return Calculate(h, w, a);
        }

        private static double Calculate(double h, double w, double a)
        {
            var res = a < 20
                ? w - a - a - a
                : w / (h * h / 10000);

            return res;
        }
    }
}
