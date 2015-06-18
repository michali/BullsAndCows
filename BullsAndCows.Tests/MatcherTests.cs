using System;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace BullsAndCows.Tests
{
    public class MatcherTests
    {
        private static Matcher CreateMatcherWithSecretCode(string secretCode)
        {
            var repository = new Mock<IRepository>();
            repository.Setup(x => x.GetSecretCode()).Returns(secretCode);
            var matcher = new Matcher(repository.Object);
            return matcher;
        }

        [Theory]
        [InlineData("1234", "5432", 1, 2)]
        [InlineData("1234", "1234", 4, 0)]
        [InlineData("1234", "4321", 0, 4)]
        [InlineData("1234", "6789", 0, 0)]
        public void FindMatches_WhenMatches_ReportsCorrectNumberOfBullsAndCows(string secretCode, 
            string guess, 
            int expectedBulls, 
            int expectedCows)
        {
            var matcher = CreateMatcherWithSecretCode(secretCode);

            var matches = matcher.FindMatches(guess);

            Assert.Equal(expectedBulls, matches.Bulls);
            Assert.Equal(expectedCows, matches.Cows);
        }
    }
}