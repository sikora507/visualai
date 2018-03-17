using System;

namespace AiCore.ActivationFunctions
{
    public class Gaussian : ActivationFunction
    {
        public override string Name => "Gaussian";

        public override double Process(double x)
        {
            return Math.Exp(-(x * x));
        }
    }
}
