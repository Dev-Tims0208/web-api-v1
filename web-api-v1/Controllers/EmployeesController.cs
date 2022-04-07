using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_api_v1.Models;
using web_api_v1.ViewModels;

namespace web_api_v1.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext ctx;

        public EmployeesController()
        {
            ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = ctx.Employees.ToList();
            return View(employees);
        }

        public ActionResult New()
        {
            var employeesList = ctx.Employees.ToList();
            var viewModel = new EmployeesViewModel
            {
                EmployeesList = employeesList
            };
            return View("EmployeesForm", viewModel);
        }

        public ActionResult Save(Employees employees)
        {
            if (employees.Id == 0)
            {
                ctx.Employees.Add(employees);
            }

            ctx.SaveChanges();
            return RedirectToAction("Index", "Employees");

        }
    }
}