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
        List<Books> _book = new List<Books>();
        /// <summary>
        /// Получает книги как объект по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Books GetBookById(int id)
        {
            return _book.FirstOrDefault(b => b.Id == id);
        }
        /// <summary>
        /// Вовзращает список всех книг
        /// </summary>
        /// <returns></returns>
        public List<Books> GetAllBooks()
        {
            return _book;
        }
        /// <summary>
        /// Добавляет книгу
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Books book)
        {
            _book.Add(book);
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
                _book.Remove(book);
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
            return _book.Where(b => b.BookGenre == genre &&
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
            return _book.Where(b => b.Author == author).Count();
        }
        /// <summary>
        /// Возвращает количество книг определенного жанра.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public int GetCountGenreBook(string genre)
        {
            return _book.Where(b => b.BookGenre == genre).Count();
        }
        /// <summary>
        /// Проверяет есть ли книга определенного автора и с определенным название. Возвращает true or false
        /// </summary>
        /// <param name="author"></param>
        /// <param name="bookTitle"></param>
        /// <returns></returns>
        public bool HasBookByAuthorAndTitle(string author, string bookTitle)
        {
            return _book.Any(b => b.Author == author && b.BookTitle == bookTitle);
        }
        /// <summary>
        /// Проверяет, есть ли определенная книга на руках у пользователя. Возвращает true or false
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsBookOnHandsOfUser (int bookId, int userId)
        {
            return _book.Any(b => b.Id == bookId && b.Users != null && b.Users.Any(u => u.Id == userId));
        }
        /// <summary>
        /// Получение последней вышедшей книги
        /// </summary>
        /// <returns></returns>
        public Books GetLatestBook()
        {
            return _book.OrderByDescending(b => b.YearOfRelease).FirstOrDefault();
        }
        /// <summary>
        /// получение списка всех книг, отсортированного в алфавитном порядке по названию
        /// </summary>
        /// <returns></returns>
        public List<Books> GetBooksSortedByTitle()
        {
            return _book.OrderBy(b => b.BookTitle).ToList();
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <returns></returns>
        public List<Books> GetBooksSortedByYearDescending()
        {
            return _book.OrderByDescending(b => b.YearOfRelease).ToList();
        }
    }
}
