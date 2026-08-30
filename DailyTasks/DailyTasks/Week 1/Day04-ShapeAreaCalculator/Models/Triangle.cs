namespace DailyTasks.Week_1.Day04_ShapeAreaCalculator.Models
{
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double @base, double height)
        {
            this.Base = @base;
            this.Height = height;
        }
        public override double GetArea()
            => (this.Base * this.Height) / 2;
    }
}
