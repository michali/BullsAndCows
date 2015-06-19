using BullsAndCows.Random;

namespace BullsAndCows.SecretCode
{
    public class SecretCodeGenerator : ISecretCodeGenerator
    {
        private readonly IRandomizer _randomizer;

        public SecretCodeGenerator(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public string Generate()
        {
            string output = string.Empty;
            
            for (int i = 0; i < Keys.CodeLength; i++)
            {
                output += GetUniqueNonZeroDigitFor(output);
            }

            return output;
        }

        private string GetUniqueNonZeroDigitFor(string output)
        {
            var num = _randomizer.Next(9).ToString();

            if (output.Contains(num) || num == "0")
            {
                return GetUniqueNonZeroDigitFor(output);
            }

            return num;
        }
    }
}