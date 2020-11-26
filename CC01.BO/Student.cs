using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BO
{
    public class Student
    {
        public string UserName { get; set; }
        public string Matricule { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Lieu_Naissance { get; set; }
        public string Date_Naissance { get; set; }
public Student (string userName, string matricule, string fullName, string email, string lieu_Naissance, string date_Naissance)
        {
            UserName = userName;
            Matricule = matricule;
            FullName = fullName;
            Email = email;
            Lieu_Naissance = lieu_Naissance;
            Date_Naissance = date_Naissance;
        }
    }
}
