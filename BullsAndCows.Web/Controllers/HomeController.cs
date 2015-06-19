using System.Collections.Generic;
using System.Web.Mvc;
using BullsAndCows.Data;
using BullsAndCows.Match;
using BullsAndCows.SecretCode;
using BullsAndCows.Web.Models;

namespace BullsAndCows.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMatcher _matcher;
        private readonly ISecretCodeGenerator _secretCodeGenerator;
        private readonly ISecretCodeRepository _secretCodeRepository;

        public HomeController(IMatcher matcher, 
            ISecretCodeGenerator secretCodeGenerator,
            ISecretCodeRepository secretCodeRepository)
        {
            _matcher = matcher;
            _secretCodeGenerator = secretCodeGenerator;
            _secretCodeRepository = secretCodeRepository;
        }

        public ActionResult Index()
        {
            _secretCodeRepository.Add(_secretCodeGenerator.Generate());
            
            return View(new Guess());
        }

        [HttpPost]
        public ActionResult TakeGuess(Guess guess)
        {
            var matches = _matcher.FindMatches(guess.Input);
            var guessResult = new GuessResult(matches.Bulls == Keys.CodeLength, matches.ToString());
            
            return PartialView("_PastGuesses", guessResult);
        }
    }
}