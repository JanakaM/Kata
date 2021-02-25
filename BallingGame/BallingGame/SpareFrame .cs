using BallingGameTests;

namespace BallingGame
{
    public class SpareFrame : IFrame
    {
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public int Number { get; set; }
        public IFrame NextFrame { get; set; }
        public bool IsNextFrameAdding() => (FirstRoll + SecondRoll == 10);

        public int Score()
        {
            return 10 + NextFrame.FirstRoll;
        }
    }
}