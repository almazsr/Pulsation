using Schemes.TimeDependent1D;

namespace Schemes.Interfaces
{
    public interface IStopCondition
    {
        bool IsFinish(TimeDependent1DSolution solution); 
    }
}