class Book
{
  public string Title { get; set; }
  public string Author { get; set; }
}

class LibrarySystem
{
  public void BorrowBook(Book book) => Console.WriteLine($"Borrowed: {book.Title} by {book.Author}");
}

// Facade
class LibraryFacade
{
  private readonly LibrarySystem librarySystem;

  public LibraryFacade()
  {
    librarySystem = new LibrarySystem();
  }

  public void Borrow(string title, string author)
  {
    Book book = new Book { Title = title, Author = author };
    librarySystem.BorrowBook(book);
  }
}

// Client
class Client
{
  public static void Main()
  {
    LibraryFacade library = new LibraryFacade();
    library.Borrow("The Great Gatsby", "F. Scott Fitzgerald");
  }
}
