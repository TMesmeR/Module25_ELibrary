using Microsoft.EntityFrameworkCore;
using Module25_ELibrary.AppContext;
using Module25_ELibrary.PreparForTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_ELibrary.Repositorys
{
    internal class UserRepository
    {
        private readonly MyAppContext _context;

        public UserRepository(MyAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ищет объект юзера по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает одного юзера в виде объекта Users</returns>
        public Users GetUserById (int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        /// <summary>
        /// Получите всех юзеров из таблицы
        /// </summary>
        /// <returns>Возвращает List<Users></returns>
        public List<Users> GetAllUsers()
        {
            return _context.Users.ToList();
        }
       /// <summary>
       /// Добавление нового юзера в бд
       /// </summary>
       /// <param name="user"></param>
        public void AddUser (Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        /// <summary>
        /// Удаление юзера по id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveUser (int id)
        {
            var user = GetUserById (id);
            if (user != null)
                _context.Users.Remove(user);
                _context.SaveChanges ();
        }
        /// <summary>
        /// Обновление имени юзверя по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName">новое имя</param>
        public void UpdateUser (int id, string newName)
        {
            var user = GetUserById (id);
            if (user != null)
            {
                user.Name = newName;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Получает количество книг на руках у пользователя или возращает 0
        /// </summary>
        /// <param name="id">Ид юзера</param>
        /// <returns></returns>
        public int GetCountBooksOnHands(int id)
        {
            var user = _context.Users
                .Include(u => u.Books)
                .FirstOrDefault(u => u.Id == id);
            return user?.Books?.Count ?? 0;
        }
    }
}
