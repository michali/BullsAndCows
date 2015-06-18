using System.Linq;

namespace BullsAndCows
{
    public class Matcher : IMatcher
    {
        private const int AllowedLength = 4;
        private readonly IRepository _repository;

        public Matcher(IRepository repository)
        {
            _repository = repository;
        }

        public GuessMatches FindMatches(string guess)
        {
            var secretCode = _repository.GetSecretCode();

            var cowCount = 0;

            for (int i = 0; i < AllowedLength; i++)
            {
                if (secretCode.Contains(guess[i]) && guess[i] != secretCode[i])
                {
                    cowCount ++;
                }
            }
            
            var bullCount = 0;

            for (int i = 0; i < AllowedLength; i ++)
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