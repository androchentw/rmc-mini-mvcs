abstract class Logger
{
  protected Logger nextLogger;

  public void SetNext(Logger next)
  {
    nextLogger = next;
  }

  public void Log(string message, LogLevel level)
  {
    if (CanHandle(level))
    {
      WriteMessage(message);
    }
    else if (nextLogger != null)
    {
      nextLogger.Log(message, level);
    }
  }

  protected abstract bool CanHandle(LogLevel level);
  protected abstract void WriteMessage(string message);
}

class ConsoleLogger : Logger
{
  protected override bool CanHandle(LogLevel level) => level == LogLevel.Info;

  protected override void WriteMessage(string message) => Console.WriteLine($"Info: {message}");
}

class ErrorLogger : Logger
{
  protected override bool CanHandle(LogLevel level) => level == LogLevel.Error;

  protected override void WriteMessage(string message) => Console.WriteLine($"Error: {message}");
}

enum LogLevel { Info, Error }

class Client
{
  public static void Main()
  {
    Logger logger1 = new ConsoleLogger();
    Logger logger2 = new ErrorLogger();
    logger1.SetNext(logger2);

    logger1.Log("This is an information message.", LogLevel.Info);
    logger1.Log("This is an error message.", LogLevel.Error);
  }
}
