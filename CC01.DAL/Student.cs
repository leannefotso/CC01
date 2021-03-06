﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.DAL
{
    public class Student
    {
        private static List<Student> students;
        private const string FILE_NAME = @"student.json";
        private readonly string dbFolder;
        private FileInfo file;
        private Student student;

        public object JsonConvert { get; private set; }

        public Student(string dbFolder)
        {
            this.dbFolder = dbFolder;
            file = new FileInfo(Path.Combine(this.dbFolder, FILE_NAME));
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            if (!file.Exists)
            {
                file.Create().Close();
                file.Refresh();
            }
            if (file.Length > 0)
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    string json = sr.ReadToEnd();
                    students = JsonConvert.DeserializeObject<List<Student>>(json);
                }
            }
            if (students == null)
            {
                students = new List<Student>();
            }
        }

        public void Set(Student oldStudent, Student newStudent)
        {
            var oldIndex = students.IndexOf(oldStudent);
            var newIndex = students.IndexOf(newStudent);
            students[oldIndex] = newStudent;
            Save();
        }

        public Student Get()
        {
            return student;
        }

        public void Add(Student student)
        {
            var index = students.IndexOf(student);
            students.Add(student);
            Save();
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(file.FullName, false))
            {
                string json = JsonConvert.SerializeObject(students);
                sw.WriteLine(json);
            }
        }

        public void Remove(Student product)
        {
            students.Remove(product);//base sur Student.Equals redefini
            Save();
        }

        public IEnumerable<Student> Find()
        {
            return new List<Student>(students);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return new List<Student>(students.Where(predicate).ToArray());
        }
    }
}
