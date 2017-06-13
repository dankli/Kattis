using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            string line1 = "9";
            string line2 = "AAAABBBBB";

            int numberOfQuestions = int.Parse(line1);

            var adrianChars = GetBoyCharsSequence(Adrian, numberOfQuestions);
            var brunoChars = GetBoyCharsSequence(Bruno, numberOfQuestions);
            var goranChars = GetBoyCharsSequence(Goran, numberOfQuestions);

            var questions = line2.ToList();

            var adrian = new Boy{Name = "Adrian"};
            var bruno = new Boy { Name = "Bruno" };
            var goran = new Boy { Name = "Goran" };

            for (var i = 0; i < questions.Count; i++)
            {
                char answer = questions[i];
                if (adrianChars[i] == answer)
                {
                    adrian.CorrectAnswers++;
                }

                if (brunoChars[i] == answer)
                {
                    bruno.CorrectAnswers++;
                }

                if (goranChars[i] == answer)
                {
                    goran.CorrectAnswers++;
                }
            }

            List<Boy> boys = new List<Boy>{adrian, bruno, goran};

            var result = boys.OrderByDescending(b => b.CorrectAnswers).ThenBy(b => b.Name).ToList();
            var topResult = result[0].CorrectAnswers;
            Console.WriteLine(topResult);
            foreach (Boy boy in result.Where(b => b.CorrectAnswers == topResult))
            {
                Console.WriteLine(boy.Name);
            }
        }

        private List<char> GetBoyCharsSequence(string template, int numberOfQuestions)
        {
            int mod;
            int div = Math.DivRem(numberOfQuestions, template.Length, out mod);

            var templateResult = new StringBuilder();
            for (var i = 0; i < div; i++)
            {
                templateResult.Append(template);
            }

            List<char> boyChars = templateResult.ToString().ToList();
            var templateChars = template.ToCharArray();
            for (var i = 0; i < mod; i++)
            {
                boyChars.Add(templateChars[i]);
            }

            return boyChars;
        }

        private class Boy
        {
            public string Name { get; set; }
            public int CorrectAnswers { get; set; }
        }
    }
}
