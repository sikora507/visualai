using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore
{
    class Connection
    {
        private readonly double _weight;
        private readonly Neuron _inputNeuron;
        private readonly Neuron _outputNeuron;

        public Connection(Neuron inputNeuron, Neuron outputNeuron, double weight)
        {
            _weight = weight;
            _inputNeuron = inputNeuron;
            _outputNeuron = outputNeuron;
        }

        public void Propagate()
        {
            _outputNeuron.InputSum += _inputNeuron.Output * _weight;
        }
    }
}
