using System;
using Calculation.Enums;

namespace Calculation.Interfaces
{
    public interface ISolution1D
    {
        IGrid1D Grid { get; }     

        ILayer1D GetLayer(int timeIndex);

        double GetTime(int timeIndex);

        double TimeStep { get; }
        
        ILayer1D CurrentLayer { get; }

        int CurrentTimeIndex { get; }

        double CurrentTime { get; }

        DateTime Started { get; }

        SolutionState State { get; }

        void AddLayer(double[] values);

        void NextTime();

        bool IsExact { get; }
    }
}