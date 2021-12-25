using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkWithMe.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        public string Nick { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }

        public string Password { get; set; } // Для логина используется email

        public string Email { get; set; }
        public bool isEmailShowing { get; set; }

        public string? PhoneNumber { get; set; }
        public bool? isNumberShowing { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? isMale { get; set; }

        // Ссылки на соцсети
        public string? VKLink { get; set; }
        public string? TelegramNick { get; set; }

        Dictionary<int, string>? Tags { get; set; }

        public User(string Nick, string Password, string Email)
        {
            this.Nick = Nick;
            this.Password = Password;
            this.Email = Email;
        }
        public User() { }
    }
}
