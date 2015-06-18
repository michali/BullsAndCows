namespace BullsAndCows
{
    public class NumberGenerator
    {
        private readonly IRandomizer _randomizer;

        public NumberGenerator(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        private const int NumberLength = 4;

        public string Generate()
        {
            string output = string.Empty;
            
            for (int i = 0; i < NumberLength; i++)
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