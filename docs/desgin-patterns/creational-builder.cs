// Product
class Car
{
  public string Make { get; set; }
  public string Model { get; set; }
  public int Year { get; set; }

  public override string ToString() => $"{Year} {Make} {Model}";
}

// Builder
class CarBuilder
{
  private Car car = new Car();

  public CarBuilder SetMake(string make)
  {
    car.Make = make;
    return this;
  }

  public CarBuilder SetModel(string model)
  {
    car.Model = model;
    return this;
  }

  public CarBuilder SetYear(int year)
  {
    car.Year = year;
    return this;
  }

  public Car Build() => car;
}

// Client
class Client
{
  public static void Main()
  {
    Car car = new CarBuilder()
      .SetMake("Toyota")
      .SetModel("Corolla")
      .SetYear(2021)
      .Build();

    Console.WriteLine(car);
  }
}
