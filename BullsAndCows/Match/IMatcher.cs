namespace BullsAndCows.Match
{
    public interface IMatcher
    {
        GuessMatches FindMatches(string guess);
    }
}