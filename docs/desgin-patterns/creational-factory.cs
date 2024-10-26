// Product
abstract class Animal
{
  public abstract void Speak();
}

// Concrete Product
class Dog : Animal
{
  public override void Speak() => Console.WriteLine("Woof!");
}

// Concrete Product
class Cat : Animal
{
  public override void Speak() => Console.WriteLine("Meow!");
}

// Factory
class AnimalFactory
{
  public static Animal CreateAnimal(string type)
  {
    return type switch
    {
      "dog" => new Dog(),
      "cat" => new Cat(),
      _ => null
    };
  }
}

// Client
class Client
{
  public static void Main()
  {
    Animal dog = AnimalFactory.CreateAnimal("dog");
    dog.Speak(); // Woof!

    Animal cat = AnimalFactory.CreateAnimal("cat");
    cat.Speak(); // Meow!
  }
}
