using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopByADO.NET.Repository
{
    public class CustomerRepository
    {
        public bool Insert(string customerName, string cell, string address)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //INSERT INTO Items (Name, Price) Values ('Black', 120)


            string commandString = @"INSERT INTO Customer_Information (Customer_Name, Cell,Address) Values ('" + customerName + "', '" + cell + "','" + address + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                return true;
            }

            //Close
            sqlConnection.Close();
            return false;
        }

        public bool Update(string customerName, string cell, string address,int id)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"UPDATE Customer_Information SET Customer_Name= '" + customerName + "',Cell='" + cell + "',Address='" + address + "' WHERE id='" + id + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute

            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                return true;
            }

            //Close
            sqlConnection.Close();
            return false;
        }

        public bool Delete(string id)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"DELETE FROM Customer_Information WHERE id = " + id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute

            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                return true;
            }
            

            //Close
            sqlConnection.Close();
            return false;
        }

        public DataTable Show()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //SELECT * FROM Items
            string commandString = @"SELECT * FROM Customer_Information";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            //Close
            sqlConnection.Close();
            return dataTable;
        }

        public DataTable Search(string name)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //SELECT * FROM Items
            string commandString = @"SELECT Customer_Name, Cell,Address FROM Customer_Information WHERE Customer_Name='" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
        

            //Close
            sqlConnection.Close();
            return dataTable;
        }

        public bool IsNameExists(string name)
        {
            bool exists = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-887J8ON; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customer_Information WHERE Customer_Name='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return exists;
        }
    }
}
