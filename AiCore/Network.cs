﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore
{
    public class Network
    {
        private List<Neuron> _neurons { get; } = new List<Neuron>();
        private List<Connection> _connections { get; } = new List<Connection>();
        private int _currentNeuronId = 1;
        public Network()
        {
            var in1 = new Neuron();
            var in2 = new Neuron();
            var hid1 = new Neuron();
            var hid2 = new Neuron();
            var hid3 = new Neuron();
            var out1 = new Neuron();

            AddConnection(new Connection(in1, hid1, 2));
            AddConnection(new Connection(in1, hid2, 1));
            AddConnection(new Connection(in1, hid3, 2));

            AddConnection(new Connection(in2, hid1, 1.5));
            AddConnection(new Connection(in2, hid2, 1));
            AddConnection(new Connection(in2, hid3, 1.5));

            AddConnection(new Connection(hid1, out1, 3));
            AddConnection(new Connection(hid2, out1, 2));
            AddConnection(new Connection(hid3, out1, 0.5));

            AddNeuron(in1);
            AddNeuron(in2);
            AddNeuron(hid1);
            AddNeuron(hid2);
            AddNeuron(hid3);
            AddNeuron(out1);

            in1.InputSum = 5;
            in2.InputSum = 5;
        }

        public void AddConnection(Connection connection)
        {
            _connections.Add(connection);
        }
        public void AddNeuron(Neuron neuron)
        {
            neuron.Id = _currentNeuronId;
            _neurons.Add(neuron);
            _currentNeuronId++;
        }

        public void Tick()
        {
            foreach (var neuron in _neurons)
            {
                neuron.Fire();
            }
            foreach (var connection in _connections)
            {
                connection.Propagate();
            }
        }

        public VisNetwork ToVisJsNetwork()
        {
            var vis = new VisNetwork();
            foreach (var node in _neurons)
            {
                vis.Nodes.Add(new Node
                {
                    Id = node.Id,
                    Label = $"{node.Id}\nin:{node.InputSum:0.00}\nout:{node.Output:0.00}"
                });
            }
            foreach (var edge in _connections)
            {
                vis.Edges.Add(new Edge
                {
                    From = edge.InputNeuron.Id,
                    To = edge.OutputNeuron.Id,
                    Label = edge.Weight.ToString(),
                    Width = (int)edge.Weight
                });
            }
            return vis;
        }
    }
}
