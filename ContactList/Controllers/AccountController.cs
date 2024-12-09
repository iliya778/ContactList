using ContactList.Core.Domain;
using ContactList.Core.Interface;
using ContactList.Core.ViewModel;
using ContactList.Infrastructure.Context;
using ContactList.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;

namespace ContactList.Controllers
{
    public class AccountController : Controller
    {
        ContactDbContext _context;
        IUserService _userService;
        IUserRepository _userRepository;
        public AccountController(ContactDbContext context, IUserService userService, IUserRepository userRepository)
        {
            _context = context;
            _userService = userService;
            _userRepository = userRepository;
        }

        #region register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (_userService.IsEmailExist(user.Email))
            {
                ModelState.AddModelError("Email", "ایمیل تکراری می باشد");
                return View(user);
            }

            if (_userService.isUserNameExist(user.Name))
            {
                ModelState.AddModelError("Name", "ایمیل تکراری می باشد");
                return View(user);
            }
            _userService.RegisterUser(user);

            return RedirectToAction("List");

        }
        #endregion

        #region ActiveAccount
        public IActionResult ActiveAccount(string activeCode)
        {
            var res = _userService.ActiveUser(activeCode);

            return View(res);
        }
        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if(!ModelState.IsValid)
            { 
                return View(login); 
            }
            var user = _context.Users.SingleOrDefault
                (u => u.Email == login.Email.ToLower().Trim()&&
                u.Password == login.Password);

            if (user == null)
            {
                ModelState.AddModelError("Email", "اطلاعات صحیح نیست");
                return View(login);
            }

            if (!user.isActive)
            {
                ModelState.AddModelError("Email", "حساب کاربری فعال نشده است");
                return View(login);

            }

            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim("IsAdmin",user.IsAdmin.ToString()),
                    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }



        #endregion

        #region Sign Out
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
        #endregion


    }
}
