using System;

namespace CC01.WinForm
{
    internal class University
    {
        private string v1;
        private string text1;
        private string text2;
        private long v2;
        private object p;

        public University(object p)
        {
            this.p = p;
        }

        public University(string v1, string text1, string text2, long v2, object p)
        {
            this.v1 = v1;
            this.text1 = text1;
            this.text2 = text2;
            this.v2 = v2;
            this.p = p;
        }

        public object Logo { get; internal set; }
        public string Nom { get; internal set; }
        public string Lieu { get; internal set; }
        public string Adresse { get; internal set; }
        public object Telephone { get; internal set; }

        internal void CreateUniversity(University newUniversity)
        {
            throw new NotImplementedException();
        }

        internal void EditUniversity(University oldUniversity, University newUniversity)
        {
            throw new NotImplementedException();
        }
    }
}