﻿using Calculation.Interfaces;

namespace Calculation.Classes
{
    public class TimeLimitCondition : IStopCondition
    {
        public TimeLimitCondition(double tMax)
        {
            TMax = tMax;
        }

        public bool IsFinish(ITimeDependentSolution1D solution)
        {
            return solution.CurrentTime > TMax;
        }

        public double TMax { get; set; }
    }
}