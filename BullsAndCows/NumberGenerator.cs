using System;

namespace BullsAndCows
{
    public class NumberGenerator
    {
        readonly Random _random = new Random();
        private const int NumberLength = 4;

        public string Generate()
        {
            string output = string.Empty;
            
            for (int i = 0; i < NumberLength; i++)
            {
                output += GetUniqueDigitFor(output);
            }

            return output;
        }

        private string GetUniqueDigitFor(string output)
        {
            var num = _random.Next(9).ToString();

            if (output.Contains(num))
            {
                return GetUniqueDigitFor(output);
            }

            return num;
        }
    }
}