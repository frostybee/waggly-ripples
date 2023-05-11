using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormLayered.Drawing.Extensions
{
    internal static class ControlExtensions
    {
        public static void PopulateFromEnum(this ComboBox inComboBox, Type inEnumType)
        {
            inComboBox.DataSource = Enum.GetValues(inEnumType)
             .Cast<Enum>()
             .Select(value => new
             {
                 (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                 typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                 value
             })
            .OrderBy(item => item.value)
            .ToList();
            inComboBox.DisplayMember = "Description";
            inComboBox.ValueMember = "value";
        }
    }
}
