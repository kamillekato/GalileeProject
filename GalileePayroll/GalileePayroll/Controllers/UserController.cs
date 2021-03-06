﻿using GalileeBusinessLogic.Interfaces;
using GalileeBusinessLogic.Managers;
using GalileeDatabase;
using GalileePayroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalileePayroll.Controllers
{
    public class UserController : Controller
    {

        IUserManager UserManager = new UserManager();
         
        
        [HttpGet]
        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        { 
            bool loginAttempt = UserManager.LoginUser(loginModel.UserName, loginModel.Password);
            if (loginAttempt)
            {
                return View(); //change view to another action result
            }
            else
            {
                //add error to view 'Invalid Username or password'
                return View();
            }
             
        }

        [HttpGet]
        public ActionResult Add ()
        {
            USER user = new USER();
            
            return View(user);
        }

        [HttpPost]
        public ActionResult Add(USER user)
        {
            if (UserManager.IsUserNameExist(user.UserName))
            {
                //add error for username exist
                return View();
            }
            else
            {
                UserManager.AddUser(user);
                return View();//change View() to another action result
            }
        }

        [HttpGet]
        public ActionResult Update(string userName)
        {
            ViewBag.ListOfGender = new SelectList(new List<SelectListItem> {
                            new SelectListItem { Value="U",Text= "Unspecified",Selected =true },
                            new SelectListItem { Value = "M",Text="Male"},
                               new SelectListItem {Value = "F", Text ="Female" }
                           }, "Value", "Text");
            var getUser = UserManager.GetUserByUsername(userName);
            if (getUser== null)
            {
                return null;
            }
            else
            {
                return View(getUser);
            }
        }

        [HttpPost]
        public ActionResult Update(USER user)
        {
            ViewBag.ListOfGender = new SelectList(new List<SelectListItem> {
                            new SelectListItem { Value="U",Text= "Unspecified",Selected =true },
                            new SelectListItem { Value = "M",Text="Male"},
                               new SelectListItem {Value = "F", Text ="Female" }
                           }, "Value", "Text");

            bool isSuccess = UserManager.UpdateUser(user);
            if (isSuccess)
            {

                return View();
            }
            else
            {
                //add model state error
                return View();
            }
        }


        public ActionResult ViewUser(string username)
        {
            var user = UserManager.GetUserByUsername(username);

            return View(user);
        }

        








        


        public JsonResult IsUserNameExist(string userName)
        {
            bool returnValue = UserManager.IsUserNameExist(userName);
            return Json(returnValue, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string username)
        {
            bool returnValue = UserManager.DeleteUser(username);
            var getUser = UserManager.GetUserByUsername(username);
            return Json(new { deleteStatus = returnValue }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNameOfUser(string username)
        {
            var returnValue = UserManager.GetUserByUsername(username);

            return Json(new { Name = returnValue.FirstName + ' ' + returnValue.LastName }, JsonRequestBehavior.AllowGet);
        }

    }
}