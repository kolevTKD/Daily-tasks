namespace DailyTasks.Week_1.Day04_ShapeAreaCalculator
{
    using System.Reflection;
    using System.Text;

    using Models;
    using Utilities;
    using Utilities.Attributes;

    [TaskDescription(@"Implement an abstract Shape class with concrete Circle and Rectangle subclasses, each calculating its own area polymorphically. The available shapes are discovered dynamically via reflection, and the user selects one and enters its required dimensions to see the calculated area.",
        "Select a shape by name (e.g. Circle, Rectangle) from the displayed list, then enter its required numeric dimensions when prompted (e.g. radius, width, height)")]
    public class Day04_ShapeAreaCalculator
    {
        [ProblemSolution]
        public static void ShapeCalculator()
        {
            string input = string.Empty;
            ConsoleColorHelper.WriteLineColored("Please select a shape to find the area of:", MessageTypes.Prompt);

            List<Type> shapeTypes = ShapeListMaker().ToList();
            StringBuilder sb = new StringBuilder();

            List<string> shapeNames = shapeTypes.Select(s => s.Name).ToList();

            foreach (string shape in shapeNames)
            {
                sb.AppendLine($"-{shape}");
            }
            sb.AppendLine("-Cancel");

            ConsoleColorHelper.WriteLineColored(sb.ToString().Trim(), MessageTypes.Prompt);

            while (input != "cancel")
            {
                input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsoleColorHelper.WriteLineColored("Invalid input, please try again.", MessageTypes.Error);
                    continue;
                }

                else if (input.ToLower() == "cancel")
                    break;

                else if (!shapeNames.Any(s => s.ToLower() == input.ToLower()))
                {
                    ConsoleColorHelper.WriteLineColored($"{input} is invalid shape, please try again.", MessageTypes.Error);
                    continue;
                }

                string shapeName = char.ToUpper(input[0]) + input.Substring(1).ToLower();
                Type shapeType = shapeTypes.FirstOrDefault(s => s.Name == shapeName)!;

                Shape shape = GetShape(shapeType);

                ConsoleColorHelper.WriteLineColored($"{shape.GetType().Name} area: {shape.GetArea():0.##}", MessageTypes.Result);
                ConsoleColorHelper.WriteLineColored("Please select another shape to find the area of:", MessageTypes.Prompt);
                ConsoleColorHelper.WriteLineColored(sb.ToString().Trim(), MessageTypes.Prompt);
            }

        }

        private static IEnumerable<Type> ShapeListMaker()
        {
            IEnumerable<Type> shapeTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(s => s.IsSubclassOf(typeof(Shape))
                && !s.IsAbstract
                && s.Namespace.Contains("Day04_ShapeAreaCalculator"));

            return shapeTypes;
        }

        private static Shape GetShape(Type shapeType)
        {
            ConstructorInfo constructor = shapeType.GetConstructors().First();
            ParameterInfo[] parameters = constructor.GetParameters();

            object[] args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                ConsoleColorHelper.WriteColored($"{parameters[i].Name}: ", MessageTypes.Prompt);

                bool isValid = double.TryParse(Console.ReadLine().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out double number);

                while (!isValid)
                {
                    ConsoleColorHelper.WriteLineColored("Invalid input, please enter a valid number.", MessageTypes.Error);
                    ConsoleColorHelper.WriteColored($"{parameters[i].Name}: ", MessageTypes.Prompt);
                    isValid = double.TryParse(Console.ReadLine(), out number);
                }

                args[i] = number;
            }

            return (Shape)Activator.CreateInstance(shapeType, args);
        }
    }
}
