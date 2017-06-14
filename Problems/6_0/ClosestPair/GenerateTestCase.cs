using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems._6_0.ClosestPair
{
    [TestClass]
    public class GenerateTestCase
    {
        [TestMethod]
        public void GenerateSmall()
        {
            Random randomInts = new Random();
            Random randomDec = new Random();

            int numberOfTestCases = 100;

            FileInfo file = new FileInfo("TestCase" + numberOfTestCases + ".txt");
            using (StreamWriter writer = file.CreateText())
            {
                for (int i = 0; i < numberOfTestCases; i++)
                {
                    int numberOfPairs = randomInts.Next(2, 1000);
                    writer.WriteLine(numberOfPairs);
                    for (int j = 0; j < numberOfPairs; j++)
                    {
                        var next = randomDec.NextDouble();
                        //var p1 = NextDecimal2(randomDec);
                        //var p2 = NextDecimal2(randomDec);
                        var p1 = Math.Round(-100000 + (next * (100000 - (-100000))), 2);
                        next = randomDec.NextDouble();
                        var p2 = Math.Round(-100000 + (next * (100000 - (-100000))), 2);
                        writer.WriteLine(p1 + " " + p2);
                    }
                }

                writer.WriteLine("0");
            }

        }

        private int NextInt32(Random random)
        {
            unchecked
            {
                int firstBits = random.Next(0, 1 << 4) << 28;
                int lastBits = random.Next(0, 1 << 28);
                return firstBits | lastBits;
            }
        }

        private decimal NextDecimal(Random random)
        {
            byte scale = (byte)random.Next(2);
            bool sign = random.Next(2) == 1;
            return new decimal(NextInt32(random),
                NextInt32(random),
                //NextInt32(random),
                random.Next(0x204FCE5E),
                sign,
                0);
            //scale);
        }

        private static int GetDecimalScale(Random r)
        {
            for (int i = 0; i <= 28; i++)
            {
                if (r.NextDouble() >= 0.1)
                    return i;
            }
            return 0;
        }

        public static decimal NextDecimal2(Random r)
        {
            var s = (byte) GetDecimalScale(r);
            var a = (int)(uint.MaxValue * r.NextDouble());
            var b = (int)(uint.MaxValue * r.NextDouble());
            var c = (int)(uint.MaxValue * r.NextDouble());
            var n = r.NextDouble() >= 0.5;
            return new Decimal(a, b, c, n, s);
        }
    }
}
