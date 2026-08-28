using DailyTasks.Utilities;

namespace DailyTasks
{
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
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("There are no duplicates in the array!");

                return;
            }

            int[] inputArr = input.Split(", ").Select(e => int.Parse(e)).ToArray();

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
                Console.WriteLine("There are no duplicates in the array!");

                return;
            }

            Console.WriteLine(String.Join(", ", result));
        }
    }
}
