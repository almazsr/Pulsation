using System;
using System.Linq;
using Calculation.Interfaces;

namespace Calculation.Helpers
{
    public static class LayerExtensions
    {
        public static double NormInf(this double[] layerArray)
        {
            return layerArray.Select(Math.Abs).Max();
        }

        public static double Norm1(this double[] layerArray)
        {
            return layerArray.Select(Math.Abs).Sum();
        }

        public static double Norm2(this double[] layerArray)
        {
            return Math.Sqrt(layerArray.Select(t => t*t).Sum());
        }

        public static double[] Subtract(this ILayer1D layer1, ILayer1D layer2)
        {
            double[] layer1Array = layer1.ToArray();
            double[] layer2Array = layer2.ToArray();
            return layer1Array.Select((t, i) => t - layer2Array[i]).ToArray();
        }
    }
}