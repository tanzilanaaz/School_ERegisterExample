using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_ERegisterExample
{
    interface IStudentRepo
    {
        void AddStudent(student student);
        List<student> GetAllStudents();
        student GetStudentById(int uniqueId);
        void UpdateStudent(student updatedStudent);
        void DeleteStudent(int uniqueId);

    }
}
