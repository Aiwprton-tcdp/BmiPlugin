using System.Collections.Generic;

namespace BmiPlugin.Services
{
    internal class NeuralNetwork
    {
        private List<Neuron> InputNeurons { get; set; }
        private Neuron OutputNeuron { get; set; }


        public NeuralNetwork()
        {
            InputNeurons = new List<Neuron>();
            for (int i = 0; i < Bmi.DataCount; i++)
                InputNeurons.Add(new Neuron());
            OutputNeuron = new Neuron();
        }

        public double Think(List<double> input)
        {
            var x = new List<double>();
            for (int i = 0; i < Bmi.DataCount; i++)
                x.Add(InputNeurons[i].Think(input));

            return OutputNeuron.Think(x);
        }

        public void Train(List<double> input, double output)
        {
            var thoughts_data = new List<double>();
            for (int i = 0; i < Bmi.DataCount; i++)
                thoughts_data.Add(InputNeurons[i].Think(input));

            double _output = Think(thoughts_data),
                error = -2 * (output - _output);

            for (int i = 0; i < Bmi.DataCount; i++)
                InputNeurons[i].Train(input, error * OutputNeuron.Weights[i]);
            OutputNeuron.Train(thoughts_data, error);
        }
    }
}
