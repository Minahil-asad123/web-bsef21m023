using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Homework3
{
    class orders
    {
        private SqlDataAdapter da;
        private DataSet ds;
        private DataTable order;
        public orders()
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            order = new DataTable();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueensDB;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string query = "select * from [Orders];";
            SqlCommand cmd = new SqlCommand(query, conn);
            da.SelectCommand = cmd;
            da.Fill(order);
            da.UpdateCommand = new SqlCommandBuilder(da).GetUpdateCommand();
            order.PrimaryKey = new DataColumn[] { order.Columns["OrderID"] };
            ds.Tables.Add(order);
            conn.Close();
        }

        public void validateID(int id)
        {
            DataRow r1 = order.Rows.Find(id);
            while (r1 == null)
            {
                Console.WriteLine("No such Order exists! re-enter");
                id = int.Parse(Console.ReadLine());
                r1 = order.Rows.Find(id);
            }
        }
        public void GetOrderDetails(int orderId)
        {

            DataRow r1 = order.Rows.Find(orderId);
            if (r1 == null)
            {
                Console.WriteLine("No such Order exists!");
            }
            else
            {
                Console.WriteLine($"1. Product Name: {r1[0]}");
                Console.WriteLine($"2. Product Code: {r1[1]}");
                Console.WriteLine($"3. Product Size: {r1[2]}");
                Console.WriteLine($"4. Customer Address: {r1[3]}");
                Console.WriteLine($"5. Customer Contact: {r1[4]}");
                Console.WriteLine($"6. Product Quantity: {r1[5]}");
                Console.WriteLine($"7. Price: {r1[6]}");
                Console.WriteLine($"8. OrderID: {r1[7]}");
                Console.WriteLine($"9. Customer Name: {r1[8]}");
            }

        }

        bool IsAllDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        string GetCustomerContact()
        {
            while (true)
            {
                Console.Write("Enter customer contact (12 digits): ");
                string input = Console.ReadLine();

                if (input.Length == 12 && IsAllDigits(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Customer contact must consist of 12 digits.");
                }
            }
        }

        int GetProductQuantity()
        {
            while (true)
            {
                Console.Write("Enter product quantity: ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity >= 1)
                {
                    return quantity;
                }
                else
                {
                    Console.WriteLine("Invalid input. Product quantity must > 1");
                }
            }
        }

        public void modifyOrderDetails(int id)
        {
            DataRow r1 = order.Rows.Find(id);
            bool exit = false;
            while (!exit)
            {
                // Display menu
                Console.WriteLine("Select attribute to modify:");
                Console.WriteLine("1. ProductName");
                Console.WriteLine("2. ProductCode");
                Console.WriteLine("3. ProductSize");
                Console.WriteLine("4. CustomerAddress");
                Console.WriteLine("5. CustomerContact");
                Console.WriteLine("6. ProductQuantity");
                Console.WriteLine("7. Price");
                Console.WriteLine("8. CustomerName");
                Console.WriteLine("9. Exit");

                // Get user choice
                Console.Write("Enter the number of the attribute you want to modify (or 10 to exit): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                   r1["ProductName"]=Console.ReadLine();
                }

                else if (choice == "2")
                {
                    r1["ProductCode"] = Console.ReadLine();
                }
                else if (choice == "3")
                {
                    r1["ProductSize"] = Console.ReadLine();
                }

                else if (choice == "4")
                {
                    r1["CustomerAddress"] = Console.ReadLine();
                }
                else if (choice == "5")
                {

                    r1["CustomerContact"] = Console.ReadLine();
                }
                else if (choice == "6")
                {
                    r1["ProductQuantity"] = Console.ReadLine();
                    
                }
                else if (choice == "7")
                {
                    r1["Price"] = decimal.Parse(Console.ReadLine());
                   
                }
                else if (choice == "8")
                {
                    r1["CustomerName"] = Console.ReadLine();
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }

            }
        }
        public void deleteOrder()
        {
                int idO = int.Parse(Console.ReadLine());
                validateID(idO);
                DataRow r1 = order.Rows.Find(idO);
                r1.Delete();
         }
        public void AddNewOrder()
        {
            DataRow newR = order.NewRow();
            Console.Write("Enter ProductName: ");
            newR["ProductName"] = Console.ReadLine();
            Console.Write("Enter Product Code: ");

            newR["ProductCode"] = Console.ReadLine();

            Console.Write("Enter ProductSize: ");
            newR["ProductSize"] = Console.ReadLine();

            Console.Write("Enter CustomerAddress: ");
            newR["CustomerAddress"] = Console.ReadLine();

            Console.Write("Enter CustomerContact: ");
            newR["CustomerContact"] = GetCustomerContact();

            newR["ProductQuantity"] = GetProductQuantity();

            Console.Write("Enter Price: ");
            newR["Price"] = decimal.Parse(Console.ReadLine());

            newR["OrderID"] = order.Rows.Count + 1;

            Console.Write("Enter CustomerName: ");
            newR["CustomerName"] = Console.ReadLine();

            order.Rows.Add(newR);
        }

        public void synchronize()
        {
             da.Update(order);
                Console.WriteLine("Database updated successfully!");
        }

    }
}

