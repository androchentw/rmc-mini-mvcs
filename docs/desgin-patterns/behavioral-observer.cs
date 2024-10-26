interface IWeatherObserver
{
  void Update(float temperature);
}

class WeatherStation
{
  private List<IWeatherObserver> observers = new List<IWeatherObserver>();
  private float temperature;

  public void Attach(IWeatherObserver observer) => observers.Add(observer);

  public void Detach(IWeatherObserver observer) => observers.Remove(observer);

  public void SetTemperature(float temperature)
  {
    this.temperature = temperature;
    NotifyObservers();
  }

  private void NotifyObservers()
  {
    foreach (var observer in observers)
    {
      observer.Update(temperature);
    }
  }
}

class TemperatureDisplay : IWeatherObserver
{
  public void Update(float temperature) => Console.WriteLine($"Temperature updated: {temperature}°C");
}

class Client
{
  public static void Main()
  {
    WeatherStation station = new WeatherStation();
    TemperatureDisplay display = new TemperatureDisplay();

    station.Attach(display);
    station.SetTemperature(25.0f);
    station.SetTemperature(30.0f);
  }
}
