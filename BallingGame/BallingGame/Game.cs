using System.Collections.Generic;
using BallingGameTests;

namespace BallingGame
{
    public class Game
    {
        public List<IFrame> Frames  {get; set;}

        public Game()
        {
            Frames = new List<IFrame>();
        }

        public object CalculateTotal()
        {
            var total = 0;
            for (var i = 0; i < Frames.Count; i++)
            {
                GetNextFrame(i);
                total += Frames[i].Score();
            }

            return total;
        }

        private void GetNextFrame(int i)
        {
            if (Frames[i].IsNextFrameAdding())
            {
                Frames[i].NextFrame = Frames[i + 1];
            }
        }
    }
}