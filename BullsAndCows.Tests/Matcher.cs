using System.Linq;
using Moq;
using Xunit;

namespace BullsAndCows.Tests
{
    public class MatcherTests
    {
        [Fact]
        public void FindMatches_WhenNoMatches_ShouldReturnNoBullsNoCows()
        {
            var repository = new Mock<IRepository>();
            repository.Setup(x => x.GetSecretNumber()).Returns("1234");
            var matcher = new Matcher(repository.Object);

            var matches = matcher.FindMatches("6789");

            Assert.Equal(0, matches.Bulls);
            Assert.Equal(0, matches.Cows);
        }

        [Fact]
        public void FindMatches_WhenOneMatchAnywhereButSamePosition_ReportOneCow()
        {
            var repository = new Mock<IRepository>();
            repository.Setup(x => x.GetSecretNumber()).Returns("1234");
            var matcher = new Matcher(repository.Object);

            var matches = matcher.FindMatches("6178");

            Assert.Equal(1, matches.Cows);
        }

        [Fact]
        public void FindMatches_WhenTwoMatchesAnywhereButSamePosition_ReportTwoCows()
        {
            var repository = new Mock<IRepository>();
            repository.Setup(x => x.GetSecretNumber()).Returns("1234");
            var matcher = new Matcher(repository.Object);

            var matches = matcher.FindMatches("6128");

            Assert.Equal(2, matches.Cows);
        }
    }

    public class Matcher
    {
        private readonly IRepository _repository;

        public Matcher(IRepository repository)
        {
            _repository = repository;
        }

        public GuessMatches FindMatches(string guess)
        {
            var secretNumber = _repository.GetSecretNumber();

            int cowCount = guess.Sum(guessDigit => secretNumber.Count(secretDigit => guessDigit == secretDigit));

            return new GuessMatches(0, cowCount);
        }
    }

    public struct GuessMatches
    {
        public GuessMatches(int bulls, int cows)
        {
            Bulls = bulls;
            Cows = cows;
        }

        public int Bulls { get; }
        public int Cows { get; }
    }

    public interface IRepository
    {
        string GetSecretNumber();
    }
}