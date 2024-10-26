interface IChatMediator
{
  void SendMessage(string message, User user);
}

class ChatMediator : IChatMediator
{
  private List<User> users = new List<User>();

  public void RegisterUser(User user) => users.Add(user);

  public void SendMessage(string message, User user)
  {
    foreach (var u in users)
    {
      if (u != user)
      {
        u.Receive(message);
      }
    }
  }
}

class User
{
  private IChatMediator mediator;
  public string Name { get; }

  public User(IChatMediator mediator, string name)
  {
    this.mediator = mediator;
    Name = name;
  }

  public void Send(string message) => mediator.SendMessage(message, this);
  public void Receive(string message) => Console.WriteLine($"{Name} received: {message}");
}

class Client
{
  public static void Main()
  {
    ChatMediator mediator = new ChatMediator();

    User user1 = new User(mediator, "Alice");
    User user2 = new User(mediator, "Bob");
    mediator.RegisterUser(user1);
    mediator.RegisterUser(user2);

    user1.Send("Hello, Bob!");
    user2.Send("Hello, Alice!");
  }
}
