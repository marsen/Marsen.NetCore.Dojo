using System.Collections.Generic;
using System.Linq;
using Marsen.NetCore.Dojo.Common;

namespace Marsen.NetCore.Dojo.Kata.BowlingGame
{
    public class BowlingLine
    {
        private List<int> _fellPins = new();
        public List<Frame> FrameList { get; private set; } = new();

        public int? Calculate(List<int> fellPins)
        {
            Initial(fellPins);
            for (var i = 0; i < _fellPins.Count; i++)
            {
                if (HasFrame()) SetBonus(i);
                FrameList.Add(new Frame(FirstTry(i), SecondTry(i)));
                if (IsStrike(i)) i++;
            }

            if (FrameList.Count>10)
            {
                throw new DojoException();
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
            foreach (var f in frames.Where(f => f.Score != null))
            {
                result ??= 0;
                result += f.Score;
            }
            return result;
        }
    }
}