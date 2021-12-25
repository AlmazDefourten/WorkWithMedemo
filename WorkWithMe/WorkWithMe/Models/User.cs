namespace WorkWithMe.Models
{
    public class User
    {
        public string Nick;
        public string? Name;
        public string? LastName;

        public string Password; // Для логина используется email

        public string Email;
        public bool isEmailShowing;

        public string? PhoneNumber;
        public bool? isNumberShowing;

        public string? Country;
        public string? City;

        public DateTime? DateOfBirth;

        public bool? isMale;

        // Ссылки на соцсети
        public string? VKLink;
        public string? TelegramNick;

        Dictionary<int, string>? Tags;
    }
}
