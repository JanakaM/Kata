using BallingGameTests;

namespace BallingGame
{
    public class FinalFrame : IFrame, IFinalFrame
    {
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public int BonusRoll { get; set; }
        public int Number { get; set; }
        public IFrame NextFrame { get; set; }
        public bool IsNextFrameAdding() => false;
        public int Score()
        {
            return FirstRoll + SecondRoll + BonusRoll;
        }
    }
}