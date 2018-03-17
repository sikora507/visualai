using System;

namespace AiCore.ActivationFunctions
{
    public class Sinc : ActivationFunction
    {
        public override string Name => "Sinc";

        public override double Process(double x)
        {
            return x == 0 ? 1 : Math.Sin(x) / x;
        }
    }
}
