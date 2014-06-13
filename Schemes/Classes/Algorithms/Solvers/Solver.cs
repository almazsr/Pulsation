using System;
using Calculation.Classes.Data;
using Calculation.Interfaces;

namespace Calculation.Classes.Algorithms.Solvers
{
    public class Solver
    {
        public virtual string GetLayerName(Bundle bundle, int number)
        {
            return number.ToString("0");
        }

        protected virtual Bundle CreateBundle(string name, object data)
        {
            return new Bundle(name, data);
        }

        protected virtual void OnSolved(Bundle bundle, bool success, Exception error = null)
        {
            bundle.EndEdit(success);
            if (Solved != null)
            {
                Solved(this, new SolvedEventArgs { Success = success, Error = error });
            }
        }

        public event SolvedEventHandler Solved; 
    }
}