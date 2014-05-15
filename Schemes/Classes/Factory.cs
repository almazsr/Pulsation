using System;
using System.Linq;
using System.Reflection;
using Calculation.Interfaces;

namespace Calculation.Classes
{
    public class Factory
    {
        static Factory()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Assembly assembly = Assembly.LoadFrom("Storage.dll");
            Type factoryType = assembly.GetTypes().FirstOrDefault(t => typeof(IFactory).IsAssignableFrom(t));
            if (factoryType != null)
            {
                Instance = (IFactory)Activator.CreateInstance(factoryType);
            }
        }

        public static IFactory Instance { get; private set; }
    }
}