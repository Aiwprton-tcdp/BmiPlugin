using BmiPlugin.Models;
using BmiPlugin.Services;
using System;

namespace BmiPlugin
{
    public class Bmi
	{
		public static BiometricData UsingData { get; set; } = new BiometricData();
		internal static int DataCount { get; set; } = Defaults.Length;


		public static void Start(Deepness deep = Deepness.Medium) =>
			Start(UsingData, deep);

		public static void Start(BiometricData input, Deepness deep = Deepness.Medium)
		{
            UsingData = input;
			WhichAreNonZero();
			UsingData.CheckAllProperties();

			GenderAssessmentService.Calculate((int)deep);
		}

		public static double GetBmi() =>
			GetBmi(UsingData.Height, UsingData.Weigth, UsingData.Age);

		public static double GetBmi(double height, double weigth, double age = 20)
		{
			WhichAreNonZero();
			UsingData.CheckBmiProperties(height, weigth, age);
			return BmiService.Get(height, weigth, age);
		}

		public static double GetGenderAssessment() =>
			GetGenderAssessment(UsingData);

		public static double GetGenderAssessment(BiometricData Data)
		{
			WhichAreNonZero();
			Data.CheckAllProperties();
			return GenderAssessmentService.Get(Data);
		}

		private static void WhichAreNonZero()
		{
			int count = 0;
			for (int i = 0; i < UsingData.GetPropertiesCount(); i++)
				if ((double)UsingData.GetProperties()[i].GetValue(UsingData, null) != 0.0d)
					count++;

			if (count < DataCount) DataCount = count;
			if (DataCount < 2)
			{
				throw new Exception("Not enough data to run.");
			}
		}
	}
}