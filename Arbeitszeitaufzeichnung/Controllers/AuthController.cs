using Arbeitszeitaufzeichnung.Models;
using Arbeitszeitaufzeichnung.Models.ViewModels;
using Arbeitszeitaufzeichnung.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            EmployeeVM employeeVM = new EmployeeVM();

            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployeeVM employeeVM)
        {
            Employee employee = Mapping(employeeVM);

            await EmployeeService.CreateEmployeeAsync(employee);

            employee = EmployeeService.GetEmployeeByMail(employee.Email);

            await LoginSessionAsync(employee);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            EmployeeVM employeeVM = new EmployeeVM();

            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Login(EmployeeVM employeeVM)
        {
            Employee employee = Mapping(employeeVM);

            bool isLoggedIn = EmployeeService.CompareEmployee(employee);

            if (!isLoggedIn)
                return RedirectToAction("Login", "Auth");

            employee = EmployeeService.GetEmployeeByMail(employee.Email);

            await LoginSessionAsync(employee);
            
            return RedirectToAction("Index", "Time");
        }
        
        [NonAction]
        private async Task LoginSessionAsync(Employee employee)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Name, employee.FirstName + " " + employee.LastName),
                new Claim(ClaimTypes.Email, employee.Email),
                new Claim(ClaimTypes.Role, employee.Role.ToString()),
            };

            var meineIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProp = new AuthenticationProperties()
            {
                IsPersistent = true,
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(meineIdentity), authProp);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("Index", "Home");
        }

        private Employee Mapping(EmployeeVM employeeVM)
        {
            Employee employee = new Employee();

            employee.FirstName = employeeVM.FirstName;
            employee.LastName = employeeVM.LastName;
            employee.Email = employeeVM.Email;
            //employee.Guid = Guid.NewGuid();
            Guid? empGuid = EmployeeService.GetGuid(employee.Email);
            //if (empGuid != null)
            //    employee.Guid = empGuid != null ? empGuid!.Value : Guid.NewGuid();
            employee.Guid = empGuid ?? Guid.NewGuid();
            employee.Password = Hash(employeeVM.Password, employee.Guid);

            return employee;
        }

        private string Hash(string password, Guid guid)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password + guid.ToString()));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
