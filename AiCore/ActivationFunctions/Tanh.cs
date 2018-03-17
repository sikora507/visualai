using System;

namespace AiCore.ActivationFunctions
{
    public class Tanh : ActivationFunction
    {
        public override string Name => "Tanh";

        public override double Process(double x)
        {
            return Math.Tanh(x);
        }
    }
}
