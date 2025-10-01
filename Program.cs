using System;
using System.Collections.Generic;

class Book { public string Title; public string Author; public string ISBN; public int Copies; }
class Reader { public string Name; public int Id; }

class Library
{
    List<Book> books = new List<Book>();
    List<Reader> readers = new List<Reader>();

    public void AddBook(Book b) => books.Add(b);
    public void RemoveBook(string isbn) => books.RemoveAll(x => x.ISBN == isbn);
    public void RegisterReader(Reader r) => readers.Add(r);

    public void GiveBook(string isbn, int readerId)
    {
        var b = books.Find(x => x.ISBN == isbn);
        var r = readers.Find(x => x.Id == readerId);
        if (b != null && r != null && b.Copies > 0) { b.Copies--; Console.WriteLine($"{r.Name} взял {b.Title}"); }
        else Console.WriteLine("Ошибка");
    }

    public void ReturnBook(string isbn)
    {
        var b = books.Find(x => x.ISBN == isbn);
        if (b != null) { b.Copies++; Console.WriteLine($"{b.Title} возвращена"); }
    }
}

class Program
{
    static void Main()
    {
        var lib = new Library();
        lib.AddBook(new Book { Title="Война и мир", Author="Толстой", ISBN="111", Copies=2 });
        lib.AddBook(new Book { Title="Преступление и наказание", Author="Достоевский", ISBN="222", Copies=1 });
        lib.RegisterReader(new Reader { Name="Иван", Id=1 });
        lib.RegisterReader(new Reader { Name="Мария", Id=2 });
        lib.GiveBook("111", 1);
        lib.GiveBook("222", 2);
        lib.GiveBook("222", 1);
        lib.ReturnBook("111");
    }
}
