using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingLine
    {
        public int? Calculate(List<int> fellPins)
        {
            var frames = new List<Frame>();
            var hasBonus = false;
            for (int i = 0; i < fellPins.Count; i++)
            {
                var firstTry = fellPins[i];
                int? secondTry = i < fellPins.Count - 1 ? fellPins[i + 1] : null;

                if (hasBonus)
                {
                    frames.Last().SetBonus(firstTry);
                    hasBonus = false;
                }

                if (firstTry != 10)
                {
                    frames.Add(new Frame(firstTry, secondTry));
                    if (firstTry + secondTry == 10)
                    {
                        hasBonus = true;
                        i++;
                    }
                }
            }

            return NullableSum(frames);
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
    }
}