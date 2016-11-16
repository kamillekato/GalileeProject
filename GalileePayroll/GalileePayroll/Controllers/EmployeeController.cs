using GalileeBusinessLogic.Managers;
using GalileeDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalileePayroll.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeManager empManager = new EmployeeManager();

         

        // GET: Employee
        public ActionResult Index()
        {
            List<EMPLOYEE> employeeList = empManager.GetEmployeeList();
            return View(employeeList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.ListOfGender = new SelectList(new List<SelectListItem> {
                            new SelectListItem { Value="U",Text= "Unspecified",Selected =true },
                            new SelectListItem { Value = "M",Text="Male"},
                               new SelectListItem {Value = "F", Text ="Female" }
                           }, "Value", "Text");

            ViewBag.AlertType = 0;
            ViewBag.AlertMessage = "";
            return View();
        }

        [HttpPost]
        public ActionResult Add(EMPLOYEE employee)
        {
            ViewBag.ListOfGender = new SelectList(new List<SelectListItem> {
                            new SelectListItem { Value="U",Text= "Unspecified",Selected =true },
                            new SelectListItem { Value = "M",Text="Male"},
                               new SelectListItem {Value = "F", Text ="Female" }
                           }, "Value", "Text");
            bool isSuccess = empManager.AddEmployee(employee);
            
            if (isSuccess)
            {
                ViewBag.SuccessMessage = "Employee Successfully Added";
                return View();
            }
            else
            { 
                ViewBag.ErrorMessage = "Something went wrong in adding employee. Please double-check and try again.";
                return View();
            }

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.ListOfGender = new SelectList(new List<SelectListItem> {
                            new SelectListItem { Value="U",Text= "Unspecified",Selected =true },
                            new SelectListItem { Value = "M",Text="Male"},
                               new SelectListItem {Value = "F", Text ="Female" }
                           }, "Value", "Text");

            return View(empManager.GetEmployeeByID(id));
        }
        
        [HttpPost]
        public ActionResult Update(EMPLOYEE employee)
        {
            ViewBag.ListOfGender = new SelectList(new List<SelectListItem> {
                            new SelectListItem { Value="U",Text= "Unspecified",Selected =true },
                            new SelectListItem { Value = "M",Text="Male"},
                               new SelectListItem {Value = "F", Text ="Female" }
                           }, "Value", "Text");


            bool isSuccess = empManager.UpdateEmployee(employee);
            if (isSuccess)
            {
                return RedirectToAction("Index","Employee");
            }
            else
            {
                //add model state error
                return View();
            }
        }
        
        
         
        public JsonResult UpdateDesignation(int id,string designation)
        {
            return Json(empManager.UpdateEmployeeDesignation(id, designation), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            bool isSuccess = empManager.DeleteEmployee(id);
           
            return Json(isSuccess, JsonRequestBehavior.AllowGet);
        }
    }
}