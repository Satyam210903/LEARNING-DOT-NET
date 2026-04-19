namespace TODO_API.Service
{
    using TODO_API.Model;
    using System.Collections.Generic;
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudents(List<Student> students, int userId);
        bool UpdateStudent(int id, Student student, int userId, bool isAdmin);
        bool DeleteStudent(int id, int userId, bool isAdmin);
    }
}
