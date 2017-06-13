using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems._3_0
{
    [TestClass]
    public class Lektira : BaseTest
    {
        [TestMethod]
        public void Run()
        {
            var input = "dcbagfekjih".ToList();
            var firstLetter = input.OrderBy(w => w).First();
            
            List<string> words = new List<string>();
            for (var i = 1; i < input.Count - 1; i++)
            {
                List<char> wordOne = input.Skip(0).Take(i).ToList();
                if (wordOne.Last() != firstLetter)
                {
                    continue;
                }

                wordOne.Reverse();

                for (var j = 1; j < input.Count - i; j++)
                {
                    var wordTwo = input.Skip(i).Take(j).Reverse();
                    var wordThree = input.Skip(i + j).Take(input.Count).Reverse();

                    //var word = new string(wordOne.ToArray()) + new string(wordTwo.ToArray()) + new string(wordThree.ToArray());
                    var word = string.Join(string.Empty, wordOne) + string.Join(string.Empty, wordTwo) + string.Join(string.Empty, wordThree);
                    words.Add(word);
                }
            }

            var bestWord = words.OrderBy(w => w).First();
            Console.WriteLine(bestWord);
        }
    }
}
