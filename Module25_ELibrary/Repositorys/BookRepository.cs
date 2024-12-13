using Module25_ELibrary.AppContext;
using Module25_ELibrary.PreparForTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_ELibrary.Repositorys
{
    internal class BookRepository
    {
        private readonly MyAppContext _context;

        public BookRepository(MyAppContext context) { _context = context; }

        /// <summary>
        /// Получает книги как объект по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Books GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }
        /// <summary>
        /// Вовзращает список всех книг
        /// </summary>
        /// <returns></returns>
        public List<Books> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        /// <summary>
        /// Добавляет книгу
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Books book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        /// <summary>
        /// Удаляет книгу
        /// </summary>
        /// <param name="id"></param>
        public void RemoveBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Обновляет год выпуска книги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newYear"></param>
        public void UpdateBookYear (int id, int newYear)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                book.YearOfRelease = newYear;
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Получать список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        public List <Books> GetBooksGenreAndBetweenYear(string genre, int startYear, int endYear)
        {
            return _context.Books
            .Where(b => b.BookGenre == genre &&
            b.YearOfRelease >= startYear &&
            b.YearOfRelease <=endYear).ToList();
        }
        /// <summary>
        /// Возвращает количество книг определенного автора
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public int GetCountAuthorBook(string author)
        {
            return _context.Books.Count(b => b.Author == author);
        }
        /// <summary>
        /// Возвращает количество книг определенного жанра.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public int GetCountGenreBook(string genre)
        {
            return _context.Books.Count(b => b.BookGenre == genre);
        }
        /// <summary>
        /// Проверяет есть ли книга определенного автора и с определенным название. Возвращает true or false
        /// </summary>
        /// <param name="author"></param>
        /// <param name="bookTitle"></param>
        /// <returns></returns>
        public bool HasBookByAuthorAndTitle(string author, string bookTitle)
        {
            return _context.Books.Any(b => b.Author == author && b.BookTitle == bookTitle);
        }
        /// <summary>
        /// Проверяет, есть ли определенная книга на руках у пользователя. Возвращает true or false
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsBookOnHandsOfUser (int bookId, int userId)
        {
            return _context.Books.Any(b => b.Id == bookId && b.Users != null && b.Users.Any(u => u.Id == userId));
        }
        /// <summary>
        /// Получение последней вышедшей книги
        /// </summary>
        /// <returns></returns>
        public Books GetLatestBook()
        {
            return _context.Books.OrderByDescending(b => b.YearOfRelease).FirstOrDefault();
        }
        /// <summary>
        /// получение списка всех книг, отсортированного в алфавитном порядке по названию
        /// </summary>
        /// <returns></returns>
        public List<Books> GetBooksSortedByTitle()
        {
            return _context.Books.OrderBy(b => b.BookTitle).ToList();
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <returns></returns>
        public List<Books> GetBooksSortedByYearDescending()
        {
            return _context.Books.OrderByDescending(b => b.YearOfRelease).ToList();
        }
    }
}
