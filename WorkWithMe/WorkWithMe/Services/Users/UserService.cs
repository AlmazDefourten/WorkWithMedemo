using WorkWithMe.Models;
using WorkWithMe;
using Microsoft.EntityFrameworkCore;

namespace WorkWithMe.Services.Users
{
    /// <summary>
    /// Сервис для работы с Users, имеет API для получения нужных данных
    /// </summary>
    public class UserService : IUserService
    {
        public List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.AsNoTracking().ToList();
            }
        }

        public User GetUser(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
            }
        }

        // CRUD operations
        public async Task AddNewUserAsync(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }
        public async Task DeleteUserAsync(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task EditUserAsync(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
            }
        }
        // END of CRUD operations
    }
}
