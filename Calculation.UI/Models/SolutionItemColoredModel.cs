using System.Drawing;

namespace Calculation.UI.Models
{
    public class SolutionItemColoredModel
    {
        public SolutionItemColoredModel(SolutionItemModel item, Color color)
        {
            Color = color;
            Item = item;
        }

        public Color Color { get; set; }
        public SolutionItemModel Item { get; set; }
    }
}