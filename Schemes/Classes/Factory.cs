using Schemes.Interfaces;

namespace Schemes.Classes
{
    public static class Factory
    {
        static Factory()
        {
            Instance = new DbFactory();
        }

        public static IFactory Instance { get; private set; }
    }
}