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
        private List<Users> _users = new List <Users>();

        /// <summary>
        /// Ищет объект юзера по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает одного юзера в виде объекта Users</returns>
        public Users GetUserById (int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
        /// <summary>
        /// Получите всех юзеров из таблицы
        /// </summary>
        /// <returns>Возвращает List<Users></returns>
        public List<Users> GEtAllUsers()
        {
            return _users;
        }
       /// <summary>
       /// Добавление нового юзера в бд
       /// </summary>
       /// <param name="user"></param>
        public void AddUser (Users user)
        {
            _users.Add(user);
        }
        /// <summary>
        /// Удаление юзера по id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveUser (int id)
        {
            var user = GetUserById (id);
            if (user != null) 
                _users.Remove(user);
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
            }
        }

        /// <summary>
        /// Получает количество книг на руках у пользователя или возращает 0
        /// </summary>
        /// <param name="id">Ид юзера</param>
        /// <returns></returns>
        public int GetCountBooksOnHands(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return user?.Books?.Count ?? 0;
        }
    }
}
