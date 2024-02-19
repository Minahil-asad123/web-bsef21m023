using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OrderMain
{
    static void Main(string[] args)
    {

        OrderCRUD orderCRUD = new OrderCRUD();

        while (true)
        {
            Console.WriteLine("1. Insert Order");
            Console.WriteLine("2. Update Order");
            Console.WriteLine("3. Read Order");
            Console.WriteLine("4. Delete Order");
            Console.WriteLine("5. Param Update Order");
            Console.WriteLine("6. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice from 1 to 6:  ");
            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    //Console.Write("Enter Order ID:  ");
                    //string orderid = Console.ReadLine();
                    Console.Write("Enter Customer CNIC :  ");
                    string cnic = Console.ReadLine();
                    Console.Write("Enter Customer Name:  ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Customer Phone No:  ");
                    string phone = Console.ReadLine();
                    Console.Write("Enter Customer Address:  ");
                    string address = Console.ReadLine();
                    Console.Write("Enter Product ID:  ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Product Price:  ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Product Size:  ");
                    string size = Console.ReadLine();

                    Order order = new Order();

                    order.Price = price;
                    order.Size = size;
                    order.ProdID = id;
                    //order.OrderID = orderid;
                    order.Cust_Address = address;
                    order.Cust_CNIC = cnic;
                    order.Cust_Name = name;
                    order.Cust_PhoneNo = phone;

                    orderCRUD.InsertOrder(order);
                    Console.WriteLine();

                    break;
                case 2:
                    Console.Write("Enter Customer Phone No:  ");
                    string phone2 = Console.ReadLine();
                    
                    Console.Write("Enter New Customer Address:  ");
                    string newaddress = Console.ReadLine();

                    orderCRUD.UpdateAddress(phone2, newaddress);
                    Console.WriteLine();
                    break;
                case 3:
                    orderCRUD.GetAllOrders();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Write("Enter Order ID:  ");
                    string order_id = Console.ReadLine();

                    orderCRUD.DeleteOrder(order_id);
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Enter Customer Phone No:  ");
                    string phone3 = Console.ReadLine();
                    Console.Write("Enter New Customer Address:  ");
                    string newupdatedaddress = Console.ReadLine();

                    orderCRUD.UpdateOrderAddress(phone3, newupdatedaddress);
                    Console.WriteLine();
                    break;
                case 6:

                    return;
            }
        }
    }
}