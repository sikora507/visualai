using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace visualai.Controllers
{
    public class ActivationFunctionsController : Controller
    {
        public double[] GetSigmoid(double scale)
        {
            return ProduceNumbers(ActiFunctions.Sigmoid, scale);
        }
        public double[] GetTanh(double scale)
        {
            return ProduceNumbers(ActiFunctions.Tanh, scale);
        }
        public double[] GetGauss(double scale)
        {
            return ProduceNumbers(ActiFunctions.Gaussian, scale);
        }
        public double[] GetSine(double scale)
        {
            return ProduceNumbers(ActiFunctions.Sin, scale);
        }
        public double[] GetSinc(double scale)
        {
            return ProduceNumbers(ActiFunctions.Sinc, scale);
        }

        public double[] ProduceNumbers(Func<double, double> producingFunction, double scale)
        {
            List<double> points = new List<double>();
            for (double i = -10; i < 10; i += 0.1)
            {
                points.Add(i); // x 
                points.Add(producingFunction(i*scale)); // y
            }
            return points.ToArray();
        }
    }
}