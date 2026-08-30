namespace DailyTasks.Utilities
{
    public class ConsoleColorHelper
    {
        public static void WriteLineColored(string text, MessageTypes messageTypes)
        {
            ColorSelector(messageTypes);

            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteColored(string text, MessageTypes messageTypes)
        {
            ColorSelector(messageTypes);

            Console.Write(text);
            Console.ResetColor();
        }

        private static ConsoleColor ColorSelector(MessageTypes messageTypes)
        {
            return Console.ForegroundColor = messageTypes switch
            {
                MessageTypes.Prompt => ConsoleColor.Cyan,
                MessageTypes.Description => ConsoleColor.DarkBlue,
                MessageTypes.InputFormat => ConsoleColor.DarkBlue,
                MessageTypes.Result => ConsoleColor.Green,
                MessageTypes.Error => ConsoleColor.DarkYellow,
                MessageTypes.TaskLabel => ConsoleColor.DarkCyan,
                _ => ConsoleColor.White
            };
        }
    }
}
