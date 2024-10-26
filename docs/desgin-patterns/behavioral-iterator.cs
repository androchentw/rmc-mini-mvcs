interface IIterator<T>
{
  bool HasNext();
  T Next();
}

interface IAggregate<T>
{
  IIterator<T> CreateIterator();
}

class Book
{
  public string Title { get; set; }

  public Book(string title) => Title = title;
}

class Library : IAggregate<Book>
{
  private List<Book> books = new List<Book>();

  public void AddBook(Book book) => books.Add(book);

  public IIterator<Book> CreateIterator() => new LibraryIterator(this);

  public int Count => books.Count;
  public Book this[int index] => books[index];
}

class LibraryIterator : IIterator<Book>
{
  private Library library;
  private int index = 0;

  public LibraryIterator(Library library) => this.library = library;

  public bool HasNext() => index < library.Count;

  public Book Next() => library[index++];
}

class Client
{
  public static void Main()
  {
    Library library = new Library();
    library.AddBook(new Book("C# Programming"));
    library.AddBook(new Book("Design Patterns"));

    IIterator<Book> iterator = library.CreateIterator();
    while (iterator.HasNext())
    {
      Console.WriteLine(iterator.Next().Title);
    }
  }
}
