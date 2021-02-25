namespace BallingGameTests
{
    public class GeneralFrame : IFrame
    {
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public IFrame NextFrame { get; set; }
        public int Number { get; set; }

        public bool IsNextFrameAdding() => false;

        public int Score()
        {
            return FirstRoll + SecondRoll;
        }
    }
}