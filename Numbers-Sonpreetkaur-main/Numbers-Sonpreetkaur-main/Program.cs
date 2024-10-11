

class Program
{
    static void Main(string[] args)
    {
        bool playAgain;
        do
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("write an integer (or press Enter to finish): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                    
                }


                try
                {
                    int number = Convert.ToInt32(input);
                    numbers.Add(number);
                }

                catch (FormatException)
                {
                    Console.WriteLine("That was not a integer. keep trying.");

                }

            }


            if (numbers.Count == 0)
            {
                Console.WriteLine("You did not enter any integer.");

            }

            else
            {
                int max = numbers.Max();
                int min = numbers.Min();
                List<int> oddNumbers = numbers.Where(n => n % 2 != 0).ToList();
                List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();


                int oddCount = oddNumbers.Count;
                int oddSum = oddNumbers.Sum();
                double oddAverage = oddCount > 0 ? (double)oddSum / oddCount : 0;


                int evenCount = evenNumbers.Count;
                int evenSum = evenNumbers.Sum();
                double evenAverage = evenCount > 0 ? (double)evenSum / evenCount : 0;


                Console.WriteLine($"Maximum value: {max}");
                Console.WriteLine($"Minimum value: {min}");
                Console.WriteLine($"Total number of odd integers: {oddCount}");
                Console.WriteLine($"Sum of all odd integers: {oddSum}");
                Console.WriteLine($"Average value of all odd integers: {oddAverage}");
                Console.WriteLine($"Total number of even integers: {evenCount}");
                Console.WriteLine($"Sum of all even integers: {evenSum}");
                Console.WriteLine($"Average value of all even integers: {evenAverage}");

            }

            Console.Write("Play again (Y/y)? ");
            string response = Console.ReadLine();
            playAgain = response.Equals("Y", StringComparison.OrdinalIgnoreCase);
        } while (playAgain);

    }

}