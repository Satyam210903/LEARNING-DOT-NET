using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Client_API.Models
{
    public class Student
    {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public int Age { get; set; }
            public string Class { get; set; } = "";
        public int User_id { get; set; }
    }
}
