using Calculation.Classes.Data;
using Calculation.Exceptions;
using Calculation.Helpers;

namespace Calculation.Classes.Algorithms.Common.Extensions
{
    public static class GridBundleExtensions
    {
        public static Grid GetGrid(this Bundle bundle)
        {
            int N = bundle.Parameter<int>("GridN");
            double min = bundle.Parameter<double>("GridMin");
            double max = bundle.Parameter<double>("GridMax");
            var grid = Grid.Create(min, max, N);
            if (grid == null) throw new BundleWithoutGridException();
            return grid;
        }
    }
}