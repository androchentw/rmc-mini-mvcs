interface IShapeVisitor
{
  void Visit(Circle circle);
  void Visit(Square square);
}

interface IShape
{
  void Accept(IShapeVisitor visitor);
}

class Circle : IShape
{
  public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

class Square : IShape
{
  public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

class ShapeVisitor : IShapeVisitor
{
  public void Visit(Circle circle) => Console.WriteLine("Processing Circle");

  public void Visit(Square square) => Console.WriteLine("Processing Square");
}

class Client
{
  public static void Main()
  {
    IShape[] shapes = { new Circle(), new Square() };
    IShapeVisitor visitor = new ShapeVisitor();

    foreach (var shape in shapes)
    {
      shape.Accept(visitor);
    }
  }
}
