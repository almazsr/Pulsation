using System;

namespace Schemes.Interfaces
{
    public interface ITimeDependentSolution1D
    {
        IGrid1D Grid { get; }     

        ILayer1D GetLayer(int timeIndex);

        double GetTime(int timeIndex);

        double dt { get; set; }
        
        ILayer1D CurrentLayer { get; }

        int CurrentTimeIndex { get; }

        double CurrentTime { get; }         
        
        void AddLayer(double[] values);

        DateTime Started { get; }

        void NextTime();

        int Save();
    }
}