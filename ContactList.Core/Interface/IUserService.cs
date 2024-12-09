using ContactList.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Core.Interface
{
    public interface IUserService
    {
        bool RegisterUser(RegisterViewModel register);
        bool IsEmailExist(string email);
        bool isUserNameExist(string username);
        bool ActiveUser(string activeCode);

         
    }
}
