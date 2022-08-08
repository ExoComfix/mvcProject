using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcProjectvs.Models;
using System.Diagnostics;
using System.Security.Claims;
using mvcProjectvs.Services;

namespace mvcProjectvs.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _db;
        private readonly MailService _mailService;
        public LoginController(
            DataContext db,
            MailService mailService
        )
        {
            _db = db;
            _mailService = mailService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Login(User login)
        {

            var userControl = _db.Users.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (userControl != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,login.Email)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                return RedirectToAction("Index", "Homepage");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User register)
        {
            var userControl = _db.Users.FirstOrDefault(x => x.Email == register.Email);
            if (userControl == null)
            {
                await _db.AddAsync(register);
                await _db.SaveChangesAsync();
                _mailService.SendWelcomeMail(register.Email);
            }
            else
            {
                return View(register);
            };
            return RedirectToAction("Login", "Login");

        }
        public IActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Forgot(User forgot)
        {
            var userControl = _db.Users.FirstOrDefault(x => x.Email == forgot.Email);
            if (userControl != null)
            {

                _mailService.SendForgotMail(forgot.Email);
            }
            return RedirectToAction("Login", "Login");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}