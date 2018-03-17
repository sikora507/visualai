using System;

namespace AiCore.ActivationFunctions
{
    public class Sine : ActivationFunction
    {
        public override string Name => "Sine";

        public override double Process(double x)
        {
            return Math.Sin(x);
        }
    }
}
