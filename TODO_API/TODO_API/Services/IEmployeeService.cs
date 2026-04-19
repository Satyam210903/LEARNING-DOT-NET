namespace TODO_API.Services
{
    using TODO_API.Model;
    using System.Collections.Generic;
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployee();
        Employee GetEmployeeByEmail(string email);
        void AddEmployee(List<Employee> employees, int userId , bool isAdmin);
        bool UpdateEmployeeSalary(string email, decimal salary, int userId, bool isAdmin);
        bool UpdateEmployeeDesignation(string email, string designation , int userId, bool isAdmin);
        bool UpdateEmployee(string email, Employee employee, int userId, bool isAdmin);
        bool UpdateFilteredEmployee(List<Employee> employees, int userId, bool isAdmin);
        bool DeleteEmployee(string email, int userId, bool isAdmin);
        bool DeleteAllEmployee(int userId, bool isAdmin);
        bool DeleteFilteredEmployee(List<Employee> employees ,int userId, bool isAdmin);
    }
}
