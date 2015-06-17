using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BullsAndCows.Tests
{
    public class NumberGeneratorTests
    {
        [Fact]
        public void GenerateNumber_GeneratesANumber4DigitsLong()
        {
            var numberGenerator = new NumberGenerator();

            var number = numberGenerator.Generate();

            Assert.Equal(4, number.Length);
        }

        [Fact]
        public void GenerateNumber_WhenGenerates_AllDigitsShouldBeDifferent()
        {
            var numberGenerator = new NumberGenerator();

            var number = numberGenerator.Generate();

            Assert.True(number.AllCharsUnique());
        }

        [Fact]
        public void GenerateNumber_WhenGenerates_ZeroIsNotInDigits()
        {
            var numberGenerator = new NumberGenerator();

            var number = numberGenerator.Generate();

            Assert.DoesNotContain("0", number);
        }
    }
}