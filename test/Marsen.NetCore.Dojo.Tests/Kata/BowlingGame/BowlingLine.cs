using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingLine
    {
        public List<Frame> FrameList { get; private set; } = new();

        private List<int> FellPins = new();

        public int? Calculate(List<int> fellPins)
        {
            FrameList = new List<Frame>();
            FellPins = fellPins;
            for (var i = 0; i < FellPins.Count; i++)
            {
                var secondTry = SecondTry(i);
                if (FrameList.Any()) FrameList.Last().SetBonus(FirstTry(i), secondTry);
                FrameList.Add(new Frame(FirstTry(i), secondTry));
                if (FirstTry(i) != 10) i++;
            }

            return NullableSum(FrameList);
        }

        private int? SecondTry(int i)
        {
            return i < FellPins.Count - 1 ? FellPins[i + 1] : null;
        }

        private int FirstTry(int i)
        {
            return FellPins[i];
        }

        private int? NullableSum(List<Frame> frames)
        {
            int? result = null;
            foreach (var f in frames)
                if (f.Score != null)
                {
                    result ??= 0;
                    result += f.Score;
                }

            return result;
        }
    }
}