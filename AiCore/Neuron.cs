using System;
using AiCore.ActivationFunctions;

namespace AiCore
{
    public class Neuron
    {
        public int Id { get; set; }

        public double InputSum { get; set; }

        public void Fire()
        {
            Output = ActivationFunction.Process(InputSum);
            InputSum = 0;
        }

        public double Output { get; private set; }

        public ActivationFunction ActivationFunction { get; set; } = new Tanh();

    }
}
