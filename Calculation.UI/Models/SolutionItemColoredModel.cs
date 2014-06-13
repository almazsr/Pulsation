using System.Drawing;

namespace Calculation.UI.Models
{
    public class SolutionItemColoredModel
    {
        public SolutionItemColoredModel(PulsationSolutionItemModel item, Color color)
        {
            Color = color;
            Item = item;
        }

        public Color Color { get; set; }
        public PulsationSolutionItemModel Item { get; set; }
    }
}