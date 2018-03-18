using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore.ActivationFunctions
{
    public static class ActiFunctionsCollection
    {
        public static ActivationFunction[] ActivationFunctionsArray = new ActivationFunction[]{
            new Gaussian(), new Sigmoid(), new Sinc(), new Sine(), new Tanh()
        };
    }
}
