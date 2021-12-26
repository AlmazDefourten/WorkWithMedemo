using WorkWithMe.Models;
using WorkWithMe;
using Microsoft.EntityFrameworkCore;

namespace WorkWithMe.Services
{
    /// <summary>
    /// Сервис для работы с Users, имеет API для получения нужных данных
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Возвращает всех пользователей, отслеживание экземпляров не ведется
        /// </summary>
        public List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return (List<User>)db.Users.AsNoTracking();
            }
        }
    }
}
