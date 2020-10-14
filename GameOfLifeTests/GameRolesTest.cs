using GameOfLife.GameOfLife;
using System;
using Xunit;

namespace GameOfLifeTests
{
    /// <summary>
    /// Tests for class GameGoles. Checks that the game roles are followed.
    /// </summary>
    public class GameRolesTest
    {
        private readonly IGameRoles _sut;
        public GameRolesTest()
        {
            _sut = new GameRoles();
        }

        /// <summary>
        /// Steps:
        /// Create playground array (array of int).
        /// Create playground array after 1 iteration (array of int).
        /// Do one iteration with first array.
        /// Expected: arrays are equal
        /// </summary>
        [Fact]
        public void DoGameOfLifeIteration_ExpectedAndActualArraysAraEqual()
        {
            int[,] arrayForIteration = new int[10, 10]  {
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
            int[,] expectedArray = new int[10, 10]  {
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  1,  1,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  1,  1,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  1,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
            };

            
            arrayForIteration = _sut.DoGameOfLifeIteration(arrayForIteration, 
                                                           arrayForIteration.GetLength(0), 
                                                           arrayForIteration.GetLength(1));

            Assert.Equal(arrayForIteration, expectedArray);
        }

    }
}
