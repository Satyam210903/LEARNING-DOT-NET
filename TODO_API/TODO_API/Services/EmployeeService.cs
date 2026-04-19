using Microsoft.Data.SqlClient;
using TODO_API.Model;

namespace TODO_API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;

        public EmployeeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string ConnectionString =>
            _configuration.GetConnectionString("DefaultConnection");

        // ================= GET ALL EMPLOYEES =================
        public List<Employee> GetAllEmployee()
        {
            var employees = new List<Employee>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEES", con);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(MapEmployee(reader));
            }

            return employees;
        }

        // ================= GET EMPLOYEE BY EMAIL =================
        public Employee GetEmployeeByEmail(string email)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM EMPLOYEES WHERE EMP_EMAIL = @EMP_EMAIL", con);

            cmd.Parameters.AddWithValue("@EMP_EMAIL", email);
            con.Open();

            using SqlDataReader reader = cmd.ExecuteReader();
            return reader.Read() ? MapEmployee(reader) : null;
        }

        // ================= ADD EMPLOYEES =================

        public void AddEmployee(List<Employee> employees, int userId , bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            foreach (var employee in employees)
            {
                using SqlCommand cmd = new SqlCommand(
                    @"IF NOT EXISTS (
                SELECT 1 FROM EMPLOYEES 
                WHERE EMP_EMAIL = @EMP_EMAIL
              )
              BEGIN
                INSERT INTO EMPLOYEES
                (EMP_USER_ID, EMP_NAME, EMP_EMAIL, EMP_PHONE, EMP_DESIGNATION, EMP_SALARY)
                VALUES
                (@EMP_USER_ID, @EMP_NAME, @EMP_EMAIL, @EMP_PHONE, @EMP_DESIGNATION, @EMP_SALARY)
              END", con);
                cmd.Parameters.AddWithValue("@EMP_USER_ID", employee.User_id);
                cmd.Parameters.AddWithValue("@EMP_NAME", employee.EmpName);
                cmd.Parameters.AddWithValue("@EMP_EMAIL", employee.EmpEmail);
                cmd.Parameters.AddWithValue("@EMP_PHONE", employee.EmpPhone);
                cmd.Parameters.AddWithValue("@EMP_DESIGNATION", employee.EmpDesignation);
                cmd.Parameters.AddWithValue("@EMP_SALARY", employee.EmpSalary);

                cmd.ExecuteNonQuery();
            }
        }








        //public void AddEmployee(List<Employee> employees, int userId)
        //{
        //    using SqlConnection con = new SqlConnection(ConnectionString);
        //    con.Open();

        //    foreach (var employee in employees)
        //    {
        //        using SqlCommand cmd = new SqlCommand(
        //            @"INSERT INTO EMPLOYEES 
        //              (EMP_USER_ID, EMP_NAME, EMP_EMAIL, EMP_PHONE, EMP_DESIGNATION, EMP_SALARY)
        //              VALUES 
        //              (@EMP_USER_ID, @EMP_NAME, @EMP_EMAIL, @EMP_PHONE, @EMP_DESIGNATION, @EMP_SALARY)", con);

        //        cmd.Parameters.AddWithValue("@EMP_USER_ID", userId);
        //        cmd.Parameters.AddWithValue("@EMP_NAME", employee.EmpName);
        //        cmd.Parameters.AddWithValue("@EMP_EMAIL", employee.EmpEmail);
        //        cmd.Parameters.AddWithValue("@EMP_PHONE", employee.EmpPhone);
        //        cmd.Parameters.AddWithValue("@EMP_DESIGNATION", employee.EmpDesignation);
        //        cmd.Parameters.AddWithValue("@EMP_SALARY", employee.EmpSalary);

        //        cmd.ExecuteNonQuery();
        //    }
        //}

        // ================= UPDATE EMPLOYEE (DESIGNATION + SALARY) =================
        public bool UpdateEmployee(string email, Employee employee, int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);

            string sql = isAdmin
                ? @"UPDATE EMPLOYEES
                    SET EMP_DESIGNATION=@EMP_DESIGNATION, EMP_SALARY=@EMP_SALARY
                    WHERE EMP_EMAIL=@EMP_EMAIL"
                : @"UPDATE EMPLOYEES 
                    SET EMP_DESIGNATION=@EMP_DESIGNATION, EMP_SALARY=@EMP_SALARY
                    WHERE EMP_EMAIL=@EMP_EMAIL AND EMP_USER_ID=@EMP_USER_ID";

            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_DESIGNATION", employee.EmpDesignation);
            cmd.Parameters.AddWithValue("@EMP_SALARY", employee.EmpSalary);
            cmd.Parameters.AddWithValue("@EMP_EMAIL", email);

            if (!isAdmin)
                cmd.Parameters.AddWithValue("@EMP_USER_ID", userId);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }


        // ================= UPDATE FILTERED EMPLOYEE (DESIGNATION + SALARY) =================

        public bool UpdateFilteredEmployee(List<Employee> employees, int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            int rowAffected = 0;
            foreach (var employee in employees)
            {
                string sql = isAdmin
                    ? @"UPDATE EMPLOYEES
                    SET EMP_DESIGNATION=@EMP_DESIGNATION, EMP_SALARY=@EMP_SALARY
                    WHERE EMP_EMAIL=@EMP_EMAIL"
                    : @"UPDATE EMPLOYEES 
                    SET EMP_DESIGNATION=@EMP_DESIGNATION, EMP_SALARY=@EMP_SALARY
                    WHERE EMP_EMAIL=@EMP_EMAIL AND EMP_USER_ID=@EMP_USER_ID";

                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@EMP_DESIGNATION", employee.EmpDesignation);
                cmd.Parameters.AddWithValue("@EMP_SALARY", employee.EmpSalary);
                cmd.Parameters.AddWithValue("@EMP_EMAIL", employee.EmpEmail);

                if (!isAdmin)
                    cmd.Parameters.AddWithValue("@EMP_USER_ID", userId);

                con.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            return rowAffected > 0;
        }



        // ================= UPDATE DESIGNATION =================
        public bool UpdateEmployeeDesignation(string email, string designation, int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);

            string sql = isAdmin
                ? @"UPDATE EMPLOYEES 
                    SET EMP_DESIGNATION=@EMP_DESIGNATION
                    WHERE EMP_EMAIL=@EMP_EMAIL"
                : @"UPDATE EMPLOYEES 
                    SET EMP_DESIGNATION=@EMP_DESIGNATION
                    WHERE EMP_EMAIL=@EMP_EMAIL AND EMP_USER_ID=@EMP_USER_ID";

            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_DESIGNATION", designation);
            cmd.Parameters.AddWithValue("@EMP_EMAIL", email);

            if (!isAdmin)
                cmd.Parameters.AddWithValue("@EMP_USER_ID", userId);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // ================= UPDATE SALARY =================
        public bool UpdateEmployeeSalary(string email, decimal salary, int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);

            string sql = isAdmin
                ? @"UPDATE EMPLOYEES 
                    SET EMP_SALARY=@EMP_SALARY
                    WHERE EMP_EMAIL=@EMP_EMAIL"
                : @"UPDATE EMPLOYEES 
                    SET EMP_SALARY=@EMP_SALARY
                    WHERE EMP_EMAIL=@EMP_EMAIL AND EMP_USER_ID=@EMP_USER_ID";

            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_SALARY", salary);
            cmd.Parameters.AddWithValue("@EMP_EMAIL", email);

            if (!isAdmin)
                cmd.Parameters.AddWithValue("@EMP_USER_ID", userId);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // ================= DELETE EMPLOYEE =================
        public bool DeleteEmployee(string email, int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);

            string sql = isAdmin
                ? "DELETE FROM EMPLOYEES WHERE EMP_EMAIL=@EMP_EMAIL"
                : "DELETE FROM EMPLOYEES WHERE EMP_EMAIL=@EMP_EMAIL AND EMP_USER_ID=@EMP_USER_ID";

            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_EMAIL", email);

            if (!isAdmin)
                cmd.Parameters.AddWithValue("@EMP_USER_ID", userId);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }



        // ================= DELETE all EMPLOYEE =================
        public bool DeleteAllEmployee(int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);

            string sql = isAdmin
                ? "DELETE FROM EMPLOYEES"
                : "DELETE FROM EMPLOYEES WHERE EMP_USER_ID=@EMP_USER_ID";

            using SqlCommand cmd = new SqlCommand(sql, con);

            if (!isAdmin)
                cmd.Parameters.AddWithValue("@EMP_USER_ID", userId);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }


        // ================= DELETE FILTERED EMPLOYEE =================
        public bool DeleteFilteredEmployee(List<Employee> employees, int userId, bool isAdmin)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            int affectedRows = 0;

            foreach (var employee in employees)
            {
                string query;

                if (isAdmin)
                {
                    query = @"DELETE FROM EMPLOYEES 
                      WHERE EMP_EMAIL <> @EMP_EMAIL";
                }
                else
                {
                    query = @"DELETE FROM EMPLOYEES 
                      WHERE EMP_EMAIL <> @EMP_EMAIL
                      AND EMP_USER_ID = @EMP_USER_ID";
                }

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EMP_EMAIL", employee.EmpEmail);

                if (!isAdmin)
                    cmd.Parameters.AddWithValue("@EMP_USER_ID", userId);

                affectedRows += cmd.ExecuteNonQuery();
            }

            return affectedRows > 0;
        }





        // ================= MAP READER TO MODEL =================
        private Employee MapEmployee(SqlDataReader reader)
        {
            return new Employee
            {
                EmpId = (int)reader["EMP_ID"],
                User_id = (int)reader["EMP_USER_ID"],
                EmpName = reader["EMP_NAME"].ToString()!,
                EmpEmail = reader["EMP_EMAIL"].ToString()!,
                EmpPhone = reader["EMP_PHONE"].ToString()!,
                EmpDesignation = reader["EMP_DESIGNATION"].ToString()!,
                EmpSalary = (decimal)reader["EMP_SALARY"]
            };
        }
    }
}
