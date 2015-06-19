namespace BullsAndCows.Random
{
    public class Randomizer : IRandomizer
    {
        private readonly System.Random _random = new System.Random();

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}