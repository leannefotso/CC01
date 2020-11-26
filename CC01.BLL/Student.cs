using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BLL
{
    public class StudentBLL
    {
        StudentBLL studentRepo;
        private String dbFolder;
        public StudentBLL (string dbFolder) 
        {
            studentRepo = new StudentBLL(dbFolder);
        }
        public void CreateStudent (StudentBLL student)
        {
            studentRepo.Add(student);
        }

        private void Add(StudentBLL student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(StudentBLL student)
        {
            studentRepo.Remove(student);
        }

        private void Remove(StudentBLL student)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return studentRepo.Find();
        }
        public IEnumerable<Student>
    }

    internal class Student
    {
    }
}
