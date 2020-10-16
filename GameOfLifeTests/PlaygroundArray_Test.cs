using GameOfLife.GameOfLife;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameOfLifeTests
{
    public class PlaygroundArray_Test
    {
        private int[,] _arrayForTest;
        public PlaygroundArray_Test()
        {
            _arrayForTest = new int[10, 10]  {
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  1,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  1,  1,  1,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
            };
        }

        [Fact]
        public void GetNumberOfLivingPlaygrounds_OnePlaygroundBacomeNullable_Ture()
        {
            IPlaygroundArray playgrounds = new PlaygroundArray(10, 10, 5);
            int[,] zerroArray = new int[10,10]{
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
            };

            for (int i = 0; i < playgrounds.NumberOfArrays; i++)
            {
                playgrounds.playgroundArray[i].PlaygriundGrid = _arrayForTest;
            }

            Assert.Equal(5, playgrounds.GetNumberOfLivingPlaygrounds());

            playgrounds.playgroundArray[0].PlaygriundGrid = zerroArray;
            Assert.Equal(4, playgrounds.GetNumberOfLivingPlaygrounds());

        }

    }
}
