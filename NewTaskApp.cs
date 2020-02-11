using System;
using System.Collections.Generic;
using System.Linq;

namespace New_Task_App
{
    class Program
    {
        public static List<string> task = new List<string> { };
        public static List<string> completedTask = new List<string> { };
        public static int index = 0;
        public static ConsoleKeyInfo cki = Console.ReadKey();
        static void Main(string[] args)
        {
            Display();
            //AddTask();
            
        }

        private static void AddTask()
        {
            Console.Write("Input Task: ");
            
            task.Add(Console.ReadLine());
            Console.Clear();
            NewDisplay(task, completedTask);
        }

        private static void NewDisplay(List<string> task, List<string> completedTask)
        {
            int a = 0;
            for (int i = 0; i < task.Count; i++)
            {
                a++;
                Console.WriteLine(a + ". " + task[i]);
                
            }

            for (int j = 0; j < completedTask.Count; j++)
            {
                ;
                Console.WriteLine(completedTask[j]);
                
            } 

            Display();
        }

        private static void SelectOption(List<string> task)
        {
            while (true)
            {
                Console.WriteLine("r: ReEnter Task | c: Complete Task | e: ESC to Previous Page");
                Console.CursorVisible = false;
                for (int i = 0; i < task.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(task[i]);

                    }
                    else
                    {
                        Console.WriteLine(task[i]);
                    }
                    Console.ResetColor();

                }
                ConsoleKeyInfo cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (index == task.Count - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        index = task.Count - 1;
                    }
                    else
                    {
                        index--;
                    }
                }

                else if (cki.Key == ConsoleKey.C)
                {
                   
                    CompletedTask(task[index]);
                }
                else if (cki.Key == ConsoleKey.R)
                {
                    ReEnterTask(task[index]);
                }      
                else if (cki.Key == ConsoleKey.E)
                {
                    Console.Clear();
                    NewDisplay(task, completedTask);
                }
                else 
                {
                    Console.ResetColor();
                }

                Console.Clear();
            }
           
        }

        private static void ReEnterTask(string v)
        {
            task.Remove(v);
            task.Add(v);

            Console.Clear();
            NewDisplay(task, completedTask);
        }

        private static void CompletedTask(string v)
        {
            task.Remove(v);
            var done = " - ";
            string a = (done + v + done);
            completedTask.Add(a);

            if (completedTask.Count == 5)
            {
                completedTask.RemoveRange(0, 5);
            }
            Console.Clear();
            
            NewDisplay(task, completedTask);
        }

        private static void Display()
        {
            //TaskList();
            Console.WriteLine("\t\t\t MENU\n");
            Console.Write("a: Add Task | s: To Select a Task | ");
            Console.Write($"q: Quit | i: Save List | ");
            PageNumber();

            Console.Write("Input: ");

            UserOption(Console.ReadKey());
        }

        private static void PageNumber()
        {
            int j = task.Count + completedTask.Count;
            if (j <= 20 )
            {
                Console.Write("Page 1\n");
            }
            else if (j > 20 && j <= 40)
            {
                Console.Write("Page 2\n");
            }
            else if (j > 40)
            {
                Console.Write("Download a real task tracking application!");
            }
        }

        private static void UserOption(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.A:
                       Console.Clear();
                       AddTask();
                       break;
                case ConsoleKey.S:
                    Console.Clear();
                    SelectOption(task);
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.I:
                    SaveList();
                    break;
                default:
                    Console.WriteLine("\nPlease input a proper command.");
                    Console.ReadKey();
                    Console.Clear();
                    NewDisplay(task, completedTask);
                    break;
            }   
        }

        private static void SaveList()
        {
            string userTask = string.Join(",", task.ToArray());
            System.IO.File.WriteAllText(@"C:\Users\Luis Saenz\source\repos\Class Project\New_Task_App\List.txt", userTask);
            Console.Clear();
            NewDisplay(task, completedTask);
        }

    }
}
