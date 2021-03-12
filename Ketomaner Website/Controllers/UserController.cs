using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ketomaner_Website.Models;
using Ketomaner_Website.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Ketomaner_Website.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<Users> userManager, SignInManager<Users> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("seeddata")]
        public async Task<IActionResult> SeedData()
        {
            //Seed roles

            var bruger = new IdentityRole();
            bruger.Name = "Bruger";

            await _roleManager.CreateAsync(bruger);


            var admin = new IdentityRole();
            admin.Name = "Admin";

            await _roleManager.CreateAsync(admin);

            //Seed Admin user
            var testUser = new Users
            {
                UserName = "Admin@something.dk",
                Email = "Admin@something.dk",
            };



            IdentityResult test3 = await _userManager.CreateAsync(testUser, "Dvl46tfx.");
            if (test3.Succeeded)
            {
                await _userManager.AddToRoleAsync(testUser, "Admin");
                await _signInManager.SignInAsync(testUser , isPersistent: false);
            }
            else
            {

            }
            return Ok();
        }

        [Route("OpretBruger")]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterUserVm model)
        {
            if (ModelState.IsValid)
            {


                var user = new Users
                {
                    Email = model.Email,
                    UserName = model.Username,
                    TEST = model.Test,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Bruger");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
