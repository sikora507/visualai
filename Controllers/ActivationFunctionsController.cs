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
        public double[] GetSigmoid()
        {
            return ProduceNumbers(ActiFunctions.Sigmoid);
        }
        public double[] GetTanh()
        {
            return ProduceNumbers(ActiFunctions.Tanh);
        }
        public double[] GetGauss()
        {
            return ProduceNumbers(ActiFunctions.Gaussian);
        }
        public double[] GetSine()
        {
            return ProduceNumbers(ActiFunctions.Sin);
        }
        public double[] GetSinc()
        {
            return ProduceNumbers(ActiFunctions.Sinc);
        }

        public double[] ProduceNumbers(Func<double, double> producingFunction)
        {
            List<double> points = new List<double>();
            for (double i = -10; i < 10; i += 0.1)
            {
                points.Add(producingFunction(i));
            }
            return points.ToArray();
        }
    }
}