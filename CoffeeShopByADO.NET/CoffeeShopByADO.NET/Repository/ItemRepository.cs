using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopByADO.NET.Repository
{
    public class ItemRepository
    {
        public bool Insert(string name, int price)
        {
            bool isAdded = false;
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //INSERT INTO Items (Name, Price) Values ('Black', 120)




            string commandString = @"INSERT INTO Item_Info (Item_Name, Price) Values ('" + name + "', " + price + ")";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();
            //Close
            sqlConnection.Close();
            return isAdded;

        }

        public bool Delete(int id)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"DELETE FROM Item_Info WHERE Item_id = " + id + "";
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
            string commandString = @"SELECT * FROM Item_Info";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    showDataGrid.DataSource = dataTable;
            //}
            //else
            //{
            //    showDataGrid.DataSource = null;
            //    MessageBox.Show("No Data Found");
            //}


            //Close
            sqlConnection.Close();
            return dataTable;
        }

        public bool Update(string name,int price, string id)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"UPDATE Item_Info SET Item_Name= '" + name + "',Price='" + price + "' WHERE Item_id='" + id + "'";
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

        public DataTable Search(string name)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //SELECT * FROM Items
            string commandString = @"SELECT Item_Name, Price FROM Item_Info WHERE Item_Name='" + name + "'";
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
                string commandString = @"SELECT * FROM Item_Info WHERE Item_Name='" + name + "'";
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
