using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Identity.Data;
using CRM.Identity.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRM.Identity.Controllers
{
    public class AuthController: Controller
    {
       // получаем сервис по управлению пользователями - UserManager и
       // сервис SignInManager, который позволяет аутентифицировать пользователя и устанавливать или удалять его куки.
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        //предназначен для предоставления служб, которые будут использоваться пользовательским интерфейсом для связи с IdentityServer, в основном относящихся к взаимодействию с пользователем. 
        private readonly IIdentityServerInteractionService _interactionService;//используется для logaut

        private CRM_Context _db;
        private Identity_Context _identity;
        //   public List<Personnel_Data> Personnel_Datas { get; set; }


        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IIdentityServerInteractionService interactionService, CRM_Context db, Identity_Context identity) =>
            (_signInManager, _userManager, _interactionService, _db, _identity) =
            (signInManager, userManager, interactionService, db, identity);

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.Username);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(viewModel.Username,
                viewModel.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Login error");
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            var viewModel = new RegisterViewModel
            {
                Appointment_Date= date
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var id = Guid.NewGuid();
            var user = new AppUser
            {
                ID_Personnal =id,
                UserName = viewModel.Username,
                Role=viewModel.Role,
                Name=viewModel.Name,
                Email=viewModel.Email,
                Last_Name=viewModel.Last_Name,
                Telefon=viewModel.Telefon,
                Appointment_Date=viewModel.Appointment_Date,
                Policy_Number=viewModel.Policy_Number,
                Position=viewModel.Position,
                Salary=viewModel.Salary
            };

            var person = new Personnel_Data
            {
                ID_Personnal = Guid.Parse(user.Id),
                UserName = viewModel.Username,
                Password = viewModel.Password,
                Name = viewModel.Name,
                Last_Name = viewModel.Last_Name,
                Email = viewModel.Email,
                Telefon = viewModel.Telefon,
                Position = viewModel.Role
            };
         
            var result = await _userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                _db.Personnel_Datas.Add(person);
                await _db.SaveChangesAsync();
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Get_Personnel");
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(viewModel);
          //  return RedirectToAction("Get_Personnel");
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect("http://localhost:3000");
        }

        [HttpGet]
        public IActionResult Get_Personnel()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _identity.Users.FirstOrDefaultAsync(e=>e.ID_Personnal==id);
            if (model == null)
            {
                return RedirectToAction("Get_Personnel");
            }
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EmployeeEditViewPersonnal input)
        {
            var employee = await _identity.Users.FirstOrDefaultAsync(e => e.ID_Personnal == id);

            //if (employee != null && ModelState.IsValid)
            //{
                employee.UserName = input.Username;
                employee.PasswordHash = input.Password;
                employee.Role = input.Role;
                employee.Email = input.Email;
                employee.Position = input.Position;
                employee.Telefon = input.Telefon;
                employee.Salary = input.Salary;

            await _identity.SaveChangesAsync();
            return RedirectToAction("Get_Personnel");
            //}
            //return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _identity.Users.FirstOrDefaultAsync(e => e.ID_Personnal == id);
            _identity.Users.Remove(user);
            await _identity.SaveChangesAsync();

 
            return RedirectToAction("Get_Personnel");
        }
    }
}
