using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Xunit;

namespace BullsAndCows.Tests
{
    public class NumberGeneratorTests
    {
        [Fact]
        public void GenerateNumber_GeneratesANumber4DigitsLong()
        {
            var numberGenerator = CreateNumberGeneratorWithExpectedNumberSequence(1,2,3,4);

            var number = numberGenerator.Generate();

            Assert.Equal("1234", number);
        }

        private static NumberGenerator CreateNumberGeneratorWithExpectedNumberSequence(params int[] numbers)
        {
            var randomizer = new Mock<IRandomizer>();
            var numberQueue = new Queue<int>();

            foreach (var number in numbers)
            {
                numberQueue.Enqueue(number);
            }

            randomizer.Setup(x => x.Next(It.IsAny<int>())).Returns(numberQueue.Dequeue);
            var numberGenerator = new NumberGenerator(randomizer.Object);
            return numberGenerator;
        }

        [Fact]
        public void GenerateNumber_WhenGenerates_AllDigitsShouldBeDifferent()
        {
            var numberGenerator = CreateNumberGeneratorWithExpectedNumberSequence(1, 2, 3, 1, 4);

            var number = numberGenerator.Generate();

            Assert.Equal("1234", number);
        }

        [Fact]
        public void GenerateNumber_WhenGenerates_ZeroIsNotInDigits()
        {
            var numberGenerator = CreateNumberGeneratorWithExpectedNumberSequence(1, 2, 3, 0, 4);

            var number = numberGenerator.Generate();

            Assert.Equal("1234", number);
        }
    }
}