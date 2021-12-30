using WorkWithMe.Models;

namespace WorkWithMe.Services.Users
{
    /// <summary>
    /// Сервис для работы с Users, имеет API для получения нужных данных
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Возвращает всех пользователей, отслеживание экземпляров не ведется
        /// </summary>
        public List<User> GetAllUsers();
        /// <summary>
        /// Геттер для юзера по первичному ключу
        /// </summary>
        /// <param name="id">Ключ для поиска пользователя</param>
        /// <returns>Возвращает экземпляр найденного пользователя без отслеживания</returns>
        public User GetUser(int id);
        public Task AddNewUserAsync(User user);
        public Task DeleteUserAsync(User user);
    }
}
