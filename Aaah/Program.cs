using System;

namespace Aaah
{
    class Program
    {
        static void Main()
        {
            string line;
            string line1 = string.Empty;
            string line2;
            int lineCount = 0;
            while ((line = Console.ReadLine()) != null)
            {
                lineCount++;
                if (lineCount % 2 == 0)
                {
                    line2 = line;
                    Validate(line1, line2);
                }
                else
                {
                    line1 = line;
                }
            }
        }

        private static void Validate(string line1, string line2)
        {
            if (line1.Length >= line2.Length)
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
