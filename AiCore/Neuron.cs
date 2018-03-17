using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore
{
    public class Neuron
    {
        public int Id { get; set; }

        public double InputSum { get; set; }

        public void Fire ()
        {
            Output = ActivationFunction(InputSum);
            InputSum = 0;
        }

        public double Output { get; private set; }

        private Func<double, double> ActivationFunction = ActiFunctions.Sigmoid;
    }
}
