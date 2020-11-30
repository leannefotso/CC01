using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BLL
{
    public class Student
    {
        Student studentRepo;
        private String dbFolder;

        public string Reference { get; private set; }

        public Student(string dbFolder)
        {
            studentRepo = new Student(dbFolder);
        }
        public void CreateStudent(Student student)
        {
            studentRepo.Add(student);
        }

        private void Add(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            studentRepo.Remove(student);
        }

        private void Remove(Student student)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return studentRepo.Find();
        }

        private IEnumerable<Student> Find()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByReference(string reference)
        {
            return studentRepo.Find(x => x.Reference == reference);
        }

        public IEnumerable<Student> GetBy(Func<Student, bool> predicate)
        {
            return studentRepo.Find(predicate);
        }

        private IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void EditStudent(Student oldStudent, Student newStudent)
        {
            studentRepo.Set(oldStudent, newStudent);
        }

        private void Set(Student oldStudent, Student newStudent)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent()
        {
            Student student = studentRepo.Get();
            /*if (student != null)
                if (!string.IsNullOrEmpty((student.Picture).ToString()))
                    student.Picture = Path.Combine(dbFolder, "Picture", (student.Picture).ToString());*/
            return student;
        }

        private Student Get()
        {
            throw new NotImplementedException();
        }
    }
}