using Codebase_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codebase_application.Controllers
{
    public class AccountController : Controller
    {
        CodebaseEntities db = new CodebaseEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var getUsers = db.sp_GetAllUserDetails().ToList();
            return View(getUsers);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModels loginModels)
        {
            try {
                if (loginModels != null)
                {
                    var checkUser = db.User_Details.Where(x => x.Email == loginModels.Username && x.Password == loginModels.Password 
                    && x.Status == true).FirstOrDefault();
                    if (checkUser != null)
                    {
                        ModelState.Clear();
                        return RedirectToAction("Index","Account");
                    }
                    else {
                        ViewBag.InvalidMessage = "Username or Password is Invalid.";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UsersModel userDetails)
        {
            try
            {
                var checkUser = db.sp_GetUserDetails(userDetails.Email).FirstOrDefault();

                if (userDetails != null && checkUser == null)
                {
                    var finalResult = db.sp_UserDetail(userDetails.FirstName, userDetails.LastName, userDetails.Password, userDetails.Email, userDetails.MobileNo);
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "You have successfully created the user and can now log in.";
                    return View("Login");
                }
                else {
                    ViewBag.DuplicateMessage = "This user email id already exist.";
                    return View("CreateUser");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Delete(int id) {
            var checkUser = db.User_Details.FirstOrDefault(x=> x.ID == id);
            if (checkUser != null)
            {
                db.User_Details.Remove(checkUser);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Account");
        }
    }
}