using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore.Tools
{
    public class BinaryCalculator
    {
        public int[] ToBinary(double toConvert, int precision, double min, double max)
        {
            var result = new int[precision];
            if (toConvert >= max)
            {
                for (int i = 0; i < result.Length; i++)
                    result[i] = 1;
                return result;
            }
            else if (toConvert <= min)
            {
                for (int i = 0; i < result.Length; i++)
                    result[i] = 0;
                return result;
            }

            //var step = (max - min) / (Math.Pow(2, precision) - 1);
            var maxBinaryValue = (Math.Pow(2, precision) - 1);

            var scaledValueToEncode = Math.Ceiling((toConvert - min) / (max - min) * maxBinaryValue);

            for (int i = 0; i < precision; i++)
            {
                int rem = (int)(scaledValueToEncode % 2);
                scaledValueToEncode = Math.Floor(scaledValueToEncode / 2);
                result[result.Length - 1 - i] = rem;
            };

            return result;
        }

        public double ToDecimal(int[] toConvert, double min, double max)
        {
            double binaryResult = 0;
            var maxBinaryValue = (Math.Pow(2, toConvert.Length) - 1);

            for (int i = 0; i < toConvert.Length; i++)
            {
                binaryResult += (toConvert[i] > 0 ? 1 : 0) * Math.Pow(2, toConvert.Length - 1 - i);
            }
            var normalizedValue = binaryResult / maxBinaryValue;
            var result = normalizedValue * (max - min) + min;
            return result;
        }
    }
}
