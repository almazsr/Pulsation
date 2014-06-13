using System;
using Calculation.Classes.Algorithms.Common.Matrixes;
using Calculation.Classes.Algorithms.TimeDependent;
using Calculation.Helpers;

namespace Calculation.Interfaces
{
    public class SolvedEventArgs : EventArgs
    {
        public bool Success { get; set; }

        public Exception Error { get; set; }
    }

    public delegate void SolvedEventHandler(object sender, SolvedEventArgs e);

    public interface IScheme1D
    {
        void FillMatrix(TriDiagMatrix matrix, SequenceBundle bundle, Grid grid, double t, double dt);
    }
}