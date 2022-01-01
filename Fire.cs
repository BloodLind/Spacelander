using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLander
{
    class Fire
    {
        public Image FireImage { get; set; }
        public float Degree { get; set; }
        public PointF Location { get; set; }
        public void DrawObject(Graphics graphics)
        {
            graphics.DrawImage(FireImage,
                      Location.X + FireImage.Width / 2, Location.Y);
        }
    }
}
