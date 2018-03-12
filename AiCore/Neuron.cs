using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore
{
    class Neuron
    {
        public double InputSum { get; set; }

        public void Fire ()
        {
            Output = ActivationFunction(InputSum);
            InputSum = 0;
        }

        public double Output { get; private set; }

        private Func<double, double> ActivationFunction = ActiFunctions.Sigmoid;

        public List<Connection> Connections = new List<Connection>();
    }
}
