using AiCore;
using Microsoft.AspNetCore.Mvc;

namespace visualai.Controllers
{
    public class SimpleNetworkController : Controller
    {
        public VisNetwork GetSimpleNetwork()
        {
            var network = new Network();
            var result = network.ToVisJsNetwork();
            return result;
        }
    }
}