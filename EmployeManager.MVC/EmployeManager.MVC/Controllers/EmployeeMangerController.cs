using EmployeManager.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeManager.MVC.Controllers
{
  
        public class EmployeeManagerController : Controller
        {
            private AppDbContext db = null;
            public EmployeeManagerController(AppDbContext _db)
            {
                this.db = _db;
            }

        /*public IActionResult Index()
        {
            return View();
        }*/


        private void FillCountries()
        { /*fill dropdown menu*/
            List<SelectListItem> countries =
                /*link query*/
            (from c in db.Countries
             orderby c.Name ascending
             select new SelectListItem()
             {/*converted select list object*/
                 Text = c.Name,
                 Value = c.Name
             }).ToList();
            ViewBag.Countries = countries;
        }

        [AllowAnonymous]


        public IActionResult List()
        {/*link query*/
            List<Employee> model = (from e in db.Employees
                                    orderby e.EmployeeID
                                    select e).ToList();
            return View(model);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Insert()
        {
            FillCountries();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Insert(Employee model)
        {
            FillCountries();
            if (ModelState.IsValid)
            {
                db.Employees.Add(model);
                db.SaveChanges();
                ViewBag.Message = "Employee inserted successfully";
            }
            return View(model);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Update(int id)
        {
            FillCountries();
            Employee model = db.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Update(Employee model)
        {
            FillCountries();
            if (ModelState.IsValid)
            {
                db.Employees.Update(model);
                db.SaveChanges();
                ViewBag.Message = "Employee updated successfully";
            }
            return View(model);
        }
        [ActionName("Delete")]
        [Authorize(Roles = "Manager")]
        public IActionResult ConfirmDelete(int id)
        {
            Employee model = db.Employees.Find(id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(int employeeID)
        {
            Employee model = db.Employees.Find(employeeID);
            db.Employees.Remove(model);
            db.SaveChanges();
            TempData["Message"] = "Employee deleted successfully";
            return RedirectToAction("List");
        }


    }
        
}
