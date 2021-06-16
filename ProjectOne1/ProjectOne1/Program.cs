using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectOne1
{
    //Defining a class Teacher
    class Teacher
    {
        public int tId;
        public string tName;
        public string tClass;
        public string tSection;
    }

    class Program
    {

        static List<Teacher> tList = new List<Teacher>();
        string filePath = @"C:\Users\DELL\Desktop\ProjevtOneC#\ProjectOne.txt";
        static Teacher teacher = new Teacher();


        //Password verfication and Menu 
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  \t\t    ******************************************************");
            Console.WriteLine("  \t\t    *                                                    *");
            Console.WriteLine("  \t\t    *    Welcome to Rainbow School System Management!!   *");
            Console.WriteLine("  \t\t    *                                                    *");
            Console.WriteLine("  \t\t    ******************************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nEnter your password: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string password = Console.ReadLine();

            if (password == "asmaa")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n   Menu");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1)Add Teacher\n" +
                    "2)Retrive Teacher\n" +
                    "3)Update Teacher\n" +
                    "4)Delete Teacher\n" +
                    "5)Close\n\n");
                bool close = true;

                while (close)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Choose your option from menu: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    int option = Convert.ToInt32((Console.ReadLine()));

                    if (option == 1)
                    {
                        addTeacher();
                    }
                    else if (option == 2)
                    {
                        retrivehTeacher();
                    }
                    else if (option == 3)
                    {
                        updateTeacher();
                    }
                    else if (option == 4)
                    {
                        removeTeacher();
                    }
                    else if (option == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n    Thank you so much ...");
                        close = false;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option\nRetry !!!");
                    }

                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid password");
            }
            Console.ReadLine();
        }


        //To add teacher
        public static void addTeacher()
        {
            string filenm = @"C:\Users\DELL\Desktop\ProjevtOneC#\ProjectOne.txt";
            List<string> tList = File.ReadAllLines(filenm).ToList();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Teacher ID: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(teacher.tId = tList.Count + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Teacher Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            teacher.tName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Teacher Class: ");
            Console.ForegroundColor = ConsoleColor.White;
            teacher.tClass = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Teacher Section: ");
            Console.ForegroundColor = ConsoleColor.White;
            teacher.tSection = Console.ReadLine();

            string x = teacher.tId.ToString() + "     " + teacher.tName + "     " + teacher.tClass + "     " + teacher.tSection;

            tList.Add(x);
            tList.Sort();
            File.WriteAllLines(filenm, tList);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Information Added successfully...\n");
            Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filenm))
            {
                foreach (string ln in tList)
                {
                    writer.WriteLine(ln);
                    writer.Flush();
                }
            }
        }


        //To delete Teacher
        public static void removeTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nEnter teacher ID to be deleted : ");
            Console.ForegroundColor = ConsoleColor.White;
            int n = Convert.ToInt32(Console.ReadLine());
            try
            {
                string filenm = @"C:\Users\DELL\Desktop\ProjevtOneC#\ProjectOne.txt";
                List<string> tList = File.ReadAllLines(filenm).ToList();
                tList.RemoveAt(n - 1);
                File.WriteAllLines(filenm, tList.ToArray());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Teacher id -{0} has been deleted\n", n);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teacher id {0} not found \n", n);
            }
        }



        //To Retrive teacher information
        public static void retrivehTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nChoose:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("1-Retrive teacher data from ID \n2-Retrive all teachers data\n==> ");
            Console.ForegroundColor = ConsoleColor.White;
            int n = int.Parse(Console.ReadLine());
            string filenm = @"C:\Users\DELL\Desktop\ProjevtOneC#\ProjectOne.txt";
            switch (n)
            {
                case 1:
                    if (File.Exists(filenm))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter teacher ID: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int find = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            List<string> tList = File.ReadAllLines(filenm).ToList();
                            TextReader trr = new StreamReader(filenm);
                            Console.WriteLine(tList[find - 1]);
                            Console.WriteLine();
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("teacher ID {0} not found\n", find);

                        }
                    }
                    break;

                case 2:

                    if (File.Exists(filenm))
                    {
                        TextReader trr = new StreamReader(filenm);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(trr.ReadToEnd());
                        trr.Close();
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong choice!...\n");
                    break;
            }
        }



        //To Update teacher Information 
        public static void updateTeacher()
        {
            try
            {
                string filenm = @"C:\Users\DELL\Desktop\ProjevtOneC#\ProjectOne.txt";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEnter teacher ID to update information: ");
                List<string> tList = File.ReadAllLines(filenm).ToList();
                Console.ForegroundColor = ConsoleColor.White;
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Update Name: ");
                Console.ForegroundColor = ConsoleColor.White;
                string name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("update Class: ");
                Console.ForegroundColor = ConsoleColor.White;
                string classs = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("update Section: ");
                Console.ForegroundColor = ConsoleColor.White;
                string section = Console.ReadLine();

                tList[id - 1] = id + "     " + name + "     " + classs + "     " + section;
                File.WriteAllLines(filenm, tList);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Information updated successfully...\n");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong ID - Not Found!....\n");
            }
        }
    }
}