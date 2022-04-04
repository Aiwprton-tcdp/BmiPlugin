namespace BmiPlugin.Models
{
    internal class Inputs
    {
        public static List<List<double>> DataForLearn => new()
        {
            new() { -91, -52, -34 }, // boy before 1 year
            new() { -93, -50, -34 }, // girl
            new() { -70, -50, -31 }, // 4
            new() { -73, -51, -31 },
            new() { -41, -34, -27 }, // 8
            new() { -43, -35, -27 },
            new() { 3, 1, -19 }, // 16
            new() { -7, -6, -19 },
            new() { 7, 10, -15 }, // 20
            new() { -6, -2, -15 },
            new() { 8, 11, -7 },
            new() { -6, 1, -7 },
            new() { 9, 14, 0 },
            new() { -6, 3, 0 },
            new() { 7, 17, -15 },
            new() { -6, 3, -15 },
            new() { 8, 20, 20 },
            new() { -8, 5, 20 },
            new() { 6, 21, 30 },
            new() { -10, 7, 30 }
        };
        public static int Length => DataForLearn.Count;
    }
}
