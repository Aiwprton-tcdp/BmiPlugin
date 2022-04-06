using System;
using System.Collections.Generic;

namespace BmiPlugin.Services
{
    internal class Neuron
	{
		public List<double> Weights { get; set; }
		private static double Bias { get; set; }
		private static Random RandomObj => new();


		public Neuron()
		{
			Weights = new List<double>();

			for (int i = 0; i < Bmi.DataCount; i++)
				Weights.Add(RandomObj.NextDouble());

			Bias = RandomObj.NextDouble();
		}


		public double Think(List<double> input) =>
			Sigmoid(DotProduct(input, Weights) + Bias);

		public void Train(List<double> input, double error)
		{
			double learn_rate = 0.1,
				_output = Think(input),
				sigmoidD = _output * (1 - _output),
				ratio = learn_rate * error * sigmoidD;

			for (int i = 0; i < Bmi.DataCount; i++)
				Weights[i] -= input[i] * ratio;
			Bias -= ratio;
		}

		private static double Sigmoid(double x) =>
			1 / (1 + Math.Exp(-x));

		private static double DotProduct(List<double> v1, List<double> v2)
		{
			double result = 0.0;
			int c1 = v1.Count,
				c2 = v2.Count;

			if (c1 == c2)
				for (int i = 0; i < c1; i++)
					result += v1[i] * v2[i];

			return result;
		}
	}
}
