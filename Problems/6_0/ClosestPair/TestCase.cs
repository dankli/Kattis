using System;
using System.Collections.Generic;

namespace Problems._6_0.ClosestPair
{
    public class TestCase
    {
        public int NumberOfValues { get; set; }
        public List<Point> Points { get; set; } = new List<Point>();

        public Tuple<double, Point, Point> Shortest { get; set; }
    }
}
