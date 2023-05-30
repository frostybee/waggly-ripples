﻿using System;
using System.Reflection;

namespace FrostyBee.FriskyRipples.Extensions
{
    internal static class EnumExtensions
    {
        /// <summary>
        /// Retrieves an attribute associated with the supplied enum value by its type. 
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute on which the lookup should be performed.</typeparam>
        /// <param name="value">The enum value whose attribute will be returned.</param>
        /// <returns></returns>
        public static TAttribute GetEnumAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttribute<TAttribute>();
        }
    }
}
