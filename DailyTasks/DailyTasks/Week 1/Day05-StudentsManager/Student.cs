namespace DailyTasks.Week_1.Day05_StudentsManager
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public override string ToString()
            => $"Student: {Name}{Environment.NewLine}Age: {Age}{Environment.NewLine}Grade: {Grade:F2}";
    }
}
