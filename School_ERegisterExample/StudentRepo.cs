using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace School_ERegisterExample
{
    class StudentRepo : IStudentRepo
    {
        private string filePath;

        public StudentRepo()
        {
            filePath = ConfigurationManager.AppSettings["StudentDataFile"];
        }

        public void AddStudent(student student)
        {
            try
            {
                List<student> students = GetAllStudents();
                student.UniqueId = students.Count > 0 ? students.Max(s => s.UniqueId) + 1 : 1;
                students.Add(student);
                WriteToFile(students);
                Console.WriteLine("Student added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }
        }

        public List<student> GetAllStudents()
        {
            List<student> students = new List<student>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        students.Add(new student
                        {
                            UniqueId = Convert.ToInt32(parts[0]),
                            Name = parts[1],
                            Age = Convert.ToInt32(parts[2]),
                            Email = parts[3]
                        });
                    }
                }
            }
            catch (FileNotFoundException)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading student data: {ex.Message}");
            }

            return students;
        }

        public student GetStudentById(int uniqueId)
        {
            return GetAllStudents().FirstOrDefault(s => s.UniqueId == uniqueId);
        }

        public void UpdateStudent(student updatedStudent)
        {
            try
            {
                List<student> students = GetAllStudents();
                student existingStudent = students.FirstOrDefault(s => s.UniqueId == updatedStudent.UniqueId);
                if (existingStudent != null)
                {
                    existingStudent.Name = updatedStudent.Name;
                    existingStudent.Age = updatedStudent.Age;
                    existingStudent.Email = updatedStudent.Email;
                    WriteToFile(students);
                    Console.WriteLine("Student updated successfully!");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student: {ex.Message}");
            }
        }

        public void DeleteStudent(int uniqueId)
        {
            try
            {
                List<student> students = GetAllStudents();
                student studentToDelete = students.FirstOrDefault(s => s.UniqueId == uniqueId);
                if (studentToDelete != null)
                {
                    students.Remove(studentToDelete);
                    WriteToFile(students);
                    Console.WriteLine("Student deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
            }
        }

        private void WriteToFile(List<student> students)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var student in students)
                    {
                        sw.WriteLine($"{student.UniqueId},{student.Name},{student.Age},{student.Email}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}
