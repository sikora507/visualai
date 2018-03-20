using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace visualai.Controllers
{
    public class DeserializationController : Controller
    {
        public static Network _network = new Network();

        [HttpPost]
        public void Deserialize([FromBody] ConnectionMatrix matrix)
        {
            _network = new Network(matrix);
        }
    }
}