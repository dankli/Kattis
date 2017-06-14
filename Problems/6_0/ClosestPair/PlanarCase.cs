using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems._6_0.ClosestPair
{
    public class PlanarCase
    {
        public static Tuple<double, Point, Point> Run(List<Point> points)
        {
            if (points.Count < 4)
            {
                return BruteForce.Run(points);
            }

            List<Point> xList = points.OrderBy(p => p.X).ToList();

            return ClosestRec(xList);
        }

        private static Tuple<double, Point, Point> ClosestRec(List<Point> xPoints)
        {
            int count = xPoints.Count;
            if (count <= 3)
            {
                return BruteForce.Run(xPoints);
            }

            List<Point> leftByX;
            List<Point> rightByX;
            if (count % 2 == 0)
            {
                leftByX = xPoints.Take(count / 2).ToList();
                rightByX = xPoints.Skip(count / 2).ToList();
            }
            else
            {
                leftByX = xPoints.Take(count / 2).ToList();
                rightByX = xPoints.Skip(count / 2).ToList();
            }
            
            Tuple<double, Point, Point> leftResult = ClosestRec(leftByX);

            
            var rightResult = ClosestRec(rightByX);

            var result = rightResult.Item1 < leftResult.Item1 ? rightResult : leftResult;

            var midX = leftByX.Last().X;
            var bandWidth = result.Item1;

            IEnumerable<Point> inBandByX = xPoints.Where(p => Math.Abs(midX - p.X) <= bandWidth);
            List<Point> inBandByY = inBandByX.OrderBy(p => p.Y).ToList();
            int lastIndex = inBandByY.Count - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                var pLower = inBandByY[i];
                for (int j = i + 1; j <= lastIndex; j++)
                {
                    var pUpper = inBandByY[j];

                    if ((pUpper.Y - pLower.Y) >= result.Item1)
                    {
                        break;
                    }

                    double distance = BruteForce.Distance(pLower, pUpper);
                    if (distance < result.Item1)
                    {
                        result = new Tuple<double, Point, Point>(distance, pLower, pUpper);
                    }
                }
            }

            return result;
        }
    }
}
