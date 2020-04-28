﻿using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class StatusController : Controller
    {
        ISystemTime systemTime;
        public StatusController(ISystemTime systemTime)
        {
            this.systemTime = systemTime;
        }


        // GET / status -> 200 OK
        [HttpGet("/status")]
        public ActionResult GetTheStatus()
        {
            var response = new GetStatusResponse
            {
                Message = "Everything is golden!",
                CheckedBy = "Joe Schmidt",
                WhenLastChecked = DateTime.Now
            };
            return Ok(response);
        }

        // GET /employees/93/salary
        [HttpGet("employees/{employeeId:int:min(1)}/salary")]
        public ActionResult GetEmployeeSalary(int employeeId)
        {
            return Ok($"The Employee {employeeId} has a salary of $87,000.00");
        }

        [HttpGet("employees")]
        public ActionResult GetEmployees([FromQuery]string dept = "All")
        {
            return Ok($"Returning employees for department {dept}");
        }
        // "Kinds of resources {Resource Archetypes}
        // 1. Document - single thing - GET /employee/52
        // 2. Collection - a plural thing
        // 3. Store
        // 4. Controller



        [HttpGet("whoami")]
        public ActionResult WhoAmI([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok($"I see you are running {userAgent}");
        }

        [HttpPost("employees")]
        public ActionResult HireEmployee([FromBody] EmployeeCreateRequest employeeToHire)
        {
            return Ok($"Hiring {employeeToHire.LastName} as a {employeeToHire.Department}");
        }
}

public class GetStatusResponse
    {
        public string Message { get; set; }
        public string CheckedBy { get; set; }
        public DateTime WhenLastChecked { get; set; }
    }

    public class EmployeeCreateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}
