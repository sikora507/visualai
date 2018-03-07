using System;

namespace AiCore
{
    public static class ActiFunctions
    {
        public static double Sigmoid(double x) => 1d / (1 + Math.Exp(-x));
        public static double Gaussian(double x) => Math.Exp(-(x * x));
        public static double Sin(double x) => Math.Sin(x);
        public static double Sinc(double x) => x == 0 ? 1 : Math.Sin(x) / x;
        public static double Tanh(double x) => Math.Tanh(x);
    }
}
