using System;

namespace Calculation.Exceptions
{
    public class CalculationException : Exception
    {
         public CalculationException(string message) : base(message)
         {
             
         }
    }
}