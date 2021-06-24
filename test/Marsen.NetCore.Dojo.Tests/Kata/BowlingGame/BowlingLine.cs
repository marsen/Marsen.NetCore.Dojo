using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingLine
    {
        public List<Frame> FrameList { get; private set; } = new();

        public int? Calculate(List<int> fellPins)
        {
            FrameList = new List<Frame>();
            for (var i = 0; i < fellPins.Count; i++)
            {
                var firstTry = fellPins[i];
                int? secondTry =
                    i < fellPins.Count - 1 ? fellPins[i + 1] : null;

                if (FrameList.Any()) FrameList.Last().SetBonus(firstTry, secondTry);

                secondTry = firstTry == 10 ? null : secondTry;
                var frame = new Frame(firstTry, secondTry);
                if (firstTry != 10)
                {
                    i++;
                }

                FrameList.Add(frame);
            }

            return NullableSum(FrameList);
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