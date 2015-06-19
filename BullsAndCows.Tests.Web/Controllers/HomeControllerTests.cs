using System.Web.Mvc;
using System.Xml.Serialization;
using BullsAndCows.Web.Controllers;
using BullsAndCows.Web.Models;
using Moq;
using Xunit;

namespace BullsAndCows.Tests.Web.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void TakeGuess_WhenComparedGuessWithSecret_ReportToView()
        {
            var controller = CreateHomeControllerWithExpectedMatches(It.IsAny<string>(), 0);

            var result = Assert.IsType<PartialViewResult>(controller.TakeGuess(new Guess ()));
            var model = (GuessResult) result.Model;

            Assert.Equal($"bulls {0}, cows {0}", model.Matches);
        }

        [Fact]
        public void TakeGuess_WhenNotFullyGuessed_SignalThis()
        {
            var guessInput = string.Empty;
            var controller = CreateHomeControllerWithExpectedMatches(guessInput, 0);

            var result = Assert.IsType<PartialViewResult>(controller.TakeGuess(new Guess() { Input = guessInput }));
            var model = (GuessResult)result.Model;

            Assert.False(model.GuessIsCorrect);
        }

        [Fact]
        public void TakeGuess_WhenFullyGuessed_SignalThis()
        {
            var guessInput = string.Empty;
            var controller = CreateHomeControllerWithExpectedMatches(guessInput, 4);

            var result = Assert.IsType<PartialViewResult>(controller.TakeGuess(new Guess { Input = guessInput }));
            var model = (GuessResult)result.Model;

            Assert.True(model.GuessIsCorrect);
        }

        [Fact]
        public void TakeGuess_WhenGuessing_GetMatchesByInput()
        {
            const string input = "1234";
            var controller = CreateHomeControllerWithExpectedMatches(input, 1, 2);

            var result = (PartialViewResult)controller.TakeGuess(new Guess {Input = input});
            var model = (GuessResult)result.Model;

            Assert.Equal("bulls 1, cows 2", model.Matches);
        }

        private static HomeController CreateHomeControllerWithExpectedMatches(string input, int expectedBulls, int expectedCows = 0)
        {
            var guessMatches = new GuessMatches(expectedBulls, expectedCows);
            var matcher = new Mock<IMatcher>();
            matcher.Setup(x => x.FindMatches(input)).Returns(guessMatches);
            var controller = new HomeController(matcher.Object);
            return controller;
        }
    }
}