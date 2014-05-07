using System;
using System.IO;

namespace Pulsation.Solvers
{
    public interface IAsyncSolver
    {
        void BeginSolve(TextWriter writer);

        event EventHandler Solved;
    }
}