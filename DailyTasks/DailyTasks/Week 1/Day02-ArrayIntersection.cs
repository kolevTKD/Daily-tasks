using DailyTasks.Utilities;
using System.Collections.Immutable;

namespace DailyTasks
{
    [TaskDescription(@"Find all numbers that appear in both of two given arrays of integers. Each common number should be printed only once, even if it repeats in one or both arrays.",
                      "Two lines, each a list of integers separated by \", \" (e.g. 4, 3, 2, 7, 8 / 2, 8, 3, 9, 1)")]
    public class Day02_ArrayIntersection
    {
        public static void ArrayIntersectionV2()
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input1) || String.IsNullOrWhiteSpace(input2))
            {
                Console.WriteLine("No numbers intersect in the arrays!");
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

            Console.WriteLine(String.Join(", ", result.OrderBy(n => n)));

        }

        [ProblemSolution]
        public static void ArrayIntersection()
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input1) || String.IsNullOrWhiteSpace(input2))
            {
                Console.WriteLine("No numbers intersect in the arrays!");
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
                Console.WriteLine("No numbers intersect in the arrays!");
                return;
            }

            Console.WriteLine(String.Join(", ", result.OrderBy(n => n)));
        }
    }
}
