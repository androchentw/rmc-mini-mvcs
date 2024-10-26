// Component
interface ICoffee
{
  string GetDescription();
  double Cost();
}

// Concrete Component
class SimpleCoffee : ICoffee
{
  public string GetDescription() => "Simple Coffee";
  public double Cost() => 2.0;
}

// Decorator
abstract class CoffeeDecorator : ICoffee
{
  protected ICoffee coffee;

  protected CoffeeDecorator(ICoffee coffee)
  {
    this.coffee = coffee;
  }

  public abstract string GetDescription();
  public abstract double Cost();
}

// Concrete Decorator
class MilkDecorator : CoffeeDecorator
{
  public MilkDecorator(ICoffee coffee) : base(coffee) { }

  public override string GetDescription() => coffee.GetDescription() + ", Milk";
  public override double Cost() => coffee.Cost() + 0.5;
}

// Client
class Client
{
  public static void Main()
  {
    ICoffee coffee = new SimpleCoffee();
    coffee = new MilkDecorator(coffee);
    Console.WriteLine($"{coffee.GetDescription()} costs {coffee.Cost()}");
  }
}
