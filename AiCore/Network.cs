using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore
{
    class Network
    {
        public List<Neuron> Neurons { get; set; } = new List<Neuron>();
        public List<Connection> Connections { get; set; } = new List<Connection>();
        public Network()
        {
            var in1 = new Neuron();
            var in2 = new Neuron();
            var hid1 = new Neuron();
            var hid2 = new Neuron();
            var hid3 = new Neuron();
            var out1 = new Neuron();

            Connections.Add(new Connection(in1, hid1, 1));
            Connections.Add(new Connection(in1, hid2, 1));
            Connections.Add(new Connection(in1, hid3, 1));

            Connections.Add(new Connection(in2, hid1, 1));
            Connections.Add(new Connection(in2, hid2, 1));
            Connections.Add(new Connection(in2, hid3, 1));

            Connections.Add(new Connection(hid1, out1, 1));
            Connections.Add(new Connection(hid2, out1, 1));
            Connections.Add(new Connection(hid3, out1, 1));

            Neurons.Add(in1);
            Neurons.Add(in2);
            Neurons.Add(hid1);
            Neurons.Add(hid2);
            Neurons.Add(hid3);
            Neurons.Add(out1);
        }

        public void Tick()
        {
            foreach (var neuron in Neurons)
            {
                neuron.Fire();
            }
            foreach (var connection in Connections)
            {
                connection.Propagate();
            }
        }
    }
}
