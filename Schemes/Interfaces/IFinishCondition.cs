using Schemes.TimeDependent1D;

namespace Schemes.Interfaces
{
    public interface IFinishCondition
    {
        bool IsFinish(TimeDependent1DSolution solution); 
    }
}