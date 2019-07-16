namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class Card
    {
        public int Rank { get; set; }
        public SuitEnum Suit { get; set; }
    }

    public enum SuitEnum
    {
        C,
        S,
        D,
        H
    }
}