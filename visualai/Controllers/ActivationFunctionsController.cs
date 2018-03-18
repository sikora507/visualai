using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiCore;
using AiCore.ActivationFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace visualai.Controllers
{
    public class ActivationFunctionsController : Controller
    {
        public double[] GetSigmoid(double scale)
        {
            return ProduceNumbers(new Sigmoid(), scale);
        }
        public double[] GetTanh(double scale)
        {
            return ProduceNumbers(new Tanh(), scale);
        }
        public double[] GetGauss(double scale)
        {
            return ProduceNumbers(new Gaussian(), scale);
        }
        public double[] GetSine(double scale)
        {
            return ProduceNumbers(new Sine(), scale);
        }
        public double[] GetSinc(double scale)
        {
            return ProduceNumbers(new Sinc(), scale);
        }

        public double[] ProduceNumbers(ActivationFunction activationFunction, double scale)
        {
            List<double> points = new List<double>();
            for (double i = -10; i < 10; i += 0.1)
            {
                points.Add(i); // x 
                points.Add(activationFunction.Process(i*scale)); // y
            }
            return points.ToArray();
        }
    }
}