namespace DailyTasks
{
    using System.Collections.Immutable;

    using Utilities;
    using Utilities.Attributes;

    [TaskDescription(@"Find all numbers that appear in both of two given arrays of integers. Each common number should be printed only once, even if it repeats in one or both arrays.",
                      "Two lines, each a list of integers separated by \", \" (e.g. 4, 3, 2, 7, 8 / 2, 8, 3, 9, 1)")]
    public class Day02_ArrayIntersection
    {
        public static void ArrayIntersectionV2()
        {
            ConsoleColorHelper.WriteColored("Input Array 1: ", MessageTypes.Prompt);
            string input1 = Console.ReadLine();

            ConsoleColorHelper.WriteColored("Input Array 2: ", MessageTypes.Prompt);
            string input2 = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input1) || String.IsNullOrWhiteSpace(input2))
            {
                ConsoleColorHelper.WriteLineColored("No numbers intersect in the arrays!", MessageTypes.Result);
                return;
            }

            int[] inputArr1 = input1.Split(", ").Select(n => int.Parse(n)).ToArray();
            int[] inputArr2 = input2.Split(", ").Select(n => int.Parse(n)).ToArray();

            List<int> result = new List<int>();

            for (int i = 0; i < inputArr1.Length; i++)
            {
                int curr = inputArr1[i];

                if (inputArr2.Contains(curr) && !result.Contains(curr))
                {
                    result.Add(curr);
                }
            }

            ConsoleColorHelper.WriteLineColored(String.Join(", ", result.OrderBy(n => n)), MessageTypes.Result);
        }

        [ProblemSolution]
        public static void ArrayIntersection()
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input1) || String.IsNullOrWhiteSpace(input2))
            {
                ConsoleColorHelper.WriteLineColored("No numbers intersect in the arrays!", MessageTypes.Result);
                return;
            }

            int[] inputArr1 = input1.Split(", ").Select(n => int.Parse(n)).ToArray();
            int[] inputArr2 = input2.Split(", ").Select(n => int.Parse(n)).ToArray();

            HashSet<int> seen = inputArr1.ToHashSet();
            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < inputArr2.Length; i++)
            {
                int curr = inputArr2[i];

                if (seen.Contains(curr))
                {
                    result.Add(curr);
                }
            }

            if (result.Count == 0)
            {
                ConsoleColorHelper.WriteLineColored("No numbers intersect in the arrays!", MessageTypes.Result);
                return;
            }

            ConsoleColorHelper.WriteLineColored(String.Join(", ", result.OrderBy(n => n)), MessageTypes.Result);
        }
    }
}
