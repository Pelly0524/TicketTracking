using System.Data;
using TicketTracking.DB;

namespace TicketTracking.Models
{

    public class User
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }
        public bool LoginStatus { get; set; }

        public User()
        {
            Id = string.Empty;
            Account = string.Empty;
            Password = string.Empty;
            Level = string.Empty;
            LoginStatus = false;
        }

        public void SetUser(string id, string account, string password, string level)
        {
            Id = id;
            Account = account;
            Password = password;
            Level = level;
            LoginStatus = true;
        }
    }

    public class LoginModel
    {
        public string account { get; set; }
        public string password { get; set; }

        public LoginModel()
        {
            account = string.Empty;
            password = string.Empty;
        }
    }
}
