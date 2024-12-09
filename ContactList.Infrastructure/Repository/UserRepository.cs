using ContactList.Core.Domain;
using ContactList.Core.Interface;
using ContactList.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        ContactDbContext _context;
        public UserRepository(ContactDbContext context)
        {
            _context = context;
        }
        public int AddUser(User user)
        {
            _context.Users.Add(user);
            return user.UserId;
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            _context.Users.Remove(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public void EditUser(User user)
        {
            _context.Users.Update(user);
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.Users;
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public bool isEmailExist(string Email)
        {
            return _context.Users.Any(u => u.Email == Email);
        }

        public bool isUserNameExist(string userName)
        {
            return _context.Users.Any(u => u.Name == userName);
        }

        public void SaveUser()
        {
            _context.SaveChanges();
        }
    }
}
