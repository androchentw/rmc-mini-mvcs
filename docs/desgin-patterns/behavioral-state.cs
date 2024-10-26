interface IElevatorState
{
  void PressButton(Elevator elevator);
}

class Elevator
{
  public IElevatorState State { get; set; }

  public Elevator(IElevatorState state) => State = state;

  public void PressButton() => State.PressButton(this);
}

class MovingUpState : IElevatorState
{
  public void PressButton(Elevator elevator)
  {
    Console.WriteLine("Elevator is moving up.");
    elevator.State = new MovingDownState();
  }
}

class MovingDownState : IElevatorState
{
  public void PressButton(Elevator elevator)
  {
    Console.WriteLine("Elevator is moving down.");
    elevator.State = new MovingUpState();
  }
}

class Client
{
  public static void Main()
  {
    Elevator elevator = new Elevator(new MovingUpState());
    elevator.PressButton(); // Elevator is moving up.
    elevator.PressButton(); // Elevator is moving down.
  }
}
