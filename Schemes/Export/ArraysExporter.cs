using System.Collections.Generic;
using System.IO;
using System.Linq;
using Calculation.Classes.Data;
using Newtonsoft.Json;

namespace Calculation.Export
{
    public class ArraysExporter
    {
        public ArraysExporter(string format = DefaultFormat)
        {
            this.Format = format;
        }

        public const string DefaultFormat = "0.000";
        public string Format { get; set; }

        public void ExportToFile(string filename, object data, IEnumerable<Array> arrays)
        {        
            using (FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    string information = JsonConvert.SerializeObject(data);
                    streamWriter.WriteLine(information);
                    foreach (Array array in arrays)
                    {
                        string valuesString = string.Join("\t", array.Values.Select(e => e.ToString(Format)));
                        streamWriter.WriteLine("#{0}\t{1}\t{2}", array.Number, array.Name, valuesString);
                    }
                }
            }
        }
    }
}