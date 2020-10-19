using GameOfLife;
using GameOfLife.GameOfLife;
using System;
using Xunit;

namespace GameOfLifeTests
{
    /// <summary>
    /// Tests cover Playground class
    /// </summary>
    public class Playground_Test
    {
        private IPlayground _sut;
        private int [,] _arrayForTest;
        public Playground_Test()
        {
            _sut = new Playground(10, 10);
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
            _sut.PlaygroundGrid = _arrayForTest;
        }

        /// <summary>
        /// Constructor check
        /// </summary>

        [Theory]
        [InlineData(1,1)]
        [InlineData(1,2)]
        [InlineData(2,1)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        public void PlaygroundConstructor_CreateArrayWithValuesLess1_ArgumentOutOfRangeException(int numberOfRous, int numberOfColumns)
        {

            Assert.Throws<ArgumentOutOfRangeException>( () =>  new Playground(numberOfRous, numberOfColumns));
            
        }

        /// <summary>
        /// Make sure the method return correct number of live poibts.
        /// </summary>
        [Fact]
        public void NumberOfLivePoints_CreateArrayOf4LivePoints_NumberOfLivePointsEqual4()
        {
            int numberOfLivePoints = _sut.GetNumberOfLivePoints();
            
            Assert.Equal(4,numberOfLivePoints);
        }

        /// <summary>
        /// Make sure the method return correct iteration number
        /// </summary>
        [Fact]
        public void NumberOfIteration_Do3Iterations_IterationNumberEqual3()
        {
            Assert.Equal(0, _sut.IterationNumber);

            _sut.Iteration();
            Assert.Equal(1, _sut.IterationNumber);

            _sut.Iteration();
            Assert.Equal(2, _sut.IterationNumber);

            _sut.Iteration();
            Assert.Equal(3, _sut.IterationNumber);
        }

        /// <summary>
        /// Make sure the method return correct arrey.
        /// </summary>
        [Fact]
        public void GetPlaygroundArray_SetArrayAndGetIt_ArraysAreEqual()
        {
            int [,] actualArray = _sut.GetPlaygroundArray();

            Assert.Equal(_arrayForTest, actualArray);
        }

        /// <summary>
        /// Steps:
        /// Do 1 Iteration.
        /// Compare Actual array and Expected array.
        /// </summary>
        [Fact]
        public void Iteration_DoOneIteration_ExpectedArrayEqualActualArray()
        {
            int [,] expectedArrayAfterIteration = new int[10, 10]  {
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
            _sut.Iteration();

            Assert.Equal(expectedArrayAfterIteration, _sut.PlaygroundGrid);
        }

    }
}