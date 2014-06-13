using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Classes.Data;
using Calculation.UI.Models;
using Pulsation.Models;

namespace Calculation.UI.Helpers
{
    public static class Convert
    {
         public static PulsationSolutionItemModel ToItemModel(this Bundle bundle, PulsationData pulsationData)
         {
             var result = new PulsationSolutionItemModel(pulsationData);
             result.Id = bundle.Id;
             result.Name = bundle.Name;
             result.Count = bundle.GetCount();
             result.IsTimeDependent = bundle.IsTimeDependent();
             return result;
         }
    }
}