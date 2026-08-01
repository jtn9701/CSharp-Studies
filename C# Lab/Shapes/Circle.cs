public class Circle : IShape
{
    public double Radius { get; init; }

    public Circle(float radius)
    {
        Radius = radius;
    }

    public double GetArea() => Math.PI * Radius * Radius;
    public void PrintArea() => Console.WriteLine($"Area of this Circle: {GetArea()}");
}