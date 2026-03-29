
using Campus.Models;

namespace Campus.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "123", Email = "admin@gmail.com" },
            new User { Id = 2, Username = "user", Password = "123", Email = "user@gmail.com" }
        };

        public User Login(string username, string password)
        {
            return _users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);
        }
    }
}