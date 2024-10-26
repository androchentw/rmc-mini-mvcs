// Target interface
interface IVoltage
{
  void ProvideVoltage();
}

// Adaptee class
class OldVoltage
{
  public void ProvideOldVoltage() => Console.WriteLine("Providing 5V from old voltage.");
}

// Adapter class
class VoltageAdapter : IVoltage
{
  private readonly OldVoltage oldVoltage;

  public VoltageAdapter(OldVoltage oldVoltage)
  {
    this.oldVoltage = oldVoltage;
  }

  public void ProvideVoltage() => oldVoltage.ProvideOldVoltage();
}

// Client
class Client
{
  public static void Main()
  {
    OldVoltage oldVoltage = new OldVoltage();
    IVoltage voltage = new VoltageAdapter(oldVoltage);
    voltage.ProvideVoltage(); // Providing 5V from old voltage.
  }
}
