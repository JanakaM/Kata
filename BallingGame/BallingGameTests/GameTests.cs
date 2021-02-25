using System;
using System.Collections.Generic;
using BallingGame;
using Xunit;

namespace BallingGameTests
{
    public class GameTests
    {
        private readonly Game _sut;
        private List<IFrame> _frames = new List<IFrame>();
        
        public GameTests()
        {
            _sut  = new Game();
        }
        
        [Fact]
        public void Given_FrameWithRolls_ReturnTotalScore()
        {
            _sut.Frames = CreateFrames(10, 3,3);

            var total = _sut.CalculateTotal();
            
            Assert.Equal(60, total);
        } 
        
        [Fact]
        public void Given_SpareFrameWithRolls_ReturnTotalScore()
        {
            _frames.Add(new SpareFrame() {FirstRoll = 6 , SecondRoll = 4});
            _frames.Add(new GeneralFrame(){ FirstRoll = 8, SecondRoll = 1});
            
            _sut.Frames = _frames;

            var total = _sut.CalculateTotal();
            
            Assert.Equal(27, total);
        } 
       
        [Theory]
        [InlineData(10, 0)]
        [InlineData(0, 10)]
        public void Given_StrikeFrameWithRolls_ReturnTotalScore(int first, int second)
        {
            _frames.Add(new StrikeFrame() {FirstRoll = first , SecondRoll = second});
            _frames.Add(new GeneralFrame(){ FirstRoll = 7, SecondRoll = 1});
            
            _sut.Frames = _frames;

            var total = _sut.CalculateTotal();
            
            Assert.Equal(26, total);
        } 
        
        [Fact]
        public void Given_SpareFrameWithRollsAndOtherFrames_ReturnTotalScore()
        {
            _frames.Add(new SpareFrame() {FirstRoll = 6 , SecondRoll = 4});
            _frames.Add(new GeneralFrame(){ FirstRoll = 8, SecondRoll = 1});
            _sut.Frames = _frames;

            CreateFrames(8, 3, 3);

            var total = _sut.CalculateTotal();
            
            Assert.Equal(75, total);
        } 
        
        [Fact]
        public void Given_StrikeFrameWithRollsAndOtherFrames_ReturnTotalScore()
        {
            _frames.Add(new StrikeFrame() {FirstRoll = 10 , SecondRoll = 0});
            _frames.Add(new GeneralFrame(){ FirstRoll = 7, SecondRoll = 1});
            _sut.Frames = _frames;
             CreateFrames(8, 3, 3);

            var total = _sut.CalculateTotal();
            
            Assert.Equal(74, total);
        } 
        
        [Fact]
        public void Given_FinalFrameWithBonusRolls_ReturnTotalScore()
        {
            var otherFrames = CreateFrames(9, 3, 3);

            otherFrames.AddRange(new List<IFrame>()
            {
                new FinalFrame()
                {
                    FirstRoll = 10,
                    SecondRoll = 10,
                    BonusRoll = 10
                }
            });

            _sut.Frames = otherFrames;
            
            var total = _sut.CalculateTotal();
            
            Assert.Equal(84, total);
        } 

        private List<IFrame> CreateFrames(int count, int first, int second)
        {
            for (var i = 0; i < count; i++)
            {
                _frames.Add(new GeneralFrame(){
                    Number = i,
                    FirstRoll = first,
                    SecondRoll = second});
            }

            return _frames;
        }

    }
}