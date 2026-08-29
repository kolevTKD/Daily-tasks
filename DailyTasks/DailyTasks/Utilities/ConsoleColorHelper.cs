namespace DailyTasks.Utilities
{
    public class ConsoleColorHelper
    {
        public static void WriteColored(string text, MessageType messageType)
        {
            Console.ForegroundColor = messageType switch
            {
                MessageType.Prompt => ConsoleColor.Cyan,
                MessageType.Description => ConsoleColor.Blue,
                MessageType.InputFormat => ConsoleColor.Blue,
                MessageType.Result => ConsoleColor.Green,
                MessageType.Error => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White
            };

            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
