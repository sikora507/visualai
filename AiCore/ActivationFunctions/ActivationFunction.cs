using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore.ActivationFunctions
{
    public abstract class ActivationFunction
    {
        public abstract string Name { get; }
        public abstract double Process(double x);
    }
}
