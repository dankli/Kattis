using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems._6_0.ClosestPair
{
    [TestClass]
    public partial class ClosestPair : BaseTest
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
        public void RunPlanarCase()
        {
            TestCase testCase = null;
            FileInfo file = new FileInfo("TestCase" + 100 + ".txt");
            using (StreamReader reader = new StreamReader(file.OpenRead()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "0")
                    {
                        Tuple<double, Point, Point> result = PlanarCase.Run(testCase.Points);
                        Console.WriteLine($"{result.Item1} - {result.Item2.X} {result.Item2.Y} {result.Item3.X} {result.Item3.Y}");
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
                            Console.WriteLine($"{result.Item1} - {result.Item2.X} {result.Item2.Y} {result.Item3.X} {result.Item3.Y}");
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

        }

        [TestMethod]
        public void Run()
        {
            BeforeTest();
            TestCase testCase = null;
            List<Task> tasks = new List<Task>();
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
                    double distance = Math.Sqrt(Math.Pow(testCase.Points[i].X - testCase.Points[j].X, 2) + Math.Pow(testCase.Points[i].Y - testCase.Points[j].Y, 2));
                    if (testCase.Shortest == null)
                    {
                        testCase.Shortest = new Tuple<double, Point, Point>(distance, testCase.Points[i], testCase.Points[j]);
                    }else if (testCase.Shortest.Item1 > distance)
                    {
                        testCase.Shortest = new Tuple<double, Point, Point>(distance, testCase.Points[i], testCase.Points[j]);
                    }
                }
            }
        }

        [TestMethod]
        public void Divide()
        {
            int n = 9;

            int d = n / 2;
            Console.WriteLine(d);
        }
    }
}
