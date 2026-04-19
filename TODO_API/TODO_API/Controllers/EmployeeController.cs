using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TODO_API.Model;
using TODO_API.Services;

namespace TODO_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Helpers
        private int UserId =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        private bool IsAdmin =>
            User.IsInRole("Admin");

        // GET ALL (Admin & User)
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeService.GetAllEmployee());
        }

        // GET BY EMAIL
        [HttpGet("{email}")]
        public IActionResult GetEmployeeByEmail(string email)
        {
            var employee = _employeeService.GetEmployeeByEmail(email);
            return employee == null
                ? NotFound("Employee not found")
                : Ok(employee);
        }


        // ADD (Admin & User)
        [HttpPost("batch")]
        public IActionResult AddEmployee([FromBody] List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                return BadRequest("No employees provided");

            _employeeService.AddEmployee(employees, UserId , IsAdmin);
            return Ok($"{employees.Count} employees added successfully");
        }



        // UPDATE (Admin OR Owner)
        [HttpPut("/Update-Salary/{email}")]
        public IActionResult UpdateEmployeeSalary(string email, [FromBody] Employee employee)
        {
            var updated = _employeeService.UpdateEmployeeSalary(
                email, employee.EmpSalary, UserId, IsAdmin);

            return updated
                ? Ok("Employee updated successfully")
                : Forbid("You are not allowed to update this employee");
        }


        // UPDATE (Admin OR Owner)
        [HttpPut("/Update-Designation/{email}")]
        public IActionResult UpdateEmployeeDesignation(string email, [FromBody] Employee employee)
        {
            var updated = _employeeService.UpdateEmployeeDesignation(
                email, employee.EmpDesignation, UserId, IsAdmin);

            return updated
                ? Ok("Employee updated successfully")
                : Forbid("You are not allowed to update this employee");
        }


        // UPDATE (Admin OR Owner)
        [HttpPut("{email}")]
        public IActionResult UpdateEmployee(string email, [FromBody] Employee employee)
        {
            var updated = _employeeService.UpdateEmployee(
                email, employee, UserId, IsAdmin);

            return updated
                ? Ok("Employee updated successfully")
                : Forbid("You are not allowed to update this employee");
        }


        // UPDATE FILTER (Admin OR Owner)
        [HttpPut("batch")]
        public IActionResult UpdateFilteredEmployee([FromBody] List<Employee> employees)
        {
            var updated = _employeeService.UpdateFilteredEmployee(employees, UserId, IsAdmin);

            return updated
                ? Ok("Employee updated successfully")
                : Forbid("You are not allowed to update this employee");
        }


        // DELETE (Admin OR Owner)
        [HttpDelete("{email}")]
        public IActionResult DeleteEmployee(string email)
        {
            var deleted = _employeeService.DeleteEmployee(
                email, UserId, IsAdmin);

            return deleted
                ? Ok("Employee deleted successfully")
                : Forbid("You are not allowed to delete this employee");
        }

        // DELETE (Admin OR Owner)
        [HttpDelete]
        public IActionResult DeleteAllEmployee()
        {
            var deleted = _employeeService.DeleteAllEmployee(UserId,IsAdmin);

            return deleted
                ? Ok("Employee deleted successfully")
                : NotFound(new { message = "Employee data not found" });
            ;
        }

        // DELETE filtered (Admin OR Owner)
        [HttpDelete("batch")]
        public IActionResult DeleteFiltteredEmployee([FromBody] List<Employee> employees)
        {
            var deleted = _employeeService.DeleteFilteredEmployee(employees, UserId, IsAdmin);

            return deleted
                ? Ok("Employee deleted successfully")
                : NotFound(new { message = "Employee data not found" });
            ;
        }
    }
}
