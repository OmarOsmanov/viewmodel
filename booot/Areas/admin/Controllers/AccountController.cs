using booot.Data;
using booot.Models;
using booot.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booot.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManeger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(AppDbContext context , UserManager<IdentityUser> userManeger, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManeger = userManeger;
          _signInManager = signInManager;
        }



        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(VmRegister model)
        {
            if (ModelState.IsValid)
            {
              var resault= await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (resault.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("", "email duzgun deyil!");
                    return View(model);
                }

            }


            return View(model);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(VmRegister model)
        {
            if (ModelState.IsValid)
            {

                CustomUser user = new CustomUser()
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    UserName = model.Email
                };


                var resault = await _userManeger.CreateAsync(user, model.Password);
                if (resault.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    foreach (var error in resault.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                    return View(model);
                }

            }


            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login");
        }

    }
}
