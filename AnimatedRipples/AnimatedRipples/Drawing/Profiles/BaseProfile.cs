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
        protected readonly List<RippleEntry> _ripples = new List<RippleEntry>();
        public int Width { get; set; } = 200;
        public int Height { get; set; } = 200;
        public int BaseRadius { get; set; } = 10;
        protected BaseProfile()
        {
        }
        // Is it better to use an interface with public properties?

        public abstract void Draw(Graphics graphics, Bitmap surface, double progress);
        public List<RippleEntry> RippleEntries { get => _ripples; }
    }
}