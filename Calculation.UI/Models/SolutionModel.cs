using System.Collections.Generic;
using System.Drawing;

namespace Calculation.UI.Models
{
    public class SolutionModel
    {
        public List<LayerModel> Layers { get; set; }

        public string Name { get; set; }

        public Color Color { get; set; }

        public string DisplayName { get; set; }

        public bool Visible { get; set; }
    }
}