using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems
{
    [TestClass]
    public abstract class BaseTest
    {
        private Stopwatch timer;
        [TestInitialize]
        public void Start()
        {
            timer = Stopwatch.StartNew();
        }

        [TestCleanup]
        public void End()
        {
            timer.Stop();

            Console.WriteLine("Took: " + timer.Elapsed);
        }
    }
}
