using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadedList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            while (cont)
            {
                Console.WriteLine();
                Console.WriteLine("Activating List.....");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine();
                Console.WriteLine("1) Add name to list");
                Console.WriteLine("2) Remove name to list");
                Console.WriteLine("3) Exit");
                Console.WriteLine();
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name to add: ");
                        string aName = Console.ReadLine();
                        Console.WriteLine();

                        Thread a = new Thread(()=> { ToList.Add(aName); });
                        a.Start();
                        a.Join();
                        break;
                    case 2:
                        Console.WriteLine("Enter name to remove: ");
                        string rName = Console.ReadLine();
                        Console.WriteLine();

                        Thread r = new Thread(() => { ToList.Remove(rName); });
                        r.Start();
                        r.Join();
                        break;
                    default:
                        Console.WriteLine("Good bye!");
                        Console.WriteLine();
                        cont = false;
                        break;
                }
            }
            
        }

        class ToList
        {
            static List<string> nList = new List<string>();

            public static void Add(string str)
            {
                nList.Add(str);
                Console.WriteLine("{0} has been added to the list!",str);
                Console.WriteLine();

                Console.WriteLine("Names in the list now: ");
                foreach (string s in nList)
                {
                    Console.WriteLine(s);
                }
            }

            public static void Remove(string str)
            {
                if (nList.Contains(str))
                {
                    nList.Remove(str);
                    Console.WriteLine("{0} has been removed from the list!",str);
                    Console.WriteLine();

                    Console.WriteLine("Names in the list now: ");
                    foreach (string s in nList)
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                {
                    Console.WriteLine("Sorry! {0} cannot be found in the list!",str);
                    Console.WriteLine("Please enter a new name!");
                    Console.WriteLine();

                    Console.WriteLine("Names in the list now: ");
                    foreach (string s in nList)
                    {
                        Console.WriteLine(s);
                    }
                }
                
            }
        }
    }
}
