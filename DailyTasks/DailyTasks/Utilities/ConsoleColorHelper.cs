namespace DailyTasks.Utilities
{
    public class ConsoleColorHelper
    {
        public static void WriteLineColored(string text, MessageTypes messageType)
        {
            Console.ForegroundColor = messageType switch
            {
                MessageTypes.Prompt => ConsoleColor.Cyan,
                MessageTypes.Description => ConsoleColor.Blue,
                MessageTypes.InputFormat => ConsoleColor.Blue,
                MessageTypes.Result => ConsoleColor.Green,
                MessageTypes.Error => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White
            };

            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
