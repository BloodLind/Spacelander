using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLander
{
    class GameMath
    {
        public static double Sin(double degree)
        {
            return Math.Sin(degree * Math.PI / 180);
        }
        public static double Cos(double degree)
        {
            return Math.Cos(degree * Math.PI / 180);
        }
        public static double DistanceOfTwoPoints(PointF firstpoint, PointF secondPoint)
        {
            return Math.Sqrt(Math.Pow((secondPoint.X - firstpoint.X), 2)
                + Math.Pow((secondPoint.Y - firstpoint.Y), 2));
        }
    }
}
