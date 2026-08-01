public class Rectangle: IShape
{
    public double Length { get; init; }
    public float Width { get; init; }

    public Rectangle(float length, float width)
    {
        Length = length;
        Width = width;
    }

    public double GetArea() => Length * Width;
    public void PrintArea() => Console.WriteLine($"Area of this Rectangle: {GetArea()}");

    
}