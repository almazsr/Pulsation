namespace Schemes.Interfaces
{
    public interface IStopCondition
    {
        bool IsFinish(ITimeDependentSolution1D solution); 
    }
}