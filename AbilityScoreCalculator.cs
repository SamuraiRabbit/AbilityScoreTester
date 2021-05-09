using System;

namespace AbilityScoreTester
{
    class AbilityScoreCalculator
    {
        public int rollResult = 14;
        public double divideBy = 1.75;
        public int addAmount = 2;
        public int minimum = 3;
        public int score;

        public void CalculateAbilityScore()
        {
            double divided = rollResult / divideBy;
            int added = addAmount + (int)divided;

            if (added < minimum)
            {
                score = minimum;
            }
            else
            {
                score = added;
            }
        }

        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while (true)
            {
                calculator.rollResult = ReadInt(calculator.rollResult, "Starting 4d6");
                calculator.divideBy = ReadDouble(calculator.divideBy, "Divide by");
                calculator.addAmount = ReadInt(calculator.addAmount, "Add amount");
                calculator.minimum = ReadInt(calculator.minimum, "Minimum");

                calculator.CalculateAbilityScore();

                Console.WriteLine("Calculated ability score: " + calculator.score);
                Console.WriteLine("Press Q to quit, any other key to continue");

                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }

        static int ReadInt(int lastUsedValue, string prompt)
        { 
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int value))
            {
                Console.WriteLine("  using value " + value);
                return value;
            }
            else 
            {
                Console.WriteLine("  using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }

        static double ReadDouble(double lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();
            if (double.TryParse(line, out double value))
            {
                Console.WriteLine("  using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine("  using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }
    }
}