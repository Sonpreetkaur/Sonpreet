
namespace NumberSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>
            {
                17, 166, 288, 324, 531, 792, 946, 157, 276, 441, 533, 355, 228, 879, 100, 421, 23, 490,
                259, 227, 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336,
                973, 483, 897, 396, 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677,
                112, 265, 28, 358, 119, 784, 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371,
                221, 437, 374, 575, 669, 354, 678, 314, 450, 808, 182, 138, 360, 585, 970, 787, 3,
                889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150
                
            };

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose an operation: 1) Basic Search 2) Range Search 3) Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BasicSearch(numbers);
                        break;

                    case "2":
                        RangeSearch(numbers);
                        break;

                    case "3":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
                        break;
                }

            }

        }

        static void BasicSearch(List<int> numbers)
        {
            Console.WriteLine("Enter an integer to search:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int searchNumber))

            {
                int index = numbers.IndexOf(searchNumber);

                if (index != -1)
                {
                    Console.WriteLine($"Number {searchNumber} found at index {index}.");
                }

                else
                {
                    Console.WriteLine("Number not found.");
                }

            }

            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

        }

        static void RangeSearch(List<int> numbers)
        {
            Console.WriteLine("Enter the lower bound of the range (press Enter for default 0):");

            string lowerInput = Console.ReadLine();
            int lowerBound = 0;

            if (!string.IsNullOrEmpty(lowerInput))
            {
                if (!int.TryParse(lowerInput, out lowerBound))
                {
                    Console.WriteLine("Invalid input. Lower bound set to default 0.");
                    lowerBound = 0;
                }

            }

            Console.WriteLine("Enter the upper bound of the range (press Enter for default MaxValue):");

            string upperInput = Console.ReadLine();
            int upperBound = int.MaxValue;

            if (!string.IsNullOrEmpty(upperInput))

            {
                if (!int.TryParse(upperInput, out upperBound))
                {
                    Console.WriteLine("Invalid input. Upper bound set to default MaxValue.");
                    upperBound = int.MaxValue;
                }

            }

            var result = numbers.Where(n => n >= lowerBound && n <= upperBound).OrderBy(n => n).ToList();

            Console.WriteLine($"Found {result.Count} numbers within the range:");
            Console.WriteLine(string.Join(", ", result));
        }

    }

}
