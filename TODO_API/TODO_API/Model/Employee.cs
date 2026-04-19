using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TODO_API.Model
{
    public class Employee
    {

        public int EmpId { get; set; }
        public int EmpUserId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPhone { get; set; }

        public string EmpDesignation { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EmpSalary { get; set; }
        public int User_id { get; set; }

    }
}
