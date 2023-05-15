using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing.Extensions
{
    internal static class EnumExtensions
    {
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
