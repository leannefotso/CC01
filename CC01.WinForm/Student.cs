using System;

namespace CC01.WinForm
{
    public class Student
    {
        private string v1;
        private string text1;
        private string text2;
        private string text3;
        private long v2;
        private byte[] vs;
        private object p;

        public Student(object p)
        {
            this.p = p;
        }

        public Student(string v1, string text1, string text2, string text3, string text, long v2, byte[] vs)
        {
            this.v1 = v1;
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.v2 = v2;
            this.vs = vs;
        }

        public byte[] Picture { get; internal set; }
        public string University { get; internal set; }
        public string Name { get; internal set; }
        public object Fullname { get; internal set; }
        public string FullName { get; internal set; }
        public string DateNaissance { get; internal set; }
        public object Matricule { get; internal set; }
        public string Email { get; internal set; }

        internal void CreateStudent(Student newStudent)
        {
            throw new NotImplementedException();
        }

        internal void EditStudent(Student oldStudent, Student newStudent)
        {
            throw new NotImplementedException();
        }
    }
}