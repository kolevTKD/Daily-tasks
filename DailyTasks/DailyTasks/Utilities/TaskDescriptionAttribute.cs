namespace DailyTasks.Utilities
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TaskDescriptionAttribute : Attribute
    {
        public TaskDescriptionAttribute(string description, string inputFormat)
        {
            this.Description = description;
            this.InputFormat = inputFormat;
        }
        public string Description { get; set; }
        public string InputFormat { get; set; }
    }
}
