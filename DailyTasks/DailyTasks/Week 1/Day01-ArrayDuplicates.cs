namespace DailyTasks
{
    using Utilities;
    using Utilities.Attributes;

    [TaskDescription(@"Find all numbers that appear more than once in an array of integers. Each duplicate should be printed only once, regardless of how many times it repeats.",
                      "A single line of integers separated by \", \" (e.g. 4, 3, 2, 7, 8, 2, 3, 1)")]
    public class Day01_ArrayDuplicates
    {
        public static void ArrayDuplicatesV2()
        {
            int[] input = Console.ReadLine().Split(", ").Select(e => int.Parse(e)).ToArray();
            List<int> result = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                int current = input[i];

                for (int j = i + 1; j < input.Length; j++)
                {
                    int check = input[j];

                    if (current == check)
                    {
                        if (!result.Contains(current))
                        {
                            result.Add(current);
                        }
                    }
                }

            }

            Console.WriteLine(String.Join(", ", result));
        }

        [ProblemSolution]
        public static void ArrayDuplicates()
        {
            string input = string.Empty;
            bool isAllValid = false;
            List<int> numbers = new List<int>();

            ValidateInput(input, isAllValid, numbers);

            int[] inputArr = numbers!.ToArray();

            HashSet<int> seen = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < inputArr.Length; i++)
            {
                int current = inputArr[i];

                if (!seen.Add(current))
                {
                    result.Add(current);
                }
            }

            if (result.Count() == 0)
            {
                ConsoleColorHelper.WriteLineColored("There are no duplicates in the array!", MessageTypes.Result);
                return;
            }

            ConsoleColorHelper.WriteLineColored($"Duplicate numbers: {String.Join(", ", result.OrderBy(n => n))}", MessageTypes.Result);
        }

        private static List<int> ValidateInput(string input, bool isAllValid, List<int> numbers)
        {
            while (isAllValid == false)
            {
                ConsoleColorHelper.WriteColored("Input Array: ", MessageTypes.Prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsoleColorHelper.WriteLineColored("Invalid input, please try again.", MessageTypes.Error);
                    continue;
                }

                string[] rawParts = input.Split(new[] { ',', '.' }).Select(p => p.Trim()).ToArray();

                numbers = new List<int>();
                isAllValid = true;

                foreach (string part in rawParts)
                {
                    if (!int.TryParse(part, out int number))
                    {
                        isAllValid = false;
                        break;
                    }
                    numbers.Add(number);
                }

                if (!isAllValid)
                {
                    ConsoleColorHelper.WriteLineColored("Invalid input, please try again.", MessageTypes.Error);
                    continue;
                }
            }

            return numbers;
        }
    }
}
