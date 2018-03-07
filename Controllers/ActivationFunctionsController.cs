using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace visualai.Controllers
{
    public class ActivationFunctionsController : Controller
    {
        public int GetSigmoid()
        {
            return 1;
        }
        public int GetTanh()
        {
            return 2;
        }
        public int GetGauss()
        {
            return 3;
        }
        public int GetSine()
        {
            return 4;
        }
    }
}