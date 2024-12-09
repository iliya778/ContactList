using ContactList.Core.Domain;
using ContactList.Core.Interface;
using ContactList.Core.ViewModel;
using ContactList.Infrastructure.Context;
using ContactList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactList.Controllers
{
    public class HomeController : Controller
    {
        ContactDbContext _context;
        IUserService _userService;
        IUserRepository _userRepository;
        public HomeController(ContactDbContext context, IUserService userService, IUserRepository userRepository)
        {
            _context = context;
            _userService = userService;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View(_context.Users);
        }

        public IActionResult List()
        {
            return View();
        }

        
    }
}
