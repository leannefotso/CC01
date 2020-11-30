using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BLL
{
    public class University
    {
        University universityRepo;
        private string dbFolder;

        public object Logo { get; private set; }

        public University(string dbFolder)
        {
            this.dbFolder = dbFolder;
            universityRepo = new University(dbFolder);
        }

        public void CreateUniversity(University oldUniversity, University newUniversity)
            {
                         string filename = null;
               if (!string.IsNullOrEmpty((string)newUniversity.Logo))
               {
                   string ext = Path.GetExtension((string)newUniversity.Logo);
                   filename = Guid.NewGuid().ToString() + ext;
                   FileInfo fileSource = new FileInfo((string)newUniversity.Logo);
                   string filePath = Path.Combine(dbFolder, "logo", filename);
                   FileInfo fileDest = new FileInfo(filePath);
                   if (!fileDest.Directory.Exists)
                       fileDest.Directory.Create();
                   fileSource.CopyTo(fileDest.FullName);
               }
               newUniversity.Logo = filename;
               universityRepo.Add(newUniversity);

               if (!string.IsNullOrEmpty((string)oldUniversity.Logo))
                   File.Delete((string)oldUniversity.Logo);
            }

        private void Add(University newUniversity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<University> GetBy(Func<University, bool> predicate)
            {
                return universityRepo.Find(predicate);
            }

                 public University GetUniversity()
                 {
                       University university = universityRepo.Get();
                       if (university != null)
                           if (!string.IsNullOrEmpty((string)university.Logo))
                               university.Logo = Path.Combine(dbFolder, "logo", (string)university.Logo);
                       return university;
                 }


            public void DeleteUniversity(University university)
            {
                universityRepo.Remove(university);
            }

        private void Remove(University university)
        {
            throw new NotImplementedException();
        }

        public void CreateUniversity(University newUniversity)
            {
                universityRepo.Add(newUniversity);
            }

            public void EditUniversity(University oldUniversity, University newUniversity)
            {
                universityRepo.Set(oldUniversity, newUniversity);
            }

        private void Set(University oldUniversity, University newUniversity)
        {
            throw new NotImplementedException();
        }
    }
}
