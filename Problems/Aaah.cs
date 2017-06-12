using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems
{
    [TestClass]
    public class Aaah
    {
        [TestMethod]
        public void Go()
        {
            string line1 = "aaaah";
            string line2 = "aaah";

            if (line1.Length > line2.Length)
            {
                Console.WriteLine("go");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
