namespace Schemes.Interfaces
{
    public interface ITimeDependentSolution1D
    {
        IGrid1D Grid { get; }     

        ILayer1D GetLayer(int timeIndex);

        double GetTime(int timeIndex);          
        
        ILayer1D CurrentLayer { get; }

        int CurrentTimeIndex { get; }

        double CurrentTime { get; }  
    }
}