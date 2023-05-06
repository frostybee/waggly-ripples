using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormLayered.Drawing.Shapes;

namespace WinFormLayered.Drawing
{
    internal abstract class BaseProfile
    {
        protected readonly List<BaseShape> _ripples = new List<BaseShape>();
        public int Width { get; set; } = 200;
        public int Height { get; set; } = 200;
        protected BaseProfile()
        {
        }
        // Is it better to use an interface with public properties?

        public abstract void Draw(Graphics graphics, Bitmap surface, double progress);
        public List<BaseShape> RippleEntries { get => _ripples; }
    }
}