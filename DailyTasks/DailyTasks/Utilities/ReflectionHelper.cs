using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace DailyTasks.Utilities
{

    public class ReflectionHelper
    {
        public static string GetProblemInfo()
        {
            Console.WriteLine("Select day in format day01 to review problem solution:");
            string problemInfo = Console.ReadLine();
            string problemNumber = $"{problemInfo.Remove(0, 3).PadLeft(2, '0')}_";

            return problemNumber;
        }

        public static MethodInfo GetProblem(string problemNumber)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().Where(t => t.Namespace == "DailyTasks" && t.Name.Contains(problemNumber)).FirstOrDefault()!; //TODO: Possible null results handle
            string description = type.GetCustomAttribute<TaskDescriptionAttribute>()!.Description;
            string inputFormat = type.GetCustomAttribute<TaskDescriptionAttribute>()!.InputFormat;
            MethodInfo problemSolution = type.GetMethods().FirstOrDefault(m => m.GetCustomAttribute<ProblemSolutionAttribute>() != null)!;

            StringBuilder sb = new StringBuilder();

            Console.WriteLine(
                 sb.AppendLine(description)
                   .AppendLine(inputFormat)
                   .ToString()
                   .Trim());

            return problemSolution;
        }

        public static void SolveProblem()
        {
            string problemInfo = GetProblemInfo();

            GetProblem(problemInfo).Invoke(null, null);
        }
    }
}
