using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems._1_5
{
    [TestClass]
    public class Ptice
    {
        [TestMethod]
        public void PticeTest()
        {
            const string Adrian = "ABC";
            const string Bruno = "BABC";
            const string Goran = "CCAABB";

            string line1 = "5";
            string line2 = "BAACC";

            int numberOfQuestions = int.Parse(line1);

            var div = 5 / Adrian.Length;
            var mod = 5 % Adrian.Length;
            Console.WriteLine(div + " " + mod);

            string adrianSeq = string.Empty;
            for (var i = 0; i < div; i++)
            {
                adrianSeq += Adrian;
            }

            var adrianChars = adrianSeq.ToCharArray().ToList();
            for (var i = 0; i < mod; i++)
            {
                adrianChars.Add(Adrian.ToCharArray()[i]);
            }

            foreach (var adrianChar in adrianChars)
            {
                Console.Write(adrianChar);
            }
        }
    }
}
