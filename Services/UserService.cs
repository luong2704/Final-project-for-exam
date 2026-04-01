
using Campus.Models;

namespace Campus.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "123", Email = "admin@gmail.com", StudentId = "DTC001002003" },
            new User { Id = 2, Username = "user", Password = "123", Email = "user@gmail.com", StudentId = "DTC004005006" }
        };

        public User Login(string email, string password)
        {
            return _users.FirstOrDefault(u =>
                u.Email == email && u.Password == password);
        }
    }
}