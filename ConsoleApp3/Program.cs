using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<string> Employee = new List<string>();
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Clear();
                Console.WriteLine("********* Welcome *********");
                Console.WriteLine();
                Console.WriteLine("Please Insert Username :");
                string UserName = Console.ReadLine();

                Console.WriteLine("Please Insert Password :");
                string Password = Console.ReadLine();

                if (UserName == "admin" && Password == "admin")
                {
                    bool adminActive = true;
                    while (adminActive)
                    {
                        Console.Clear();
                        adminMenu();
                        string Input = Console.ReadLine();
                        switch (Input)
                        {
                            case "1":
                                insertEmployee(Employee);
                                break;

                            case "2":
                                editEmployee(Employee);
                                break;

                            case "3":
                                deleteEmployee(Employee);
                                break;

                            case "4":
                                printEmployee(Employee);
                                break;

                            case "5":
                                setTask(Employee);
                                break;

                            case "6":
                                adminActive = false;
                                break;

                            default:
                                Console.WriteLine("Try again");
                                Console.ReadKey();
                                break;
                        }

                    }
                }
                else if (UserName == "guest")
                {
                    bool guestActive = true;
                    while (guestActive)
                    {
                        Console.Clear();
                        guestMenu();
                        string Input = Console.ReadLine();
                        switch (Input)
                        {
                            case "1":
                                printEmployee(Employee);
                                break;

                            case "2":
                                guestActive = false;
                                break;

                            default:
                                Console.WriteLine("Try again");
                                break;

                        }
                        Console.ReadKey();
                    }
                }
            }
        }

        private static void deleteEmployee(List<string> Employee)
        {
            Console.Clear();
            Console.WriteLine("Insert username for delete :");
            string search = Console.ReadLine();
            bool find = false;
            for (int i = 0; i < Employee.Count; i++)
            {
                string[] data = Employee[i].Split(',');
                if (search == data[0])
                {
                    find = true;
                    Console.WriteLine("Found :)");
                    Console.WriteLine($"Are you sure for delete " + data[0] + "? (y/n)");
                    string result = Console.ReadLine();

                    if (result == "y")
                    {
                        string UserName = data[0];
                        string Password = data[1];

                        Employee[i] = ($"{UserName},{Password},0");
                        Console.WriteLine("Deleted succecfully");
                        Console.WriteLine("Press Enter to continue ...");
                        Console.ReadKey();
                    }
                }
            }
            if (!find)
            {
                Console.WriteLine("Not found :(");
            }
            Console.ReadKey();

        }

        private static void editEmployee(List<string> Employee)
        {
            Console.Clear();
            Console.Write("Insert username for search :");
            string search = Console.ReadLine();
            bool find = false;
            for (int i = 0; i < Employee.Count; i++)
            {
                string[] data = Employee[i].Split(',');
                if (search == data[0])
                {
                    Console.Clear();
                    find = true;
                    Console.WriteLine($"Find" + data[0] + ":)");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.Clear();
                        editMenu();
                        string Input = Console.ReadLine();

                        switch (Input)
                        {
                            case "1":
                                break;

                            case "2":
                                break;

                            case "3":
                                break;

                            case "4":
                                return;

                            default:
                                Console.WriteLine("Try again");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
            }
            if (!find)
            {
                Console.WriteLine("Not found");
                Console.ReadKey();
            }
        }

        private static void setTask(List<string> Employee)
        {
            Console.Clear();
            Console.WriteLine("Please Insert username :");
            string search = Console.ReadLine();
            for (int i = 0; i < Employee.Count; i++)
            {
                string[] data = Employee[i].Split(',');
                if (search == data[0])
                {
                    Console.WriteLine($"Found :)   Insert new Task for " + data[0]);
                    string Task = Console.ReadLine();
                    Employee.Add(Task);
                    Console.WriteLine("Succecfully add task");
                    Console.WriteLine("Press Enter to continue ...");
                    Console.ReadKey();

                }
            }
        }

        private static void insertEmployee(List<string> Employee)
        {
            Console.Clear();

            Console.Write("Please Insert your username :");
            string UserName = Console.ReadLine();

            Console.Write("Please Insert your pass :");
            string Password = Console.ReadLine();

            string Format = $"{UserName},{Password},1";
            Employee.Add(Format);
            Console.WriteLine();
            Console.WriteLine("Aded Succecfully :) ");
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue ...");
            Console.ReadKey();
        }

        private static void printEmployee(List<string> Employee)
        {
            Console.Clear();
            for (int i = 0; i < Employee.Count; i++)
            {
                string[] data = Employee[i].Split(',');
                if (data[2] == "1" )
                {
                    Console.WriteLine($"Username : " + data[0]);
                    Console.WriteLine($"Password : " + data[1]);
                    Console.WriteLine($"Task :");
                    Console.WriteLine($"Task condition : undone");
                    Console.WriteLine($"Task id :");
                    Console.WriteLine("*******************");
                    Console.WriteLine("------------------------");

                }
            }
            Console.ReadKey();

        }
        private static void adminMenu()
        {
            Console.WriteLine("1) Add Employee");
            Console.WriteLine("2) Edit Employee");
            Console.WriteLine("3) Delete Employee");
            Console.WriteLine("4) Print Employee");
            Console.WriteLine("5) Set Task");
            Console.WriteLine("6) Logout");
        }

        private static void editMenu()
        {
            Console.WriteLine("1) Edit username");
            Console.WriteLine("2) Edit pass");
            Console.WriteLine("3) Edit task");
            Console.WriteLine("4) Exit editmenu");

        }

        private static void guestMenu()
        {
            Console.WriteLine("1) Show Task");
            Console.WriteLine("2) Logout");
        }
    }
}



