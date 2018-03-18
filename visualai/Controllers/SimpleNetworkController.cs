using AiCore;
using Microsoft.AspNetCore.Mvc;

namespace visualai.Controllers
{
    public class SimpleNetworkController : Controller
    {
        public static Network _network = new Network();
        public VisNetwork GetSimpleNetwork()
        {
            _network = new Network();
            var result =_network.ToVisJsNetwork();
            return result;
        }

        public VisNetwork UpdateNetwork()
        {
            _network.Tick();
            var result = _network.ToVisJsNetwork();
            return result;
        }

        public ConnectionMatrix ToConnectionMatrix()
        {
            return _network.ToConnectionMatrix();
        }
    }
}