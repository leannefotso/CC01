using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BO
{
    public class Student
    {
        public string Name { get; set; }
        public string Matricule { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string LieuNaissance { get; set; }
        public string DateNaissance { get; set; }

        private string university;

        public string GetUniversity()
        {
            return university;
        }

        public void SetUniversity(string value)
        {
            university = value;
        }

        public byte[] Picture { get; set; }

        public int cmp = 0;

        public string Reference { get; set; }
        public string Logo { get; set; }
        public Student()//serialisation
        {
        }
        public Student (string name, string matricule, string fullName, string email, string lieuNaissance, 
            string dateNaissance, string university)
        {
            Name = name;
            Matricule = matricule;
            FullName = fullName;
            Email = email;
            LieuNaissance = lieuNaissance;
            DateNaissance = dateNaissance;
             

        }
        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Nom == student.Nom &&
                   Adresse == student.Adresse;
        }

        public override int GetHashCode()
        {
            int hashCode = 740290091;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Adresse);
            return hashCode;
        }
    }
}
