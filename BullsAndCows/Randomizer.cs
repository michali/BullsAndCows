using System;

namespace BullsAndCows
{
    public class Randomizer : IRandomizer
    {
        private readonly Random _random = new Random();

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}