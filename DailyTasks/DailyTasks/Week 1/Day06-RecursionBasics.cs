using DailyTasks.Utilities;
using DailyTasks.Utilities.Attributes;

namespace DailyTasks.Week_1
{
    [TaskDescription(@"", "")]
    public class Day06_RecursionBasics
    {
        [ProblemSolution]
        public static void RecursionManager()
        {
            int[] array = {1, 2, 3, 4, 5, 6};
            int number = int.Parse(Console.ReadLine());

            ConsoleColorHelper.WriteColored($"{ReverseArray(array, number)} ", MessageTypes.Result);
        }

        private static int Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }

        private static int SumArray(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + SumArray(array, ++index);
        }

        private static int ReverseArray(int[] array, int index)
        {
            if (index == 0)
            {
                return 0;
            }

            return ReverseArray(array, --index);
        }
    }
}
