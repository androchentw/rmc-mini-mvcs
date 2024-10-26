// Prototype
abstract class Shape
{
  public abstract Shape Clone();
}

// Concrete Prototype
class Circle : Shape
{
  public override Shape Clone() => new Circle();
}

// Client
class Client
{
  public static void Main()
  {
    Shape circle = new Circle();
    Shape clonedCircle = circle.Clone();

    Console.WriteLine($"Circle cloned: {clonedCircle.GetType().Name}");
  }
}
