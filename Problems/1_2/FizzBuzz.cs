using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems._1_2
{
    [TestClass]
    public class FizzBuzz : BaseTest
    {
        
        [TestMethod]
        public void Take1()
        {
            string line = "3 5 100";

            List<int> parts = line.Split(' ').Select(int.Parse).ToList();
            foreach (var i in Enumerable.Range(1, parts[2]))
            {
                string result = string.Empty;
                if (i % parts[0] == 0)
                {
                    result = "Fizz";
                }

                if (i % parts[1] == 0)
                {
                    result += "Buzz";
                }

                if (string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
