using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFinal.service
{
    static class ServiceMenu
    {
        public static ServiceCode serviceCode = new ServiceCode();
        public static void CreateGroupMenu()
        {


            Console.WriteLine("TYPE GROUP NO");
            string no = Console.ReadLine();
            if (serviceCode.CheckGroup(no))
            {
                Console.WriteLine("1.ONLINE GROUP\n2.OFFLINE GROUP");
                string strOnline = Console.ReadLine();
                bool resultLimit = int.TryParse(strOnline, out int num);
                bool isOnline = false;

                if (resultLimit)
                {
                    switch (num)
                    {

                        case 1:
                            isOnline = true;
                            break;
                        case 2:
                            isOnline = false;
                            break;
                        default:
                            Console.WriteLine("choose  valid num!  1 or  2 PLEASE ");
                            return;
                    }

                }
                //else
                //{
                //    Console.WriteLine("asad");
                //    return;
                //}
                foreach (Category c in System.Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)c} {c}");
                }
                int category;
                string catStr = Console.ReadLine();
                bool resultCat = int.TryParse(catStr, out category);
                if (resultCat)
                {
                    switch (category)
                    {
                        case (int)Category.Programming:

                            string No = serviceCode.CreateGroup(Category.Programming, no, isOnline);
                            Console.WriteLine($"{No} group succesfully created");
                            break;
                        case (int)Category.Design:

                            No = serviceCode.CreateGroup(Category.Design, no, isOnline);
                            Console.WriteLine($"{No} group succesfully created");
                            break;
                        case (int)Category.System_Administration:

                            No = serviceCode.CreateGroup(Category.System_Administration, no, isOnline);
                            Console.WriteLine($"{No} group succesfully created");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("please choose valid category");
                }
            }

        }
        public static void EditGroupMenu()
        {
            Console.WriteLine("TYPE GROUP NO");
            string no = Console.ReadLine();
            Console.WriteLine("TYPE NEW GROUP NO");
            string newNo = Console.ReadLine();
            if (newNo != no && serviceCode.CheckGroup(newNo))
            {
                serviceCode.EditGroupName(no, newNo);
            }
            else
            {
                Console.WriteLine("Yeni adi duz yazin");
            }

        }
        public static void ShowGroupsMenu()
        {
            serviceCode.ShowGroups();
        }
        public static void GetGroupStudentsMenu()
        {
            Console.WriteLine("TYPE GROUP NO");
            string no = Console.ReadLine();
            serviceCode.GetGroupStudents(no);
        }
        public static void GetAllStudentsMenu()
        {

            serviceCode.GetAllStudents();
        }
        public static void CreateStudentMenu()
        {

            Console.WriteLine("TYPE NAME AND SURNAME");
            string? fullname = Console.ReadLine();
            Console.WriteLine("GROUP NO :");
            string? qrupno = Console.ReadLine();
            Group existedQrup = serviceCode.FindGroup(qrupno);

            if (existedQrup == null)
            {
                Console.WriteLine("PLEASE CHOOSE EXISTED GROUP NO");
                return;
            }

            if (existedQrup.Limit <= existedQrup.Students.Count)
            {
                Console.WriteLine("GROUP IS FULL");
                return;
            }

            Console.WriteLine("1.with GARANTY\n2.without GARANTY");


            int garant;
            string? garantystr = Console.ReadLine();
            bool resultCat = int.TryParse(garantystr, out garant);
            if (garant==2||garant==1)
            {
                switch (garant)
                {
                    case 1:
                        serviceCode.CheckGaranty(true);
                        break;
                    case 2:
                        serviceCode.CheckGaranty(false);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("CHOOSE VALID NUM 1 OR 2"); return;
            }
            





            Student student = new Student(fullname, qrupno, true);
            serviceCode.CreateStudent(fullname, qrupno, true);


            Console.WriteLine($"STUDENT {fullname} SUCCESFULLY CREATED");


        }
    }
}
