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
        public Task AddNewUserAsync(User user);
        public Task DeleteUserAsync(User user);
    }
}
