namespace DailyTasks.Utilities.Attributes
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
