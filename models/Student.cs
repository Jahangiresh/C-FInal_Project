using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFinal

{
    class Student
    {
        public string Fullname;
        public string GroupNo;
        public bool HasGaranty;
        public Student(string fullname, string groupno,bool hasgaranty)
        {
            Fullname = fullname;
            GroupNo = groupno;
            HasGaranty = hasgaranty;
        }


        public override string ToString()
        {
            string statusStudent = HasGaranty ? "zemanetli" : "zemanetsiz";
            return $"ad soyad:{Fullname}, Grup nom:{GroupNo}, Status: {statusStudent}";
        }
    }
}