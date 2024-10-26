interface ICommand
{
  void Execute();
}

class Light
{
  public void TurnOn() => Console.WriteLine("Light is ON");
  public void TurnOff() => Console.WriteLine("Light is OFF");
}

class TurnOnCommand : ICommand
{
  private Light light;

  public TurnOnCommand(Light light) => this.light = light;

  public void Execute() => light.TurnOn();
}

class TurnOffCommand : ICommand
{
  private Light light;

  public TurnOffCommand(Light light) => this.light = light;

  public void Execute() => light.TurnOff();
}

class RemoteControl
{
  private ICommand command;

  public void SetCommand(ICommand command) => this.command = command;

  public void PressButton() => command.Execute();
}

class Client
{
  public static void Main()
  {
    Light light = new Light();
    ICommand turnOn = new TurnOnCommand(light);
    ICommand turnOff = new TurnOffCommand(light);

    RemoteControl remote = new RemoteControl();

    remote.SetCommand(turnOn);
    remote.PressButton();

    remote.SetCommand(turnOff);
    remote.PressButton();
  }
}
