using System;

namespace Calculation.Exceptions
{
    public class BundleNotInEditModeException : Exception
    {
        public override string Message
        {
            get { return "Bundle not in edit mode."; }
        }
    }
}