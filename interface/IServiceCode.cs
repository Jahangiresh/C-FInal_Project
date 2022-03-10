using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFinal

{
     interface IServiceCode
    {
        public static List<Group> Groups { get; }
        public static List<Student> Students { get; }
        public string CreateGroup(Category categories, string no,bool isOnline);
        public void ShowGroups();
        public void EditGroupName(string no, string newNo);
        public void GetGroupStudents(string no);
        public void GetAllStudents();
        public void CreateStudent(string fullname,string groupno,bool hasgaranty);


    }
}