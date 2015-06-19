namespace BullsAndCows.Data
{
    public interface ISecretCodeRepository
    {
        string Get();
        void Add(string secretCode);
    }
}