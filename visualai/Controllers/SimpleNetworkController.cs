using AiCore;
using Microsoft.AspNetCore.Mvc;

namespace visualai.Controllers
{
    public class SimpleNetworkController : Controller
    {
        public static ExampleNetwork _network = new ExampleNetwork();
        public VisNetwork GetSimpleNetwork()
        {
            _network = new ExampleNetwork();
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

        public int GetBitsPrecision()
        {
            return ConnectionMatrix.WeightBitsPrecision;
        }
    }
}