using System;
using System.Collections.Generic;
using Calculation.Enums;

namespace Calculation.Interfaces
{
    public interface ISolution1D
    {
        object Key { get; }

        #region Main properties
        IGrid1D Grid { get; }

        string PhysicalData { get; set; } 
        #endregion

        #region Numeric or analytic
        bool IsExact { get; }

        string Solver { get; } 
        #endregion

        #region Time properties
        bool IsTimeDependent { get; }

        double dt { get; }

        double tCurrent { get; }

        int Nt { get; }

        ILayer1D CurrentLayer { get; }
        #endregion

        #region State properties
        DateTime? StartedAt { get; }

        SolutionState State { get; } 
        #endregion

        #region Methods

        ILayer1D GetLayer(int timeIndex);

        List<ILayer1D> GetLayers(int fromTimeIndex, int count);

        double GetTime(int timeIndex);

        void AddLayer(double[] layerValues);

        void Finish(bool success);

        void NextTime();

        void Start();

        #endregion

        event EventHandler Started;                
        event EventHandler Finished;
    }
}