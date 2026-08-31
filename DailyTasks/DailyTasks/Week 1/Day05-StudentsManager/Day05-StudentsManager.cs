using System.Text;

namespace DailyTasks.Week_1.Day05_StudentsManager
{
    public class Day05_StudentsManager
    {
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
        }

        private static string OrderedByGrade(List<Student> students, double grade)
        {
           List<Student> result =  students.Where(g => g.Grade >= grade).OrderByDescending(s => s.Grade).ToList();

            return string.Join(Environment.NewLine, result);
        }

        private static string AgeGroupAvgGrade(List<Student> students)
        {
            var result = students
                .AsEnumerable()
                .GroupBy(s => s.Age)
                .Select(s => new
                {
                    Age = s.Key,
                    AverageGrade = s.Average(g => g.Grade),
                }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var group in result)
            {
                sb.AppendLine($"-Age group: {group.Age}")
                  .AppendLine($"Average grade: {group.AverageGrade:F2}");
            }

            return sb.ToString().Trim(); ;
        }

        private static string HighestStudentGrade(List<Student> students)
            => students.MaxBy(s => s.Grade).ToString();

        private static string TopLowestGrades(List<Student> students)
        {
            List<Student> result = students.OrderByDescending(s => s.Grade).Take(3).ToList();

            return string.Join(Environment.NewLine, result);
        }

        private static string PassedStudentsNames(List<Student> students, double grade)
        {
            List<string> result = students.Where(s => s.Grade >= grade).Select(s => s.Name).ToList();

            return string.Join(", ", result);
            
        }
    }
}
