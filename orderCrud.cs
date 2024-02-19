using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QueenLocalDataHandling
{
    class OrderCRUD
    {
        public void insertOrder(Order o)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueensDB;Integrated Security=True;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"insert into Orders Values ('{o.OrderId}','{o.CustomerCnic}','{o.CustomerName}','{o.CustomerPhone}','{o.CustomerAddress}','{o.ProductId}','{o.ProductPrice}','{o.ProductSize}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void displayAllOrders()
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueensDB;Integrated Security=True;";
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from orders";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int n = dr.FieldCount;
            while (dr.Read())
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(dr[i]);
                } 
            }
            dr.Close();
            con.Close();
        }

        public void UpdateAddress(string ph)
        {
            string custAdd = Console.ReadLine();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueensDB;Integrated Security=True;";
            SqlConnection con = new SqlConnection(cs);
            string query = $"UPDATE Orders SET CustomerAddress='{custAdd}' WHERE CustomerPhone='+{ph}+'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }

        //function to prevent sql injection

        public void UpdateOrderAddress(string ph)
        {
            string custAdd = Console.ReadLine();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueensDB;Integrated Security=True;";
            SqlConnection con = new SqlConnection(cs);
            string query = "UPDATE Orders SET CustomerAddress=@CustAdd WHERE CustomerPhone=@Ph";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@CustAdd", custAdd);
            cmd.Parameters.AddWithValue("@Ph", ph);
            int i = cmd.ExecuteNonQuery();
            if(i==0)
            {
                Console.WriteLine("not a valid phone number");
            }
            else
            {
                Console.WriteLine("updated");
            }
            
            con.Close();
        }

        public void deleteOrder(int id)
        {
            string custAdd = Console.ReadLine();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueensDB;Integrated Security=True;";
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from orders where CustomerId='{id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}