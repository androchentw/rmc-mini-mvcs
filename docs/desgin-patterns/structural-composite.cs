// Component
abstract class FileSystemComponent
{
  public abstract void ShowDetails();
}

// Leaf
class File : FileSystemComponent
{
  private readonly string name;

  public File(string name)
  {
    this.name = name;
  }

  public override void ShowDetails() => Console.WriteLine($"File: {name}");
}

// Composite
class Directory : FileSystemComponent
{
  private readonly string name;
  private readonly List<FileSystemComponent> components = new List<FileSystemComponent>();

  public Directory(string name)
  {
    this.name = name;
  }

  public void Add(FileSystemComponent component) => components.Add(component);

  public override void ShowDetails()
  {
    Console.WriteLine($"Directory: {name}");
    foreach (var component in components)
    {
      component.ShowDetails();
    }
  }
}

// Client
class Client
{
  public static void Main()
  {
    Directory root = new Directory("Root");
    Directory subDir = new Directory("SubDirectory");

    root.Add(new File("File1.txt"));
    root.Add(subDir);
    subDir.Add(new File("File2.txt"));

    root.ShowDetails();
  }
}
