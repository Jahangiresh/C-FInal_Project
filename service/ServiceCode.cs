using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFinal
{
    class ServiceCode : IServiceCode
    {
        private List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;
        private static List<Student> _students =  new List<Student>();
        public static List<Student> Students = _students;
        public bool CheckGroup(string no)
        {
            for (int i = 0; i < no.Length; i++)
            {

                if (no.Length == 4 && char.IsUpper(no[0]) && char.IsDigit(no[1]) &&char.IsDigit(no[2]) && char.IsDigit(no[3]))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("GROUP NAME MUST CONTAIN 1 CAPITAL AND 3 DIGITS");
                    break;
                }
                
            }
           
            return false;
        }
        public bool CheckStudentName(string fullname)
        {
           
            if (fullname.Contains(' '))
            {
                string[] subs = fullname.Split(' ');
                string name = subs[0];
                string surname = subs[1];
                if (char.IsUpper(name[0]) && char.IsUpper(surname[0]))
                {

                    return true;
                }
                else
                {

                    Console.WriteLine("FIRST LETTERS MUST BE CAPITAL");
                }
            }
            else
            {
                Console.WriteLine("THERE IS NO SPACE BETWEEN NAME AND SURNAME");
                
            }
            return true;
        }
        public string CreateGroup(Category categories, string no, bool isOnline)
        {
            Group group = new Group(categories, no, isOnline);
            if (!CheckGroup(no))
            {
               

            }
            if(isOnline == true)
            {
                group.Limit = 15;
            }
            else
            {
                group.Limit = 10;
            }

            Groups.Add(group);
            return group.No;
        }
        public void ShowGroups()
        {
            if (_groups.Count == 0)
            {
                Console.Clear();
                Console.Beep();
                Console.Error.WriteLine("THERE IS NO GROUP YET");
                return;
            }
            foreach (Group group in _groups)
            {
                Console.WriteLine(group);
            }

        }
        public void EditGroupName(string no, string newNo)
        {
            Group existedGroup = FindGroup(no);

            if (existedGroup == null)
            {
                Console.Clear();
                Console.Beep();
                Console.Error.WriteLine("THERE IS NO GROUP WITH THIS NAME");
                return;
            }

            foreach (Group group in _groups)
            {
                if (group.No == newNo)
                {
                    Console.WriteLine($"{newNo} GROUP IS ALREADY EXITS");
                    return;
                }
            }
            existedGroup.No = newNo;
            Console.WriteLine($"GROUP {no} SUCCESFULY CHANGED TO {newNo}");
        }
        public Group FindGroup(string no)
        {
            foreach (Group group in Groups)
            {
                if (group.No == no)
                {
                    return group;
          
                }
            }
            return null;
            
        }
        public void GetGroupStudents(string no)
        {
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.Clear();
                Console.Beep();
                Console.Error.WriteLine("PLEASE CHOOSE VALID GROUP NUM");
               
                return;
            }
            if (Students.Count!=0)
            {
                foreach (Student student in group.Students)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {

                Console.Clear();
                Console.Beep();
                Console.Error.WriteLine($"THERE IS NOT ANY STUDENT IN GROUP: {group}");
            
                
            }
            
        }
        public void GetAllStudents()
        {
            if (Students.Count!=0)
            {
                foreach (Student student in Students)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.Clear();
                Console.Beep();
                Console.Error.WriteLine("THERE IS NO STUDENTS IN THIS ACADEMY" ); 


            }
           
        }
        public bool CheckGaranty(bool hasgaranty)
        {
            if (hasgaranty)
            {
                return true;
            }
            return false;
        }
       
        public void CreateStudent(string fullname, string groupno,bool hasgaranty)
        {

            CheckStudentName(fullname);
            
           
           
            Student student = new Student(fullname, groupno,hasgaranty);
            Group group = FindGroup(groupno);
            group.Students.Add(student);
            Students.Add(student);

        }

      

     
    }
}