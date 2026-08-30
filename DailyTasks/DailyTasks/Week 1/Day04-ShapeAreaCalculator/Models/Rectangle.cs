namespace DailyTasks.Week_1.Day04_ShapeAreaCalculator.Models
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double GetArea()
            => this.Width * this.Height;
    }
}
