using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore
{
    public class Connection
    {
        public double Weight;
        public Neuron InputNeuron;
        public Neuron OutputNeuron;

        public Connection(Neuron inputNeuron, Neuron outputNeuron, double weight)
        {
            Weight = weight;
            InputNeuron = inputNeuron;
            OutputNeuron = outputNeuron;
        }

        public void Propagate()
        {
            OutputNeuron.InputSum += InputNeuron.Output * Weight;
        }
    }
}
