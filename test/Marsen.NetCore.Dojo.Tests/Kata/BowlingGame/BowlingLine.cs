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

                if (_frames.Any() && _frames.Last().BonusCount > 0)
                {
                    _frames.Last().SetBonus(firstTry);
                    //bonusCount--;
                }

                if (firstTry == 10)
                {
                    _frames.Add(new Frame(firstTry));
                }
                else
                {
                    var frame = new Frame(firstTry, secondTry);
                    if (firstTry + secondTry == 10)
                    {
                        frame.Spare();
                        //bonusCount = 1;
                    }

                    _frames.Add(frame);
                    i++;
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