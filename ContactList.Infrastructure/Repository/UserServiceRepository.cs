using ContactList.Core.Domain;
using ContactList.Core.Interface;
using ContactList.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Infrastructure.Repository
{
    public class UserServiceRepository : IUserService
    {
        IUserRepository _repository;
        public UserServiceRepository(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool ActiveUser(string activeCode)
        {
            var user = _repository.GetUserByActiveCode(activeCode);
            if (user == null)
            {
                return false;
            }
            user.isActive = true;
            user.ActiveCode = Guid.NewGuid().ToString();

            _repository.EditUser(user);
            _repository.SaveUser();
            return true;
        }

        public bool IsEmailExist(string email)
        {
            string _email = email.ToLower().Trim();
            return _repository.isEmailExist(_email);
        }

        public bool isUserNameExist(string username)
        {
            return _repository.isUserNameExist(username);
        }

        public bool RegisterUser(RegisterViewModel register)
        {

            User user = new User();
            user.Name = register.Name;
            user.Email = register.Email.ToLower().Trim();
            user.PhoneNumber = register.PhoneNumber;
            user.Password = register.Password;
            user.isActive =false;
            user.IsAdmin = false;
            user.ActiveCode = Guid.NewGuid().ToString();

            _repository.AddUser(user);
            _repository.SaveUser();
            return true;

        }

        
    }
}
