using Services;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ServiceTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_Fact()
        {
            var calculator = new Calculator();

            var result = calculator.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1, 3, 4)]
        [InlineData(-1, 3, 2)]
        public void Add_Theory_InlineData(int a, int b, int expectedResult)
        {
            var calculator = new Calculator();

            var actualResult = calculator.Add(a, b);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void Add_Theory_ClassData(int a, int b, int expectedResult)
        {
            var calculator = new Calculator();

            var actualResult = calculator.Add(a, b);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Add_Theory_MemberData(int a, int b, int expectedResult)
        {
            var calculator = new Calculator();

            var actualResult = calculator.Add(a, b);

            Assert.Equal(expectedResult, actualResult);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            return new List<object[]>
            {
                new object[] { 1, 4, 5 },
                new object[] { 2, 4, 6 },
                new object[] { 3, 6, 9 }
            };
        }
    }

    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 4, 5 };
            yield return new object[] { 2, 4, 6 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
