using System.Reflection;
using System.Text;

namespace DailyTasks.Utilities
{

    public class ReflectionHelper
    {
        public static void SolveProblem()
        {
            var (problemNumber, foundType) = GetProblemInfo();

            GetProblem(foundType).Invoke(null, null);
        }

        public static (string ProblemNumber, Type FoundType) GetProblemInfo()
        {
            int tasksCount = GetTasksCount();

            Console.WriteLine($"Enter day to access (Day01 through Day{tasksCount:D2}):");

            Type? foundType = null;
            string problemInfo = String.Empty;
            string problemNumber = String.Empty;

            while (foundType == null)
            {
                problemInfo = Console.ReadLine();
                problemNumber = $"{problemInfo.Remove(0, 3).PadLeft(2, '0')}_";
                foundType = GetDayInfo(problemNumber);

                if (foundType == null)
                {
                    Console.WriteLine("No task found for this day, please try again.");
                }

            }

            return (problemNumber, foundType);
        }

        public static int GetTasksCount()
        {
            IEnumerable<Type> allTasksRange = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute<TaskDescriptionAttribute>() != null);

            return allTasksRange.Count();
        }


        public static Type? GetDayInfo(string problemNumber)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type dayType = assembly.GetTypes().Where(t => t.Namespace == "DailyTasks" && t.Name.Contains(problemNumber)).FirstOrDefault()!;

            return dayType;
        }

        public static MethodInfo GetProblem(Type type)
        {
            var metadata = GetTaskMetadata(type);

            PrintTaskInfo(metadata.Description, metadata.InputFormat);

            return metadata.SolutionMethod;
        }

        public static void PrintTaskInfo(string description, string inputFormat)
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine(
                 sb.AppendLine(description)
                   .AppendLine(inputFormat)
                   .ToString()
                   .Trim());
        }

        public static (string Description, string InputFormat, MethodInfo SolutionMethod) GetTaskMetadata(Type type)
        {
            var attribute = type.GetCustomAttribute<TaskDescriptionAttribute>();
            MethodInfo solutionMethod = type.GetMethods().FirstOrDefault(m => m.GetCustomAttribute<ProblemSolutionAttribute>() != null);

            return (attribute?.Description ?? "", attribute?.InputFormat ?? "", solutionMethod);
        }
    }
}
