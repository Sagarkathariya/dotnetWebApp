using dotnetWebApp.Models;
using dotnetWebApp.Models.Security;
using dotnetWebApp.Models.SolidPrinciple;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dotnetWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _service;
        private readonly IDataProtector _dataProtector;
        private readonly RegistrationappContext _registrationapp;

        public HomeController(IStudentService service, DataSecurityProvider datakey, IDataProtectionProvider provider, RegistrationappContext registrationappContext)
        {
            _service = service;
            _dataProtector = provider.CreateProtector(datakey.dataKey); 
           _registrationapp = registrationappContext;
        }

        /*public List<Student> GetUserLists()
        {
            
            List<Student> students = new()
            {
                new Student { Id=1, Name="Sagar Kathariya", Address="Dhangadhi"},
                new Student { Id=2, Name="Kapil Poudel", Address="KTM"},
                new Student { Id=3, Name="Arjun Rana", Address="Belauri"},
                new Student { Id=4, Name="Nishan Chaudhary", Address="KTM"},
            };
            return students;
        } */
       

        public IActionResult Index()
        {
            //List<Student> Std = GetUserLists(); and var Std=GetUserLists are same 
           // var Std=GetUserLists();
            var std= _service.GetStudents();
           /* var s =std.Select(e=>new Student
            {
                Id=e.UserId,
                Name=e.UserName,
                Address =e.UserAddress,
                encId=_dataProtector.Protect(e.UserId.ToString())
            }).ToList();
           // return Json(std);*/
           var u = std.Select(e=>new UserList
           {
               UserId=e.UserId,
               UserName=e.UserName,
               UserEmail=  e.UserEmail,
               UserPassword=e.UserPassword,
               UserProfile=e.UserProfile,
               UserAddress = e.UserAddress,
               UserRole = e.UserRole,
               UserStatus=e.UserStatus,
               EncId = _dataProtector.Protect(e.UserId.ToString()),
           }).ToList();
            return View(u);
        }

        public IActionResult Details(string id)
        {
            int userId = Convert.ToInt32(_dataProtector.Unprotect(id));
            UserList std = _service.GetStdById(userId);
           // return Json(std);
            return View(std);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
