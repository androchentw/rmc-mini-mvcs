// Abstract Product
interface IButton
{
  void Render();
}

// Abstract Product
interface ITextBox
{
  void Render();
}

// Concrete Product
class WinButton : IButton
{
  public void Render() => Console.WriteLine("Windows Button rendered.");
}

// Concrete Product
class WinTextBox : ITextBox
{
  public void Render() => Console.WriteLine("Windows TextBox rendered.");
}

// Concrete Product
class MacButton : IButton
{
  public void Render() => Console.WriteLine("Mac Button rendered.");
}

// Concrete Product
class MacTextBox : ITextBox
{
  public void Render() => Console.WriteLine("Mac TextBox rendered.");
}

// Abstract Factory
interface IGUIFactory
{
  IButton CreateButton();
  ITextBox CreateTextBox();
}

// Concrete Factory
class WinFactory : IGUIFactory
{
  public IButton CreateButton() => new WinButton();
  public ITextBox CreateTextBox() => new WinTextBox();
}

// Concrete Factory
class MacFactory : IGUIFactory
{
  public IButton CreateButton() => new MacButton();
  public ITextBox CreateTextBox() => new MacTextBox();
}

// Client
class Client
{
  public static void Main()
  {
    IGUIFactory factory = new WinFactory(); // Or MacFactory
    IButton button = factory.CreateButton();
    ITextBox textBox = factory.CreateTextBox();

    button.Render();
    textBox.Render();
  }
}
