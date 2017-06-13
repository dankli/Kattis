using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems._6_0
{
    [TestClass]
    public class ClosestPair : BaseTest
    {
        private List<string> lines;

        protected override void BeforeTest()
        {
            this.lines = new List<string>
            {
                "2",
                "1.12 0",
                "0 0.51",
                "3",
                "158 12",
                "123 15",
                "1859 -1489",
                "3",
                "21.12 -884.2",
                "18.18 43.34",
                "21.12 -884.2",
                "0"
            };
        }


        [TestMethod]
        public void Run()
        {
            BeforeTest();
            TestCase testCase = null;
            foreach (var line in lines)
            {
                string[] parts = line.Split(' ');
                
                if (parts.Length == 1)
                {
                    if (parts[0] == "0")
                    {
                        CalculateTestCase(testCase);
                        Console.WriteLine($"{testCase.Shortest.Item2.X} {testCase.Shortest.Item2.Y} {testCase.Shortest.Item3.X} {testCase.Shortest.Item3.Y}");
                        break;
                    }

                    int numberOfValues = 0;
                    if (int.TryParse(line, out numberOfValues))
                    {
                        if (testCase == null)
                        {
                            testCase = new TestCase { NumberOfValues = numberOfValues };
                        }
                        else
                        {
                            CalculateTestCase(testCase);
                            Console.WriteLine($"{testCase.Shortest.Item2.X} {testCase.Shortest.Item2.Y} {testCase.Shortest.Item3.X} {testCase.Shortest.Item3.Y}");
                            testCase = new TestCase { NumberOfValues = numberOfValues };
                        }
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

        private static void CalculateTestCase(TestCase testCase)
        {
            for (var i = 0; i < testCase.Points.Count - 1; i++)
            {
                for (var j = i + 1; j < testCase.Points.Count; j++)
                {
                    decimal distance = Convert.ToDecimal(Math.Sqrt(Math.Pow(testCase.Points[i].X - testCase.Points[j].X, 2) + Math.Pow(testCase.Points[i].Y - testCase.Points[j].Y, 2)));
                    if (testCase.Shortest == null)
                    {
                        testCase.Shortest = new Tuple<decimal, Point, Point>(distance, testCase.Points[i], testCase.Points[j]);
                    }else if (testCase.Shortest.Item1 > distance)
                    {
                        testCase.Shortest = new Tuple<decimal, Point, Point>(distance, testCase.Points[i], testCase.Points[j]);
                    }
                }
            }
        }

        private class TestCase
        {
            public int NumberOfValues { get; set; }
            public List<Point> Points { get; set; } = new List<Point>();

            public Tuple<decimal, Point, Point> Shortest { get; set; }
        }

        private class Point
        {
            public Point(float x, float y)
            {
                X = x;
                Y = y;
            }
            public float X { get; set; }
            public float Y { get; set; }
        }
    }
}
