using System.Web.Mvc;
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
            var controller = CreateHomeControllerWithExpectedMatches(string.Empty, 0, 0);

            var result = Assert.IsType<PartialViewResult>(controller.TakeGuess(new Guess ()));

            Assert.Equal($"bulls {0}, cows {0}", result.Model);
        }

        [Fact]
        public void TakeGuess_WhenGuessing_GetMatchesByInput()
        {
            var input = "1234";
            var controller = CreateHomeControllerWithExpectedMatches(input, 1, 2);

            var result = (PartialViewResult)controller.TakeGuess(new Guess {Input = input});

            Assert.Equal("bulls 1, cows 2", result.Model);
        }

        private static HomeController CreateHomeControllerWithExpectedMatches(string input, int expectedBulls, int expectedCows)
        {
            var guessMatches = new GuessMatches(expectedBulls, expectedCows);
            var matcher = new Mock<IMatcher>();
            matcher.Setup(x => x.FindMatches(input)).Returns(guessMatches);
            var controller = new HomeController(matcher.Object);
            return controller;
        }
    }
}