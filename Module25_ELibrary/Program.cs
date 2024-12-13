using Module25_ELibrary.AppContext;
using Module25_ELibrary.Repositorys;


using (var db = new MyAppContext())
{
    var bookRepository = new BookRepository(db);
    var userRepository = new UserRepository(db);

    bookRepository.AddBook(new Module25_ELibrary.PreparForTable.Books { YearOfRelease = 1965, Author = "Tomas", BookGenre = "Horor", BookTitle = "IT" });
    bookRepository.AddBook(new Module25_ELibrary.PreparForTable.Books { YearOfRelease = 2000, Author = "Alise", BookGenre = "Horor", BookTitle = "WTF" });
    var listbooks = bookRepository.GetAllBooks();

    foreach (var book in listbooks)
    {
        Console.WriteLine($"id {book.Id} Автор {book.Author} название {book.BookTitle}" );
       
        
    }
}