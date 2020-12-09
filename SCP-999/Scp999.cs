namespace SCP_999
{
    public class Scp999
    {
        public string UserId { get; }
        public string PreviousRank { get; }

        public Scp999(string userId, string previousRank)
        {
            UserId = userId;
            PreviousRank = previousRank;
        }
    }
}
