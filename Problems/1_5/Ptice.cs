using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems._1_5
{
    [TestClass]
    public class Ptice : BaseTest
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

            var adrianchars = GetBoyChars(Adrian, numberOfQuestions);
            var brunochars = GetBoyChars(Bruno, numberOfQuestions);
            var goranchars = GetBoyChars(Goran, numberOfQuestions);

            foreach (char c in adrianchars)
            {
                Console.Write(c);
            }
            Console.WriteLine();
            foreach (char c in brunochars)
            {
                Console.Write(c);
            }
            Console.WriteLine();
            foreach (char c in goranchars)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }

        private List<char> GetBoyChars(string sequence, int numberOfQuestions)
        {
            var div = numberOfQuestions / sequence.Length;
            var mod = numberOfQuestions % sequence.Length;
            

            string boySeq = string.Empty;
            for (var i = 0; i < div; i++)
            {
                boySeq += sequence;
            }

            var boyChars = boySeq.ToCharArray().ToList();
            char[] coreChars = sequence.ToCharArray();
            for (var i = 0; i < mod; i++)
            {
                boyChars.Add(coreChars[i]);
            }

            return boyChars;
        }
    }
}
