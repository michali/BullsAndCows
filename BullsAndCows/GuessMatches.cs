namespace BullsAndCows
{
    public struct GuessMatches
    {
        public GuessMatches(int bulls, int cows)
        {
            Bulls = bulls;
            Cows = cows;
        }

        public int Bulls { get; }
        public int Cows { get; }

        public override string ToString()
        {
            return $"bulls {Bulls}, cows {Cows}";
        }
    }
}