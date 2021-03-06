﻿using AiCore.ActivationFunctions;
using AiCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiCore
{
    public class Network
    {
        private List<Neuron> _neurons { get; } = new List<Neuron>();
        private List<Connection> _connections { get; } = new List<Connection>();
        private int _currentNeuronId = 0;

        public Network()
        {

        }

        public Network(ConnectionMatrix connectionMatrix)
        {
            var neuronsCount = connectionMatrix.ActiFunctions.Length;
            foreach (var actiFunction in connectionMatrix.ActiFunctions)
            {
                var function = ActiFunctionsCollection.ActivationFunctionsArray.Single(x => x.Name == actiFunction);
                AddNeuron(new Neuron
                {
                    ActivationFunction = function
                });
            }
            var buffer = new int[ConnectionMatrix.WeightBitsPrecision];
            for (int row = 0; row < neuronsCount; row++)
            {
                for (int column = 0; column < neuronsCount; column++)
                {
                    if (connectionMatrix.ConnectionPresence[row * neuronsCount + column])
                    {
                        // get weight from binary
                        Array.Copy(connectionMatrix.WeightsBinary, row * neuronsCount * ConnectionMatrix.WeightBitsPrecision + column * ConnectionMatrix.WeightBitsPrecision, buffer, 0, ConnectionMatrix.WeightBitsPrecision);
                        var weight = BinaryCalculator.ToDecimal(buffer, ConnectionMatrix.MinWeight, ConnectionMatrix.MaxWeight);
                        // setup connection
                        AddConnection(new Connection(_neurons[row], _neurons[column], weight));
                    }
                }
            }
        }

        public ConnectionMatrix ToConnectionMatrix()
        {
            var conMatrix = new ConnectionMatrix();
            var neuronsCount = _neurons.Count;

            conMatrix.ActiFunctions = new string[neuronsCount];
            conMatrix.ConnectionPresence = new bool[neuronsCount * neuronsCount];
            conMatrix.WeightsBinary = new int[neuronsCount * ConnectionMatrix.WeightBitsPrecision * neuronsCount];

            var n = 0;
            foreach (var neuron in _neurons)
            {
                conMatrix.ActiFunctions[n] = neuron.ActivationFunction.Name;
                n++;
            }

            foreach (var connection in _connections)
            {
                var row = _neurons.IndexOf(connection.InputNeuron);
                var col = _neurons.IndexOf(connection.OutputNeuron);
                // update connection presence
                conMatrix.ConnectionPresence[row * neuronsCount + col] = true;
                // update connection weight
                var weightBinary = BinaryCalculator.ToBinary(connection.Weight, ConnectionMatrix.WeightBitsPrecision, ConnectionMatrix.MinWeight, ConnectionMatrix.MaxWeight);
                for (var i = 0; i < weightBinary.Length; ++i)
                {
                    conMatrix.WeightsBinary[row * neuronsCount * ConnectionMatrix.WeightBitsPrecision + col * ConnectionMatrix.WeightBitsPrecision + i] = weightBinary[i];
                }
            }

            return conMatrix;
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
                    Label = $"{node.Id} - {node.ActivationFunction.Name}\nin:{node.InputSum:0.00}\nout:{node.Output:0.00}"
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
