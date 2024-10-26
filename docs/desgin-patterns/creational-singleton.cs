class ConfigurationManager
{
  private static ConfigurationManager instance;

  private ConfigurationManager() { }

  public static ConfigurationManager Instance
  {
    get { return (instance != null) ? instance : new ConfigurationManager(); }
  }

  public string GetConfig(string key) => $"Config value for {key}";
}

// Client
class Client
{
  public static void Main()
  {
    ConfigurationManager config = ConfigurationManager.Instance;
    Console.WriteLine(config.GetConfig("AppName"));
  }
}
