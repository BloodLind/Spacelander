using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SpaceLander
{
    class GroundCoolision
    {

        public static bool CheckCoordInPoints(PointF point, IEnumerable<PointF> pointFs)
        {

            for(int i = 0; i < pointFs.Count() - 1; i++)
            {
                int ac = 
                    (int)GameMath.DistanceOfTwoPoints
                    (pointFs.ElementAt(i), pointFs.ElementAt(i + 1));

                int ab =
                    (int)GameMath.DistanceOfTwoPoints(pointFs.ElementAt(i), point);

                int bc =
                    (int)GameMath.DistanceOfTwoPoints(point, pointFs.ElementAt(i + 1));

                if (ac == bc + ab)
                    return true;

            }
            return false;
        }
    }
}
