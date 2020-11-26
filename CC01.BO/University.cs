using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BO
{
    public class University
    {
        public string Nom { get; set; }
        public long Telephone { get; set; }
        public string Lieu { get; set; }
        public string Adresse { get; set; }

        public University(string nom, long telephone, string lieu, string adresse)
        {
            Nom = nom;
            Telephone = telephone;
            Lieu = lieu;
            Adresse = adresse;
        }

        public override bool Equals(object obj)
        {
            return obj is University university &&
                   Nom == university.Nom &&
                   Adresse == university.Adresse;
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
