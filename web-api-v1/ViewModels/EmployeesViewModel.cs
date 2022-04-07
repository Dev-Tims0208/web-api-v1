using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api_v1.Models;

namespace web_api_v1.ViewModels
{
    public class EmployeesViewModel
    {
        public IEnumerable<Employees> EmployeesList { get; set; }
        public Employees Employees { get; set; }
    }
}