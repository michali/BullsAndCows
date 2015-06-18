namespace BullsAndCows
{
    public interface IMatcher
    {
        GuessMatches FindMatches(string guess);
    }
}