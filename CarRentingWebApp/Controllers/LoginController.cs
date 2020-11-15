using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarRentingWebApp.Models;
using CarRentingWebApp.Repository;
using CarRentingWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CarRentingWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext Context;
        private DataRepository<User> Repository;
        private readonly IMapper Mapper;

        private const string SessionUserId = "UserId";
        private const string SessionFirstName = "FirstName";
        private const string SessionLastName = "LastName";
        private const string SessionDateOfBirth = "DateOfBirth";
        private const string SessionGender = "Gender";
        private const string SessionEmail = "Email";
        private const string SessionUsername = "Username";
        private const string SessionPassword = "Password";
        private const string SessionIsAdmin = "IsAdmin";
        private const string SessionIsLoggedIn = "IsLoggedIn";
        
        public ClaimsIdentity userIdentity { get; set; }

        public LoginController(ApplicationDbContext context, IMapper mapper)
        {
            Repository = new DataRepository<User>(context);
            Context = context;
            Mapper = mapper;
            userIdentity = new ClaimsIdentity("Custom");
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["HasError"] = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserViewModel UserViewModel)
        {
            ViewData["HasError"] = true;
            User Model = new User();
            var MappedModel = Mapper.Map(UserViewModel, Model);
            var all = Repository.SelectAll().Result.ToList();
            User user = null;
            userIdentity.AddClaim(new Claim("type", "value"));

            foreach (var item in all)
            {
                if (item.Email.Trim() == Model.Email && item.Password.Trim() == Model.Password)
                {
                    user = item;
                    HttpContext.Session.SetInt32(SessionUserId, user.UserId);
                    HttpContext.Session.SetString(SessionFirstName, user.FirstName);
                    HttpContext.Session.SetString(SessionLastName, user.LastName);
                    HttpContext.Session.SetString(SessionDateOfBirth, user.DateOfBirth);
                    HttpContext.Session.SetString(SessionGender, user.Gender);
                    HttpContext.Session.SetString(SessionEmail, user.Email);
                    HttpContext.Session.SetString(SessionUsername, user.Username);
                    HttpContext.Session.SetString(SessionPassword, user.Password);
                    HttpContext.Session.SetString(SessionIsLoggedIn, "true");
                    if(item.Admin == true)
                    {
                        HttpContext.Session.SetString(SessionIsAdmin, "true");
                        return RedirectToAction("AdminAccount");
                    }
                    else
                    {
                        HttpContext.Session.SetString(SessionIsAdmin, "false");
                        return RedirectToAction("UserAccount");
                    }
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel UserViewModel)
        {
            User Model = new User();
            var MappedModel = Mapper.Map(UserViewModel, Model);
            await Repository.Insert(MappedModel);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult UserAccount()
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Username = HttpContext.Session.GetString(SessionUsername);

            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult AdminAccount()
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Username = HttpContext.Session.GetString(SessionUsername);

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserDetails(UserViewModel UserViewModel)
        {
            User Model = new User();
            var MappedModel = Mapper.Map(UserViewModel, Model);
            Model.Password = HttpContext.Session.GetString(SessionPassword);
            await Repository.Update(Model);
            return RedirectToAction("Index ", "Home");
        }
    }
}