using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormLayered.Drawing.Shapes
{
    internal class CrosshairProfile : BaseProfile
    {
        SolidBrush _verticalBrush;
        SolidBrush _horizontalBrush;
        public CrosshairProfile()
        {
            InitDrawingProfile();
        }

        private void InitDrawingProfile()
        {
            int opacity = 10;            
            int width = 40;
            int height = 8;
            // TODO: Set the initial opacity here. 
            //_verticalBrush = new SolidBrush(Color.CornflowerBlue);
            _verticalBrush = new SolidBrush(Color.DarkBlue);
            _horizontalBrush = new SolidBrush(Color.Crimson);            
            // 1) Make the outer most ripple.
            _ripples.Add(
                new RippleEntry()
                {
                    IsExpandable = false,
                    Bounds = new Rectangle((200/ 2) - 4, (200 / 2) - 20, height, width),
                    ShapeType = ShapeType.Crosshair,
                    InitialRadius = 10,
                    RadiusMultiplier = 2,
                    FillBrush = _verticalBrush,
                    IsFilled = true,
                });
            _ripples.Add(
             new RippleEntry()
             {
                 IsExpandable = false,
                 Bounds = new Rectangle((200 / 2) - 20, (200 / 2) - 4, width, height),
                 ShapeType = ShapeType.Crosshair,
                 InitialRadius = 10,
                 RadiusMultiplier = 2,
                 FillBrush = _horizontalBrush,
                 IsFilled = true,
             });
        }       
    }
}
