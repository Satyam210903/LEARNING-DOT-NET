using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TODO_API.Model;
using TODO_API.Service;

namespace TODO_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Helpers
        private int UserId =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        private bool IsAdmin =>
            User.IsInRole("admin");

        // GET ALL (Admin & User)
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            return student == null
                ? NotFound("Student not found")
                : Ok(student);
        }

        // ADD (Admin & User)
        [HttpPost("batch")]
        public IActionResult AddStudents([FromBody] List<Student> students)
        {
            if (students == null || students.Count == 0)
                return BadRequest("No students provided");

            _studentService.AddStudents(students, UserId);
            return Ok($"{students.Count} students added successfully");
        }

        // UPDATE (Admin OR Owner)
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var updated = _studentService.UpdateStudent(
                id, student, UserId, IsAdmin);

            return updated
                ? Ok("Student updated successfully")
                : Forbid("You are not allowed to update this student");
        }

        // DELETE (Admin OR Owner)
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var deleted = _studentService.DeleteStudent(
                id, UserId, IsAdmin);

            return deleted
                ? Ok("Student deleted successfully")
                : Forbid("You are not allowed to delete this student");
        }
    }
}
