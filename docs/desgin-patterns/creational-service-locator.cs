class ServiceLocator
{
  private static Dictionary<string, object> services = new Dictionary<string, object>();

  public static void RegisterService(string name, object service) =>
    services[name] = service;

  public static T GetService<T>(string name) => (T)services[name];
}

// Client Service
class EmailService
{
  public void SendEmail(string message) => Console.WriteLine($"Email sent: {message}");
}

// Client
class Client
{
  public static void Main()
  {
    EmailService emailService = new EmailService();
    ServiceLocator.RegisterService("EmailService", emailService);

    var service = ServiceLocator.GetService<EmailService>("EmailService");
    service.SendEmail("Hello World!");
  }
}
