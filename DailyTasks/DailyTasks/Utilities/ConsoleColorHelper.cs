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
                MessageTypes.Description => ConsoleColor.Blue,
                MessageTypes.InputFormat => ConsoleColor.Blue,
                MessageTypes.Result => ConsoleColor.Green,
                MessageTypes.Error => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White
            };
        }
    }
}
