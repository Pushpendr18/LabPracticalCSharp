using System;
using System.Collections.Generic;

namespace SchoolMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            StudentManagementSystem.Run();
        }
    }

    class Student
    {
        public int Id;
        public string Name;
        public int Age;

        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}");
        }
    }

    class StudentManagementSystem
    {
        static List<Student> students = new List<Student>();

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Student Management system");
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayStudents();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age");
                return;
            }

            students.Add(new Student(id, name, age));
            Console.WriteLine("Student added successfully!");
        }

        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found!");
                return;
            }

            foreach (var s in students)
            {
                s.Display();
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                student.Display();
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void DeleteStudent()
        {
            Console.Write("Enter ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            var student = students.Find(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student deleted!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
    }
}
