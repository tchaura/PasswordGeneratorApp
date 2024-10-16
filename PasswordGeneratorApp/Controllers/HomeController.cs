using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApp.Models;
using PasswordGeneratorApp.Utils;

namespace PasswordGeneratorApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PasswordOptions());
        }

        [HttpPost]
        public IActionResult GeneratePassword(PasswordOptions options)
        {
            var passwordGenerator = new Utils.PasswordGenerator(options);
            var password = passwordGenerator.GetPassword();
            var passwordStrengthCalculator = new PasswordStrengthCalculator(password);

            var generatedPassword = new GeneratedPassword
            {
                Password = password,
                Strength = passwordStrengthCalculator.GetStrength()
            };

            return PartialView("_GeneratePasswordPartial", generatedPassword);
        }
    }
}