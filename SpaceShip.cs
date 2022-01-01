using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLander
{
	public class SpaceShip : IDraweble
	{
		public Image ShipImage { get; set; }
		public float Speed { get; set; }
		public float Degree { get; set; }
		public int Resistant { get; set; }
		public Pen DrawingBrush { get; set; }
		public PointF Location { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public void DrawObject(Graphics graphics)
		{

			if (ShipImage == null)
			{
				graphics.FillRectangle(DrawingBrush.Brush, Location.X, Location.Y, Width, Height);
			}
			else
			{
				graphics.DrawImage(ShipImage, Location.X, Location.Y);
			}
		}
	}
}
