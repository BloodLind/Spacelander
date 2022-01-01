using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SpaceLander
{
    public class LevelCreator
    {
        private int landingIndex;
        private int maximalCountOfPoints = 0;
        private List<PointF> points = new List<PointF>();

        public int LandingIndex { get => landingIndex; }
        public int LandingZoneSize { get; set; }
        public List<PointF> Points { get => points; }
        public Pen LandingPen { get; set; }
        public Pen GroundPen { get; set; }
        public Image GroundTexture { get; set; }
        public int ScreenHeight { get; set; }
        public int MaximalHeight { get; set; }
        public int MaximalWidth { get; set; }

        public void SetMaximalCountOfPoints(int value)
        {
            if (value % 2 == 0)
                maximalCountOfPoints = value;
            else
                maximalCountOfPoints = value + 1;
        }
        public int GetMaximalCountOfPoints() => maximalCountOfPoints;
        public void GenaratePoints()
        {
            Random random = new Random();
            for (int x = 0; x < MaximalWidth;
                x += random.Next(MaximalWidth / maximalCountOfPoints) + 20)
            {
                Points.Add(new PointF(x, random.Next(MaximalHeight)));
            }
            for(int i =0; i < Points.Count; i++)
            {
                Points[i] = new PointF(Points[i].X, ScreenHeight - Points[i].Y);
            }
            Points.Add(new PointF(MaximalWidth, random.Next(MaximalHeight)));

            landingIndex = random.Next(0, Points.Count - 1);
            Points[landingIndex + 1] = new PointF(Points[landingIndex].X + LandingZoneSize, Points[landingIndex].Y);
        }
        public void DrawPoints(Graphics graphics)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLine(points[0], new PointF(0, ScreenHeight));
            
            for (int i = 0; i < Points.Count - 1; i++)
            {
                path.AddLine(Points[i], Points[i + 1]);
                graphics.DrawLine(i == landingIndex ? LandingPen : GroundPen, Points[i], Points[i + 1]);
            }
           
            path.AddLine(Points[Points.Count - 1], new PointF(MaximalWidth, ScreenHeight));
            path.AddLine(new PointF(MaximalWidth, ScreenHeight), new PointF(0, ScreenHeight));
            path.CloseFigure();
            graphics.FillPath(GroundTexture == null ? GroundPen.Brush : 
                new TextureBrush(GroundTexture), path);
        }
    }
}
