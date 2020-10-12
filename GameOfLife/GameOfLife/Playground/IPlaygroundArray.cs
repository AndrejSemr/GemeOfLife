using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GameOfLife
{
    public interface IPlaygroundArray
    {
        public Playground[] playgroundArray { get; set; }
        public int NumberOfArrays { get; set; }

        public int GetNumberOfLivingPlaygrounds();
    }
}
