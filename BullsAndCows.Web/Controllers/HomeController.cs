using System.Collections.Generic;
using System.Web.Mvc;
using BullsAndCows.Web.Models;

namespace BullsAndCows.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Guess());
        }

        [HttpPost]
        public ActionResult TakeGuess(Guess guess)
        {
            return PartialView("_PastGuesses", guess.Input);
        }
    }
}