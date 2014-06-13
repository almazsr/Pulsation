using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Calculation.Helpers
{
    public static class ObjectHelper
    {
        public static void Copy<T, U>(T from, U to, params Type[] attributeTypes)
        {
            Type typeFrom = from.GetType();
            Type typeTo = to.GetType();

            var propertiesFrom = GetProperties(typeFrom, attributeTypes);
            foreach (var propertyFrom in propertiesFrom)
            {
                var propertyTo = GetProperty(typeTo, propertyFrom.Name, attributeTypes);
                var value = propertyFrom.GetValue(from);
                if (propertyTo.SetMethod != null)
                {
                    propertyTo.SetValue(to, value);
                }
            }
        }

        private static PropertyInfo GetProperty(Type type, string name, params Type[] attributeTypes)
        {
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (attributeTypes == null || attributeTypes.Any(a => property.GetCustomAttribute(a) != null))
            {
                return property;
            }
            return null;
        }

        private static IEnumerable<PropertyInfo> GetProperties(Type type, params Type[] attributeTypes)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(
                    p => attributeTypes == null || attributeTypes.Any(a => p.GetCustomAttribute(a) != null));
        }
    }
}