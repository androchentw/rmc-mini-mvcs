// Subject
interface IWebPage
{
  void Display();
}

// Real Subject
class RealWebPage : IWebPage
{
  private readonly string url;

  public RealWebPage(string url)
  {
    this.url = url;
  }

  public void Display() => Console.WriteLine($"Displaying {url}");
}

// Proxy
class ProxyWebPage : IWebPage
{
  private readonly string url;
  private RealWebPage realWebPage;

  public ProxyWebPage(string url)
  {
    this.url = url;
  }

  public void Display()
  {
    if (realWebPage == null)
    {
      realWebPage = new RealWebPage(url);
    }
    Console.WriteLine("Proxy: Checking access...");
    realWebPage.Display();
  }
}

// Client
class Client
{
  public static void Main()
  {
    IWebPage page = new ProxyWebPage("http://example.com");
    page.Display(); // Proxy: Checking access...
                    // Displaying http://example.com
  }
}
