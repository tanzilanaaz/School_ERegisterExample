using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_ERegisterExample
{
    class Program
    {
        static IStudentRepo studentRepo = new StudentRepo();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Student \n2. View Students \n3. Update Student \n4. Delete Student \n5. Get Student by UniqueId \n6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        ViewStudents();
                        break;

                    case "3":
                        UpdateStudent();
                        break;

                    case "4":
                        DeleteStudent();
                        break;

                    case "5":
                        GetStudentById();
                        break;

                    case "6":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void AddStudent()
        {
            try
            {
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                Console.Write("Enter student age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter student email: ");
                string email = Console.ReadLine();

                student newStudent = new student
                {
                    Name = name,
                    Age = age,
                    Email = email
                };

                studentRepo.AddStudent(newStudent);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for age.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }
        }

        static void ViewStudents()
        {
            List<student> students = studentRepo.GetAllStudents();

            if (students.Any())
            {
                Console.WriteLine("Student Details:");
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("No students found.");
            }
        }

        static void UpdateStudent()
        {
            try
            {
                Console.Write("Enter the UniqueId of the student you want to update: ");
                int uniqueId = Convert.ToInt32(Console.ReadLine());

                student existingStudent = studentRepo.GetStudentById(uniqueId);

                if (existingStudent != null)
                {
                    Console.Write("Enter the new name for the student: ");
                    string newName = Console.ReadLine();

                    Console.Write("Enter the new age for the student: ");
                    int newAge = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the new email for the student: ");
                    string newEmail = Console.ReadLine();

                    student updatedStudent = new student
                    {
                        UniqueId = uniqueId,
                        Name = newName,
                        Age = newAge,
                        Email = newEmail
                    };

                    studentRepo.UpdateStudent(updatedStudent);
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for age.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student: {ex.Message}");
            }
        }

        static void DeleteStudent()
        {
            try
            {
                Console.Write("Enter the UniqueId of the student you want to delete: ");
                int uniqueId = Convert.ToInt32(Console.ReadLine());

                studentRepo.DeleteStudent(uniqueId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for UniqueId.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
            }
        }

        static void GetStudentById()
        {
            try
            {
                Console.Write("Enter the UniqueId of the student you want to retrieve: ");
                int uniqueId = Convert.ToInt32(Console.ReadLine());

                student student = studentRepo.GetStudentById(uniqueId);

                if (student != null)
                {
                    Console.WriteLine("Student Details:");
                    Console.WriteLine(student);
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for UniqueId.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving student: {ex.Message}");
            }
        }

    }
    
}
