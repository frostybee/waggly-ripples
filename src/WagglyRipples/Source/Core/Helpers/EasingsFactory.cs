using FrostyBee.FriskyRipples.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace FrostyBee.FriskyRipples.Animation
{
    internal static class EasingsFactory
    {
        public static IEnumerable<Type> GetEnumerableOfType<T>() where T : class
        {
            List<Type> types = new List<Type>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                //types.Add((T)Activator.CreateInstance(type));
                types.Add(type);
            }
            //types.Sort();
            return types;
        }

        internal static Dictionary<string, EasingInfoAttribute> GetEasingFunctions()
        {
            Dictionary<string, EasingInfoAttribute> easingMap = new Dictionary<string, EasingInfoAttribute>();
            var easings = EasingsFactory.GetEnumerableOfType<Easing>();

            foreach (Type type in easings)
            {
                // Retrieve the EasingInfo attribute.                 
                EasingInfoAttribute attribute = type.GetCustomAttribute<EasingInfoAttribute>(false);
                if (attribute != null)
                {
                    Debug.WriteLine(attribute.Name +" "+ attribute.Description + " " + attribute.Speed);
                    attribute.Type = type;
                    easingMap.Add(attribute.Name, attribute);
                }
            }
            return easingMap;           
        }
    }
}
