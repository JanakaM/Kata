namespace BallingGameTests
{
    public interface IFrame
    {
        int FirstRoll { get; set; }
        int SecondRoll { get; set; }
        IFrame NextFrame { get; set; }
        bool IsNextFrameAdding();
        int Score();
    }
}