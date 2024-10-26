// Flyweight
class Font
{
  public string FontName { get; }
  public Font(string fontName) => FontName = fontName;
}

// Flyweight Factory
class FontFactory
{
  private readonly Dictionary<string, Font> fonts = new Dictionary<string, Font>();

  public Font GetFont(string fontName)
  {
    if (!fonts.ContainsKey(fontName))
    {
      fonts[fontName] = new Font(fontName);
    }
    return fonts[fontName];
  }
}

// Client
class Client
{
  public static void Main()
  {
    FontFactory factory = new FontFactory();
    Font font1 = factory.GetFont("Arial");
    Font font2 = factory.GetFont("Arial");

    Console.WriteLine(ReferenceEquals(font1, font2)); // True
  }
}
