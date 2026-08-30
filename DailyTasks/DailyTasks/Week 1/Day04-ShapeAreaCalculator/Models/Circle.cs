namespace DailyTasks.Week_1.Day04_ShapeAreaCalculator.Models
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius { get; set; }

        public override double GetArea()
            => Math.PI * Math.Pow(this.Radius, 2);

    }
}
