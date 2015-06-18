using System.Collections.Generic;
using System.Web.Mvc;
using BullsAndCows.Web.Models;

namespace BullsAndCows.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMatcher _matcher;

        public HomeController(IMatcher matcher)
        {
            _matcher = matcher;
        }

        public ActionResult Index()
        {
            return View(new Guess());
        }

        [HttpPost]
        public ActionResult TakeGuess(Guess guess)
        {
            var matches = _matcher.FindMatches(guess.Input);
            
            return PartialView("_PastGuesses", matches.ToString());
        }
    }
}