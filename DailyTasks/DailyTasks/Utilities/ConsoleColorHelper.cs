namespace DailyTasks.Utilities
{
    public class ConsoleColorHelper
    {
        public static void WriteColored(string text, MessageType messageType)
        {
            Console.ForegroundColor = messageType switch
            {
                MessageType.Prompt => ConsoleColor.Cyan,
                MessageType.Description => ConsoleColor.DarkGreen,
                MessageType.InputFormat => ConsoleColor.DarkGreen,
                MessageType.Result => ConsoleColor.Green,
                MessageType.Error => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White
            };

            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
