using System;

namespace Calculation.Exceptions
{
    public class BundleWithoutGridException : Exception
    {
        public override string Message
        {
            get { return "Bundle without grid."; }
        }
    }
}