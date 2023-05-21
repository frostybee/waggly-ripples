﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrostyBee.FriskyRipples.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class ConstructableEnumAttribute : Attribute
    {
        public Type Type { get; set; }
        public ConstructableEnumAttribute(Type inType)
        {
            Type = inType;
        }
    }
}
