namespace DailyTasks.Utilities
{
    using System.Reflection;

    using Attributes;

    public class ReflectionHelper
    {
        public static void SolveProblem()
        {
            var (problemNumber, foundType) = GetProblemInfo();

            GetProblem(foundType).Invoke(null, null);
        }

        private static (string ProblemNumber, Type FoundType) GetProblemInfo()
        {
            int tasksCount = GetTasksCount();

            ConsoleColorHelper.WriteLineColored($"Enter day to access (Day01 through Day{tasksCount:D2}):", MessageTypes.Prompt);

            Type? foundType = null;
            string problemInfo = String.Empty;
            string problemNumber = String.Empty;

            var isValid = CheckValidInput(foundType, problemInfo, problemNumber);

            return (isValid.ProblemNumber, isValid.FoundType);
        }

        private static int GetTasksCount()
        {
            IEnumerable<Type> allTasksRange = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute<TaskDescriptionAttribute>() != null);

            return allTasksRange.Count();
        }


        private static Type? GetDayInfo(string problemNumber)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type dayType = assembly.GetTypes().Where(t => t.Namespace.Contains("DailyTasks") && t.Name.Contains(problemNumber)).FirstOrDefault()!;

            return dayType;
        }

        private static (string ProblemNumber, Type? FoundType) CheckValidInput(Type? foundType, string problemInfo, string problemNumber)
        {
            while (String.IsNullOrWhiteSpace(problemInfo) || foundType == null)
            {
                problemInfo = Console.ReadLine().Trim();

                if (String.IsNullOrWhiteSpace(problemInfo) || !problemInfo.ToLower().StartsWith("day"))
                {
                    ConsoleColorHelper.WriteLineColored("Invalid input, please try again.", MessageTypes.Error);
                    continue;
                }

                string digitsOnly = new string(problemInfo.Where(d => char.IsDigit(d)).ToArray());
                problemNumber = $"{digitsOnly.PadLeft(2, '0')}_";

                foundType = GetDayInfo(problemNumber);

                if (foundType == null)
                {
                    ConsoleColorHelper.WriteLineColored("No task found for this day, please try again.", MessageTypes.Error);
                    continue;
                }
            }

            return (problemNumber, foundType);
        }

        private static MethodInfo GetProblem(Type type)
        {
            var metadata = GetTaskMetadata(type);

            PrintTaskInfo(metadata.Description, metadata.InputFormat);

            return metadata.SolutionMethod;
        }

        private static void PrintTaskInfo(string description, string inputFormat)
        {
            ConsoleColorHelper.WriteLineColored(description, MessageTypes.Description);
            ConsoleColorHelper.WriteLineColored(inputFormat, MessageTypes.InputFormat);
        }

        private static (string Description, string InputFormat, MethodInfo SolutionMethod) GetTaskMetadata(Type type)
        {
            var attribute = type.GetCustomAttribute<TaskDescriptionAttribute>();
            MethodInfo solutionMethod = type.GetMethods().FirstOrDefault(m => m.GetCustomAttribute<ProblemSolutionAttribute>() != null);

            return (attribute?.Description ?? "", attribute?.InputFormat ?? "", solutionMethod);
        }
    }
}
