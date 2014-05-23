using Calculation.Interfaces;
using Calculation.UI.Models;

namespace Calculation.UI.Helpers
{
    public static class Convert
    {
         public static SolutionItemModel ToItemModel(this ISolution1D s)
         {
             var result = new SolutionItemModel
                        {
                            Id = (int)s.Key,
                            IsExact = s.IsExact,
                            IsTimeDependent = s.IsTimeDependent,
                            State = s.State,
                            Started = s.StartedAt,
                            SolverType = s.Solver,
                            PhysicalData = s.PhysicalData,
                            Grid = string.Format(GridFormatTemplate, s.Grid.Min, s.Grid.Max, s.Grid.N, s.Grid.h),
                            TimeData = string.Format(TimeDataFormatTemplate, s.tCurrent, s.Nt, s.dt),    
                            Selected = false            
                        };
             result.Name = string.Format("{0:ddMMyyyy_hhmmss}{1}{2}{3}{4}", result.Started, result.PhysicalData, result.Grid,
                                         result.TimeData,
                                         result.SolverType);
             return result;
         }

        public const string GridFormatTemplate = "[{0},{1}](N={2})(d={3})";
        public const string TimeDataFormatTemplate = "[{0}](N={1})(d={2})";
    }
}