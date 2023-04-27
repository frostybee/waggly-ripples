using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLayered.Drawing
{
    internal abstract class BaseRipple
    {      
        protected BaseRipple()
        {        
        }        
        // Is it better to use an interface with public properties?

        public abstract void Draw(Graphics graphics, Bitmap surface, double progress);
    }
}
