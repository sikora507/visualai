using System;

namespace AiCore.ActivationFunctions
{
    public class Sigmoid : ActivationFunction
    {
        public override string Name => "Sigmoid";

        public override double Process(double x)
        {
            return 1d / (1 + Math.Exp(-x));
        }
    }
}
