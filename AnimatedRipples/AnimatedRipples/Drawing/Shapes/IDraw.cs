using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing.Shapes
{
    internal interface IShapeDraw
    {
        void Draw(Graphics graphics, double progress);
    }
}
