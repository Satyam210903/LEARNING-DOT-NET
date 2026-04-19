using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TODO_Client_API.Models;
using TODO_Client_API;
class Program
{
    static async Task Main()
    {
        var studentService =
            new StudentApiService("https://localhost:7050/");

        // Login once
        await studentService.LoginAsync("admin", "1234");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("<===== STUDENT MANAGEMENT =====>");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. View Student By ID");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddStudent(studentService);
                    break;

                case "2":
                    await ViewAllStudents(studentService);
                    break;

                case "3":
                    await ViewStudentById(studentService);
                    break;

                case "4":
                    await UpdateStudent(studentService);
                    break;

                case "5":
                    await DeleteStudent(studentService);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }

    // ADD STUDENT  Operation Starts from here
    static async Task AddStudent(StudentApiService service)
    {
        Console.Write("Name  : ");
        var name = Console.ReadLine();

        Console.Write("Age   : ");
        int age = int.Parse(Console.ReadLine()!);

        Console.Write("Class : ");
        var cls = Console.ReadLine();

        await service.AddStudentsAsync(new List<Student>
        {
            new Student
            {
                Name = name!,
                Age = age,
                Class = cls!
            }
        });

        Console.WriteLine("Student added successfully.");
    }

    // VIEW ALL Students Operation Starts from here
    static async Task ViewAllStudents(StudentApiService service)
    {
        var students = await service.GetStudentsAsync();

        Console.WriteLine("\nID | Name | Age | Class");
        Console.WriteLine("------------------------");

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Id} | {s.Name} | {s.Age} | {s.Class}");
        }
    }

    //  VIEW STUDENTS BY ID  Operation Starts from here
    static async Task ViewStudentById(StudentApiService service)
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine()!);

        var student = await service.GetStudentByIdAsync(id);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine($"ID    : {student.Id}");
        Console.WriteLine($"Name  : {student.Name}");
        Console.WriteLine($"Age   : {student.Age}");
        Console.WriteLine($"Class : {student.Class}");
    }

    // UPDATE Operation Starts from here
    static async Task UpdateStudent(StudentApiService service)
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("New Name  : ");
        var name = Console.ReadLine();

        Console.Write("New Age   : ");
        int age = int.Parse(Console.ReadLine()!);

        Console.Write("New Class : ");
        var cls = Console.ReadLine();

        bool updated = await service.UpdateStudentAsync(id, new Student
        {
            Name = name!,
            Age = age,
            Class = cls!
        });

        Console.WriteLine(updated
            ? "Student updated successfully."
            : "Student not found.");
    }

    //  DELETE Operation Starts From Here
    static async Task DeleteStudent(StudentApiService service)
    {
        Console.Write("Enter Student ID Whom You Want To Delete Student: ");
        int id = int.Parse(Console.ReadLine()!);

        bool deleted = await service.DeleteStudentAsync(id);

        Console.WriteLine(deleted
            ? "Student deleted successfully."
            : "Student not found.");
    }
}
