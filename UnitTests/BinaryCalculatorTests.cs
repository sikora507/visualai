using AiCore.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class BinaryCalculatorTests
    {
        public class CalculatorTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // -20 is 0 in binary
                yield return new object[] { -20, 8, -20, 20, new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 } };
                // 20 is 255 in binary
                yield return new object[] { 20, 8, -20, 20, new int[8] { 1, 1, 1, 1, 1, 1, 1, 1 } };
                // -19.9 is 1 in binary
                yield return new object[] { -19.9, 8, -20, 20, new int[8] { 0, 0, 0, 0, 0, 0, 0, 1 } };
                // 19.8 is 254 in binary
                yield return new object[] { 19.8, 8, -20, 20, new int[8] { 1, 1, 1, 1, 1, 1, 1, 0 } };
                // 0 is 128 in binary
                yield return new object[] { 0, 8, -20, 20, new int[8] { 1, 0, 0, 0, 0, 0, 0, 0 } };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class ToDecimalTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 }, -20, 20, -20, };
                yield return new object[] { new int[8] { 1, 1, 1, 1, 1, 1, 1, 1 }, -20, 20, 20, };
                yield return new object[] { new int[8] { 0, 1, 1, 1, 1, 1, 1, 1 }, -20, 20, -0.1, };
                yield return new object[] { new int[8] { 1, 0, 0, 0, 0, 0, 0, 0 }, -20, 20, 0, };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void DecimalToBinaryTest(double toConvert, int precision, double min, double max, int[] expectedResult)
        {
            // arrange

            // act
            var output = BinaryCalculator.ToBinary(toConvert, precision, min, max);

            // assert
            Assert.Equal(expectedResult.Length, output.Length);
            Assert.Equal(expectedResult, output);
        }

        [Theory]
        [ClassData(typeof(ToDecimalTestData))]
        public void BinaryToDecimalTest(int[] binary, double min, double max, double expectedResult)
        {
            // arrange

            // act
            var output = BinaryCalculator.ToDecimal(binary, min, max);
            // assert
            Assert.True(Math.Abs(expectedResult - output) < 0.1);
        }
    }
}
