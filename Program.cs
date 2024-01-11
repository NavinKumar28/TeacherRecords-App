using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Records_App
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Teacher Records System");

            while (true)
            {
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. View All Teachers");
                Console.WriteLine("3. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;
                    case 2:
                        ViewAllTeachers();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddTeacher()
        {
            Teacher teacher = new Teacher();

            Console.Write("Enter ID: ");
            teacher.ID = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            teacher.Name = Console.ReadLine();

            Console.Write("Enter Class and Section: ");
            teacher.ClassSection = Console.ReadLine();

            TeacherDataAccess.SaveTeacher(teacher);
            Console.WriteLine("Teacher added successfully!");
        }

        static void ViewAllTeachers()
        {
            var teachers = TeacherDataAccess.GetAllTeachers();

            Console.WriteLine("Teacher Records:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class and Section: {teacher.ClassSection}");
            }
        }
    }

}
