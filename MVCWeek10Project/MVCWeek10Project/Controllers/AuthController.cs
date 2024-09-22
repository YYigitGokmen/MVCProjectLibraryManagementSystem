using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoAppPatika.Entities;
using ToDoAppPatika.Models;

namespace ToDoAppPatika.Controllers
{
    //I used OOP Principles
    public class AuthController : Controller
    {
        //AuthController: It will manage member-related
        //transactions and have the following action methods:
        public IActionResult About()
        {
            return View();
        }


        private static List<UserEntity> _users = new List<UserEntity>()
        {
            new UserEntity{ Id = 1, Email="." , Password = "."}
        };

        private readonly IDataProtector _dataProtector;
        public AuthController(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel formData)
        {
            // Check if the passwords match
            //A warning should be given when the passwords are not the same.
            if (formData.Password != formData.PasswordConfirm)
            {
                ViewBag.PasswordMismatch = "Passwords do not match.";
                return View(formData);
            }

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());
            if (user is not null)
            {
                ViewBag.Error = "This User already exists.";
                return View(formData);
            }

            var newUser = new UserEntity()
            {
                Id = _users.Max(x => x.Id) + 1,
                Email = formData.Email.ToLower(),
                Password = _dataProtector.Protect(formData.Password)
            };

            _users.Add(newUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel formData)
        {
            var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());

            // Check if the user exists
            if (user is null)
            {
                ViewBag.Error = "Username or password is incorrect.";
                return View(formData);
            }

            // Unprotect the stored password to compare
            var rawPassword = _dataProtector.Unprotect(user.Password);

            // Check if the provided password matches the stored password
            if (rawPassword == formData.Password)
            {
                // Create claims for the user (email, id, etc.)
                var claims = new List<Claim>
        {
            new Claim("email", user.Email),
            new Claim("id", user.Id.ToString())
        };

                // Set up identity with claims
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Set up authentication properties
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(48) // Set cookie expiration time
                };

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);

                // Redirect to homepage after successful login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If the password is incorrect
                ViewBag.Error = "Username or password is incorrect.";
                return View(formData);
            }
        }
            public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index","Home");
        }
    }
}
