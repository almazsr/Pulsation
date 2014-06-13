using Calculation.Classes.Data;
using Calculation.Helpers;

namespace Pulsation.Models
{
    public class PulsationAlphaData : PulsationData
    {
        public PulsationAlphaData(PulsationData pulsationData, Bundle group)
        {
            ObjectHelper.Copy(pulsationData, this, typeof (ParameterAttribute));
            GroupName = group.Name;
            GroupId = group.Id;
        }

        public int GroupId { get; set; }        

        [Parameter("Решение")]
        public string GroupName { get; set; }
    }
}