// Implementor
interface IColor
{
  void ApplyColor();
}

// Concrete Implementor
class Red : IColor
{
  public void ApplyColor() => Console.WriteLine("Red color applied.");
}

// Concrete Implementor
class Green : IColor
{
  public void ApplyColor() => Console.WriteLine("Green color applied.");
}

// Abstraction
abstract class Shape
{
  protected IColor color;

  protected Shape(IColor color)
  {
    this.color = color;
  }

  public abstract void Draw();
}

// Refined Abstraction
class Circle : Shape
{
  public Circle(IColor color) : base(color) { }

  public override void Draw()
  {
    Console.Write("Drawing Circle. ");
    color.ApplyColor();
  }
}

// Client
class Client
{
  public static void Main()
  {
    Shape circle = new Circle(new Red());
    circle.Draw(); // Drawing Circle. Red color applied.
  }
}
