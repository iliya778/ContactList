using ContactList.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Core.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int userId);
        User GetUserByActiveCode(string activeCode);
        int AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);
        void DeleteUser(User user);
        bool isUserNameExist(string userName);
        bool isEmailExist(string Email);
        void SaveUser();
    }
}
