using ConsoleAppFinal.service;
using System;



namespace ConsoleAppFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection;
            do
            {
                Console.WriteLine("1.Create new group\n2.Edit group name\n3.Show group list\n4.Show students list in group\n5.Show all students list\n6.Create student\n0.Exit");
                string strSelection = Console.ReadLine();
                bool result = int.TryParse(strSelection, out selection);

                if (result&&selection>0)
                {
                    switch (selection)
                    {
                        case 1:
                            ServiceMenu.CreateGroupMenu();
                           
                            break;
                        case 2:
                            ServiceMenu.EditGroupMenu();
                            break;
                        case 3:
                            ServiceMenu.ShowGroupsMenu();
                            break;
                        case 4:
                            ServiceMenu.GetGroupStudentsMenu();
                                break;
                        case 5:
                            ServiceMenu.GetAllStudentsMenu();
                                break;
                        case 6:
                            ServiceMenu.CreateStudentMenu();
                            break;
                        default:
                            Console.Beep();  
                           //Console.ForegroundColor = ConsoleColor.Red;              
                            Console.WriteLine("1.Create new group\n2.Edit group name\n3.Show group list\n4.Show students list in group\n5.Show all students list\n6.Create student\n0.Exit");
                            Console.Clear();
                            Console.Error.WriteLine("PLEASE CHOOSE VALID NUM");
                            break;
                    }

                }
                else
                {
                 
                    Console.Clear();
                    Console.Beep();
                    Console.Error.WriteLine("PLEASE CHOOSE VALID NUM");
                    Console.WriteLine("1.Create new group\n2.Edit group name\n3.Show group list\n4.Show students list in group\n5.Show all students list\n6.Create student\n0.Exit");
                }

            } while (selection != 0 );

            



        }
    }
}