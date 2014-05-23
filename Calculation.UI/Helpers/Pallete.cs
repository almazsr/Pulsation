using System.Drawing;

namespace Calculation.UI.Helpers
{
    public static class Pallete
    {
        public static Color GetColor(int index)
        {
            int i = index%_colors.Length;
            return _colors[i];
        }

        private static Color[] _colors = new []
                                             {
                                                 Color.Black,
                                                 Color.Red,
                                                 Color.Blue,
                                                 Color.Green,
                                                 Color.DarkViolet,
                                                 Color.Orange,
                                                 Color.Gray,
                                                 Color.SaddleBrown,
                                                 Color.Yellow
                                             };
    }
}