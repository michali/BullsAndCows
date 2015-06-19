namespace BullsAndCows.Web.Models
{
    public class GuessResult
    {
        public GuessResult(bool guessIsCorrect, string matches)
        {
            GuessIsCorrect = guessIsCorrect;
            Matches = matches;
        }

        public bool GuessIsCorrect { get; }
        public string Matches { get; }
    }
}