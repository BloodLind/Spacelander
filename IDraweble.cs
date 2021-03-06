using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLander
{
	interface IDraweble
	{
		Pen DrawingBrush { get; set; }
		PointF Location { get; set; }
		int Height { get; set; }
		int Width { get; set; }
		void DrawObject(Graphics graphics);
	}
}
