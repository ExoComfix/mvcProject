using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcProjectvs.Models;
using System.Diagnostics;
using System.Security.Claims;
using BCrypt;

namespace mvcProjectvs.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _db;
        public LoginController(
            DataContext db
        )
        {
            _db = db;
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
        public async Task<IActionResult> Login(User login)
        {

            var userControl = _db.Users.FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);
            if (userControl != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,login.Username)
                };  
                var useridentity = new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                return RedirectToAction("Index","Homepage");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Register() 
        {
            return View();
        }
        public async Task<IActionResult> Register(User register)
        {
            var userControl = _db.Users.FirstOrDefault(x => x.Username == register.Username);
            if (userControl == null)
            {
                await _db.AddAsync(register);
                await _db.SaveChangesAsync();
            };
            return RedirectToAction("Login", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}