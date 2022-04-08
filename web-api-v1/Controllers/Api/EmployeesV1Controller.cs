using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api_v1.Models;

namespace web_api_v1.Controllers.Api
{
    public class EmployeesV1Controller : ApiController
    {
        private ApplicationDbContext ctx;

        public EmployeesV1Controller()
        {
            ctx = new ApplicationDbContext();
        }

        // GET /api/customers
        [Route("api/v1/employeesv1")]
        public IEnumerable<Employees> GetEmployees()
        {
            return ctx.Employees.ToList();
        }

        // GET Employees by ID
        public Employees GetEmployees(int id)
        {
            var emp = ctx.Employees.SingleOrDefault(c => c.Id == id);
            if (emp == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return emp;
        }

        // POST
        [HttpPost]
        public Employees CreateEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            ctx.Employees.Add(employees);
            ctx.SaveChanges();

            return employees;
        }

        // PUT
        [HttpPut]
        public void UpdateEmployees(int id, Employees employees)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var empInDb = ctx.Employees.SingleOrDefault(e => e.Id == id);
            empInDb.Name = employees.Name;
            empInDb.Address = employees.Address;

            ctx.SaveChanges();
        }

        [HttpDelete]
        public void DeleteEmployees(int id)
        {
            var empInDb = ctx.Employees.SingleOrDefault(e => e.Id == id);

            if (empInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ctx.Employees.Remove(empInDb);
            ctx.SaveChanges();
        }



    }
}
