using Calculation.Classes.Data;
using Calculation.Helpers;
using Newtonsoft.Json;
using Pulsation.Models;

namespace Calculation.UI.Models
{
    public class PulsationSolutionItemModel : PulsationData
    {
        public PulsationSolutionItemModel(PulsationData data)
        {
            ObjectHelper.Copy(data, this, typeof(ParameterAttribute));
            Info = JsonConvert.SerializeObject(new {data.H1, data.H2, data.H3});
        }

        public int Id { get; set; }
        public string Info { get; set; }
        public bool IsTimeDependent { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public int CountInPeriod
        {
            get { return (int) (Period/dt) + 1; }
        }

        public double Time
        {
            get { return dt*Count; }
        }
    }
}