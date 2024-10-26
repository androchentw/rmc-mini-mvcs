class TextEditor
{
  public string Content { get; set; }

  public Memento Save() => new Memento(Content);

  public void Restore(Memento memento) => Content = memento.Content;
}

class Memento
{
  public string Content { get; }

  public Memento(string content) => Content = content;
}

class Caretaker
{
  private Memento memento;

  public void Save(TextEditor editor)
  {
    memento = editor.Save();
  }

  public void Restore(TextEditor editor)
  {
    editor.Restore(memento);
  }
}

class Client
{
  public static void Main()
  {
    TextEditor editor = new TextEditor();
    Caretaker caretaker = new Caretaker();

    editor.Content = "Version 1";
    caretaker.Save(editor);

    editor.Content = "Version 2";
    Console.WriteLine(editor.Content); // Version 2

    caretaker.Restore(editor);
    Console.WriteLine(editor.Content); // Version 1
  }
}
