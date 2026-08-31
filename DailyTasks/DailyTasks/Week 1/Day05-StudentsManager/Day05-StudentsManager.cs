namespace DailyTasks.Week_1.Day05_StudentsManager
{
    using System.Text;

    using Utilities.Attributes;
    using Utilities;

    [TaskDescription(@"Manage a hardcoded list of students using LINQ queries: filter students above a minimum grade, group students by age with average grade per group, find the student with the highest grade, get the top 3 highest-graded students, or list the names of students passing a grade threshold.",
        "Choose an action by number (1-5, or 0 to cancel). Actions 1 and 5 additionally require a decimal grade between 2.00 and 6.00 (e.g. 5.50)")]

    public class Day05_StudentsManager
    {
        [ProblemSolution]
        public static void ManageStudents()
        {
            List<Student> students = new List<Student>
            {
                new Student("Alexander Petrov", 16, 5.50),
                new Student("Maria Ivanova", 15, 6.00),
                new Student("Georgi Dimitrov", 17, 4.75),
                new Student("Elena Nikolova", 14, 5.25),
                new Student("Daniel Georgiev", 16, 4.50),
                new Student("Viktor Stoyanov", 15, 5.75),
                new Student("Anna Todorova", 17, 4.25),
                new Student("Nikolay Vasilev", 14, 5.00),
                new Student("Sofia Angelova", 16, 5.90),
                new Student("Martin Kolev", 15, 6.00),

            };

            StringBuilder sb = new StringBuilder();
            string prompt = sb.AppendLine("Choose a number to select action:")
                              .AppendLine("1. Minimum grade to filter by:")
                              .AppendLine("2. Average grade by group age:")
                              .AppendLine("3. Get the student with the highest grade:")
                              .AppendLine("4. Get top 3 students with lowest grades:")
                              .AppendLine("5. Get names of students over threshold:")
                              .AppendLine("0. Cancel")
                              .ToString()
                              .Trim();

            ConsoleColorHelper.WriteLineColored(prompt, MessageTypes.Prompt);

            string cmd = string.Empty;
            string result = string.Empty;

            while (cmd != "cancel" || cmd != "0")
            {
                if (!int.TryParse(cmd = Console.ReadLine().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out int selectedAction))
                {
                    if (string.IsNullOrWhiteSpace(cmd))
                    {
                        ConsoleColorHelper.WriteLineColored("Invalid input, please try again.", MessageTypes.Error);
                        continue;
                    }
                    else if (cmd.ToLower() == "cancel")
                        break;

                    else
                    {
                        ConsoleColorHelper.WriteLineColored("Invalid input, please try again.", MessageTypes.Error);
                        continue;
                    }
                }
                else if (selectedAction < 0 || selectedAction > 5)
                {
                    ConsoleColorHelper.WriteLineColored("Invalid action, please try again.", MessageTypes.Error);
                    continue;
                }
                else if (selectedAction == 0)
                    break;
                else
                {
                    double grade = -1;

                    if (selectedAction == 1)
                    {
                        ConsoleColorHelper.WriteColored("Enter grade to filter by: ", MessageTypes.Prompt);

                        while (!double.TryParse(cmd = Console.ReadLine().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out grade) || (grade < 2 || grade > 6))
                        {
                            ConsoleColorHelper.WriteLineColored("Invalid grade format, please enter valid decimal number.", MessageTypes.Error);
                            ConsoleColorHelper.WriteColored("Enter grade to filter by: ", MessageTypes.Prompt);
                        }

                        result = OrderedByGrade(students, grade);
                    }
                    else if (selectedAction == 2)
                    {
                        result = AgeGroupAvgGrade(students);
                    }
                    else if (selectedAction == 3)
                    {
                        result = HighestStudentGrade(students);
                    }
                    else if (selectedAction == 4)
                    {
                        result = TopLowestGrades(students);
                    }
                    else if (selectedAction == 5)
                    {
                        ConsoleColorHelper.WriteColored("Enter grade threshold: ", MessageTypes.Prompt);

                        while (!double.TryParse(cmd = Console.ReadLine().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out grade) || (grade < 2 || grade > 6))
                        {
                            ConsoleColorHelper.WriteLineColored("Invalid grade format, please enter valid decimal number.", MessageTypes.Error);
                            ConsoleColorHelper.WriteColored("Enter grade threshold: ", MessageTypes.Prompt);
                        }

                        result = PassedStudentsNames(students, grade);
                    }
                }

                ConsoleColorHelper.WriteLineColored(result, MessageTypes.Result);

                ConsoleColorHelper.WriteLineColored(prompt, MessageTypes.Prompt);
            }
        }

        private static string OrderedByGrade(List<Student> students, double grade)
        {
            List<Student> result = students.Where(g => g.Grade >= grade).OrderByDescending(s => s.Grade).ToList();

            return string.Join(Environment.NewLine, result);
        }

        private static string AgeGroupAvgGrade(List<Student> students)
        {
            var result = students
                .GroupBy(s => s.Age)
                .Select(s => new
                {
                    Age = s.Key,
                    Count = s.Count(),
                    AverageGrade = s.Average(g => g.Grade),
                }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var group in result)
            {
                sb.AppendLine($"Age group: {group.Age}")
                  .AppendLine($"-Students count: {group.Count}")
                  .AppendLine($"-Average grade: {group.AverageGrade:F2}");
            }

            return sb.ToString().Trim(); ;
        }

        private static string HighestStudentGrade(List<Student> students)
            => students.MaxBy(s => s.Grade).ToString();

        private static string TopLowestGrades(List<Student> students)
        {
            List<Student> result = students.OrderBy(s => s.Grade).Take(3).ToList();

            return string.Join(Environment.NewLine, result);
        }

        private static string PassedStudentsNames(List<Student> students, double grade)
        {
            List<string> result = students.Where(s => s.Grade >= grade).Select(s => s.Name).ToList();

            return string.Join(", ", result);
        }
    }
}
