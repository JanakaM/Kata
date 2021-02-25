using System;
using BallingGame;
using Xunit;


namespace BallingGameTests
{
    public class FrameTests
    {
        [Fact]
        public void GivenFrameWithTwoTryScore_ReturnScore()
        {
            var sut = new GeneralFrame
            {
                FirstRoll = 4,
                SecondRoll = 5
            };
            var score = sut.Score();
            Assert.Equal(9, score);
        }
        
        [Fact]
        public void GivenStrikeFrameWithTwoTryScore_ReturnScore()
        {
            var sut = new StrikeFrame()
            {
                FirstRoll = 10,
                NextFrame = new GeneralFrame()
                {
                    FirstRoll = 7,
                    SecondRoll = 1
                }
            };
            var score = sut.Score();
            Assert.Equal(18, score);
        }
        
        [Fact]
        public void GivenSpareFrameWithTwoTryScore_ReturnScore()
        {
            var sut = new SpareFrame()
            {
                FirstRoll = 8,
                SecondRoll = 2,
                NextFrame = new GeneralFrame()
                {
                    FirstRoll = 7,
                    SecondRoll = 1
                }
            };
            var score = sut.Score();
            Assert.Equal(17, score);
        }
        
        [Fact]
        public void GivenFinalFrameWithTwoTryScore_ReturnScore()
        {
            var sut = new FinalFrame
            {
                FirstRoll = 10,
                SecondRoll = 10,
                BonusRoll = 10
            };
            var score = sut.Score();
            Assert.Equal(30, score);
        }
    }
}