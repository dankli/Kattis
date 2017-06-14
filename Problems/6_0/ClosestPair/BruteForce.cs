using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems._6_0.ClosestPair
{
    public class BruteForce
    {
        public static Tuple<double, Point, Point> Run(List<Point> points)
        {
            double shortest = Double.MaxValue;
            Tuple<double, Point, Point> closetsPair = new Tuple<double, Point, Point>(double.MaxValue, points[0], points[0]);
            for (var i = 0; i < points.Count - 1; i++)
            {
                var p1 = points[i];
                for (var j = i + 1; j < points.Count; j++)
                {
                    var p2 = points[j];
                    double distance = Distance(p1, p2);
                    if (distance < shortest)
                    {
                        closetsPair = new Tuple<double, Point, Point>(distance, p1, p2);
                    }
                }
            }

            return closetsPair;
        }

        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
