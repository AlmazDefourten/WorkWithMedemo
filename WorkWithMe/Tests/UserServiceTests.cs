using NUnit.Framework;
using Moq;
using WorkWithMe.Services.Users;
using WorkWithMe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WorkWithMe.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        IUserService userService = new UserService();
        ApplicationContext db = new ApplicationContext();
        User user = new User() { Email = "aa@mail.ru", Nick = "testuser", Password = "testpassword" };

        [SetUp]
        public void Setup()
        {
            userService = new UserService();
            db = new ApplicationContext();
            user = new User() { Email = "aa@mail.ru", Nick = "testuser", Password = "testpassword" };
        }
        [Test]
        public void Add_New_User()
        {
            userService.AddNewUserAsync(user);
            User? userResult = db.Users.FirstOrDefault(u => u.Nick == user.Nick);
            bool result = (userResult.Nick == user.Nick) ? true : false;

            Assert.IsNotNull(userResult);
            Assert.AreEqual(result, true);

            userService.DeleteUserAsync(user);
        }

        [Test]
        public void Delete_User()
        {
            userService.AddNewUserAsync(user);
            User? userResult = db.Users.FirstOrDefault(u => u.Nick == user.Nick);
            Assert.IsNotNull(userResult);

            userService.DeleteUserAsync(userResult);
            db = new ApplicationContext();
            User? nullUser = db.Users.FirstOrDefault(u => u.Nick == user.Nick);

            Assert.IsNull(nullUser);
        }

        [Test]
        public void Is_Users_Returns_Withount_Tracking()
        {
            List<User> users = userService.GetAllUsers();
            Assert.AreNotEqual(users.Count, 0);

            User userForTesting = users[0];
            userForTesting.Nick = "anothernick"; // Изменяем свойство юзера чтоб проверить, отслеживаются ли изменения контекстом
            db.SaveChanges();
            users = userService.GetAllUsers();

            bool result = users[0] != userForTesting ? true : false;
            Assert.AreEqual(result, true);
        }
    }
}