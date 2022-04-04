using BmiPlugin.Models;

namespace BmiPlugin.Services
{
    internal class GenderAssessmentService
	{
		private static NeuralNetwork Network => new();


		public static double Get(BiometricData Data)
		{
			return Network.Think(GetValues(Data));
		}

		public static void Calculate(int deep)
		{
			for (int i = 0; i < deep; i++)
				for (int j = 0; j < Inputs.Length; j++)
					Network.Train(Inputs.DataForLearn[j], Outputs.DataForLearn[j]);
		}

		private static List<double> GetValues(BiometricData Data)
		{
			var res = new List<double>();

			for (int i = 0; i < Bmi.DataCount; i++)
				res.Add((double)Bmi.UsingData.GetProperties()[i].GetValue(Data, null) - Defaults.Data[i]);

			return res;
		}
	}
}
