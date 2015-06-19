using System.Linq;
using BullsAndCows.Data;

namespace BullsAndCows.Match
{
    public class Matcher : IMatcher
    {
        private readonly ISecretCodeRepository _secretCodeRepository;

        public Matcher(ISecretCodeRepository secretCodeRepository)
        {
            _secretCodeRepository = secretCodeRepository;
        }

        public GuessMatches FindMatches(string guess)
        {
            var secretCode = _secretCodeRepository.Get();

            var cowCount = 0;

            for (int i = 0; i < Keys.CodeLength; i++)
            {
                if (secretCode.Contains(guess[i]) && guess[i] != secretCode[i])
                {
                    cowCount ++;
                }
            }
            
            var bullCount = 0;

            for (int i = 0; i < Keys.CodeLength; i ++)
            {
                if (guess[i] == secretCode[i])
                {
                    bullCount++;
                }
            }
            
            return new GuessMatches(bullCount, cowCount);
        }
    }
}