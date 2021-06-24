using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingLine
    {
        public List<Frame> FrameList { get; private set; } = new();

        private List<int> _fellPins = new();

        public int? Calculate(List<int> fellPins)
        {
            Initial(fellPins);
            for (var i = 0; i < _fellPins.Count; i++)
            {
                if (HasFrame()) SetBonus(i);
                FrameList.Add(new Frame(FirstTry(i), SecondTry(i)));
                if (IsStrike(i)) i++;
            }

            return NullableSum(FrameList);
        }

        private void Initial(List<int> fellPins)
        {
            FrameList = new List<Frame>();
            _fellPins = fellPins;
        }

        private bool HasFrame()
        {
            return FrameList.Any();
        }

        private void SetBonus(int i)
        {
            FrameList.Last().SetBonus(FirstTry(i), SecondTry(i));
        }

        private bool IsStrike(int i)
        {
            return FirstTry(i) != 10;
        }

        private int? SecondTry(int i)
        {
            return i < _fellPins.Count - 1 ? _fellPins[i + 1] : null;
        }

        private int FirstTry(int i)
        {
            return _fellPins[i];
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