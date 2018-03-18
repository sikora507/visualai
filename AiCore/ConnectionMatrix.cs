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
        public int[] Weights { get; set; }
        public bool[] ConnectionPresence { get; internal set; }
    }
}
