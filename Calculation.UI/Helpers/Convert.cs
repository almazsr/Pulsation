using Calculation.Interfaces;
using Calculation.UI.Models;

namespace Calculation.UI.Helpers
{
    public static class Convert
    {
         public static SolutionItemModel ToItemModel(this ISolution1D s)
         {
             return new SolutionItemModel
                        {
                            Key = s.Key,
                            IsExact = s.IsExact,
                            IsTimeDependent = s.IsTimeDependent,
                            State = s.State,
                            Started = s.Started,
                            SolverType = s.Solver,
                            PhysicalData = s.PhysicalData,
                            Grid = string.Format(GridFormatTemplate, s.Grid.Min, s.Grid.Max, s.Grid.N, s.Grid.h),
                            TimeData = string.Format(TimeDataFormatTemplate, s.tCurrent, s.Nt, s.dt),    
                            Selected = false            
                        };
         }

        public const string GridFormatTemplate = "[{0},{1}](N={2})(d={3})";
        public const string TimeDataFormatTemplate = "[{0}](N={1})(d={2})";
    }
}