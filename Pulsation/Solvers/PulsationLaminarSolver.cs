using System;
using System.IO;
using Pulsation.Models;

namespace Pulsation.Solvers
{
    public abstract class PulsationLaminarSolver : IAsyncSolver
    {       
        public PulsationLaminarPhysicalData PhysicalData { get; set; }

        public PulsationLaminarCalculationData CalculationData { get; set; }        

        public abstract void BeginSolve(TextWriter writer);

        protected virtual void OnSolved()
        {
            if (Solved != null)
            {
                Solved(this, new EventArgs());
            }
        }

        public event EventHandler Solved;
    }
}