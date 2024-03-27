using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            orders or = new orders();
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("1. Receive order details");
                Console.WriteLine("2. Add new order");
                Console.WriteLine("3. modify order");
                Console.WriteLine("4. delete order");
                Console.WriteLine("5. Synchronize changes with the database");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter order id: ");
                    int id = 0;
                    try
                    {
                        id = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("invalid id");
                    }
                    or.validateID(id);
                    or.GetOrderDetails(id);
                }

                else if (choice == "2")
                {
                    or.AddNewOrder();

                }
                else if (choice == "3")
                {
                    Console.Write("Enter order id: ");
                    int id2 = 0;
                    try
                    {
                        id2 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("invalid id");
                    }
                    or.validateID(id2);
                    or.modifyOrderDetails(id2);
                }

                else if (choice == "4")
                {
                    or.deleteOrder();
                }
                else if (choice == "5")
                {

                    or.synchronize();
                }
                else if (choice == "6")
                {
                    or.synchronize();
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }

            }
        }
    }
}
