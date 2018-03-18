using AiCore.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore
{
    public class ConnectionMatrix
    {
        public static readonly double MaxWeight = 20.0;
        public static readonly double MinWeight = -20.0;
        public static readonly int WeightBitsPrecision = 8;

        // 3 "chromosomes"
        public string[] ActiFunctions { get; set; }
        public int[] WeightsBinary { get; set; }
        public bool[] ConnectionPresence { get; set; }

        // just for debug / preview
        // does not take part in crossover / mutation
        public double[] WeightsDecimal
        {
            get
            {
                var neuronsCount = ActiFunctions.Length;
                var result = new double[neuronsCount * neuronsCount];
                var binaryBuffer = new int[WeightBitsPrecision];
                for (int row = 0; row < neuronsCount; row++)
                {
                    for (int column = 0; column < neuronsCount; column++)
                    {
                        Array.Copy(WeightsBinary, row * neuronsCount * WeightBitsPrecision + column * WeightBitsPrecision, binaryBuffer, 0, WeightBitsPrecision);
                        var decimalValue = BinaryCalculator.ToDecimal(binaryBuffer, MinWeight, MaxWeight);
                        result[row * neuronsCount + column] = decimalValue;
                    }
                }
                return result;
            }
        }
    }
}
