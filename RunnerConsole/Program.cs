using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RunnerConsole
{
    class Program
    {
        static void Main()
        {
            TestCase testCase = null;
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (line == "0")
                {
                    Tuple<double, Point, Point> result = PlanarCase.Run(testCase.Points);
                    Console.WriteLine($"{result.Item2.X} {result.Item2.Y} {result.Item3.X} {result.Item3.Y}");
                    break;
                }

                string[] parts = line.Split(' ');
                if (parts.Length == 1)
                {
                    if (testCase == null)
                    {
                        testCase = new TestCase();
                    }
                    else
                    {
                        Tuple<double, Point, Point> result = PlanarCase.Run(testCase.Points);
                        Console.WriteLine($"{result.Item2.X} {result.Item2.Y} {result.Item3.X} {result.Item3.Y}");
                        testCase = new TestCase();
                    }
                }
                else
                {
                    float x = float.Parse(parts[0], CultureInfo.InvariantCulture.NumberFormat);
                    float y = float.Parse(parts[1], CultureInfo.InvariantCulture.NumberFormat);
                    Point point = new Point(x, y);
                    testCase.Points.Add(point);
                }
            }
        }

        public class TestCase
        {
            public int NumberOfValues { get; set; }
            public List<Point> Points { get; set; } = new List<Point>();

            public Tuple<decimal, Point, Point> Shortest { get; set; }
        }

        public class Point
        {
            public Point(float x, float y)
            {
                X = x;
                Y = y;
            }
            public float X { get; set; }
            public float Y { get; set; }
        }

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
}
