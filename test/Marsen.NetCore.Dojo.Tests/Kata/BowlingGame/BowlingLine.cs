using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingLine
    {
        private List<Frame> _frames = new();

        public int? Calculate(List<int> fellPins)
        {
            _frames = new();
            var bonusCount = 0;
            for (int i = 0; i < fellPins.Count; i++)
            {
                var firstTry = fellPins[i];
                int? secondTry = i < fellPins.Count - 1 ? fellPins[i + 1] : null;

                if (bonusCount > 0)
                {
                    _frames.Last().SetBonus(firstTry);
                    bonusCount--;
                }

                if (firstTry != 10)
                {
                    _frames.Add(new Frame(firstTry, secondTry));
                    i++;
                    if (firstTry + secondTry == 10)
                    {
                        bonusCount = 1;
                    }
                }
                else
                {
                    _frames.Add(new Frame(firstTry));
                }
            }

            return NullableSum(_frames);
        }

        private int? NullableSum(List<Frame> frames)
        {
            int? result = null;
            foreach (var f in frames)
            {
                if (f.Score != null)
                {
                    result ??= 0;

                    result += f.Score;
                }
            }

            return result;
        }

        public List<Frame> FrameList => _frames;
    }
}