using Calculation.Classes.Algorithms.TimeDependent;

namespace Calculation.Classes.Algorithms.Solvers
{
    public class PeriodicSchemeSolver<TData> : SchemeSolver<TData> where TData : class
    {
        protected override Data.Bundle CreateBundle(string name, object data)
        {
            return new PeriodicSequenceBundle(name, data);
        }
    }
}