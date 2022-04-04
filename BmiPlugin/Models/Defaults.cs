namespace BmiPlugin.Models
{
    internal class Defaults
    {
        public static List<double> Data => new()
        {
            170.0,
            60.0,
            35.0
        };
        public static int Length => Data.Count;
    }
}
