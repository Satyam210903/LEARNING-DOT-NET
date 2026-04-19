using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TODO_API.Model;
using System.Collections.Generic;

namespace TODO_API.Service
{
    public class StudentService : IStudentService
    {
        private readonly IConfiguration _configuration;

        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string ConnectionString =>
            _configuration.GetConnectionString("DefaultConnection");


        // Get all students (admin & user)
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                students.Add(MapStudent(reader));
            }

            return students;
        }

        // Get by ID
        public Student GetStudentById(int id)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Student WHERE Id=@Id", con);

            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();

            using SqlDataReader reader = cmd.ExecuteReader();
            return reader.Read() ? MapStudent(reader) : null;
        }

        // Add students (assign User_id = userId)
        public void AddStudents(List<Student> students, int userId)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            foreach (var student in students)
            {
                using SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Student (Name, Age, Class, User_id)
                      VALUES (@Name, @Age, @Class, @User_id)", con);

                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@User_id", userId);

                cmd.ExecuteNonQuery();
            }
        }

        // Update student (admin can update any, user only own)
        public bool UpdateStudent(int id, Student student, int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);

            string sql = isAdmin
                ? @"UPDATE Student 
                    SET Name=@Name, Age=@Age, Class=@Class
                    WHERE Id=@Id"
                : @"UPDATE Student 
                    SET Name=@Name, Age=@Age, Class=@Class
                    WHERE Id=@Id AND User_id=@UserId";

            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@Class", student.Class);

            if (!isAdmin)
                cmd.Parameters.AddWithValue("@UserId", userId);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // Delete student (admin can delete any, user only own)
        public bool DeleteStudent(int id, int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);

            string sql = isAdmin
                ? "DELETE FROM Student WHERE Id=@Id"
                : "DELETE FROM Student WHERE Id=@Id AND User_id=@UserId";

            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Id", id);

            if (!isAdmin)
                cmd.Parameters.AddWithValue("@UserId", userId);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        //Map SqlDataReader → Student
        private Student MapStudent(SqlDataReader reader)
        {
            return new Student
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()!,
                Age = (int)reader["Age"],
                Class = reader["Class"].ToString()!,
                User_id = (int)reader["User_id"]
            };
        }
    }
}
