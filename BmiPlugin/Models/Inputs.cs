using System.Collections.Generic;

namespace BmiPlugin.Models
{
    internal class Inputs
    {
        public static List<List<double>> DataForLearn => new List<List<double>>()
        {
            new List<double>() { -91, -52, -34 }, // boy before 1 year
            new List<double>() { -93, -50, -34 }, // girl
            new List<double>() { -70, -50, -31 }, // 4
            new List<double>() { -73, -51, -31 },
            new List<double>() { -41, -34, -27 }, // 8
            new List<double>() { -43, -35, -27 },
            new List<double>() { 3, 1, -19 }, // 16
            new List<double>() { -7, -6, -19 },
            new List<double>() { 7, 10, -15 }, // 20
            new List<double>() { -6, -2, -15 },
            new List<double>() { 8, 11, -7 },
            new List<double>() { -6, 1, -7 },
            new List<double>() { 9, 14, 0 },
            new List<double>() { -6, 3, 0 },
            new List<double>() { 7, 17, -15 },
            new List<double>() { -6, 3, -15 },
            new List<double>() { 8, 20, 20 },
            new List<double>() { -8, 5, 20 },
            new List<double>() { 6, 21, 30 },
            new List<double>() { -10, 7, 30 }
        };
        public static int Length => DataForLearn.Count;
    }
}
