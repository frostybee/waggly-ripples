using FrostyBee.FriskyRipples.Attributes;
using FrostyBee.FriskyRipples.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Drawing
{
    internal class ConstructableFactory
    {

        /// <summary>
        /// Instantiates a class specified by its constructable enum value.
        /// </summary>
        /// <typeparam name="T">The class to be instantiated.</typeparam>
        /// <param name="selectedValue">The enum value that is mapped to a constructable attribute.</param>
        /// <returns>The newly created instance of the selected type.</returns>
        public static T Instantiate<T>(Enum selectedValue)
        {
            ConstructableEnumAttribute attribute = selectedValue.GetEnumAttribute<ConstructableEnumAttribute>();
            T newInstance = (T)Activator.CreateInstance(attribute.Type);
            return newInstance;
        }
    }
}
