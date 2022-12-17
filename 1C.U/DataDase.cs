using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C.U
{
    class DataBase
    {
        static string connectString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Inventory;Integrated Security=true;";
        static SqlConnection myConnection = new SqlConnection(connectString);

        public static List<User> LoadUsersData()
        {
            myConnection.Open();

            string query = "SELECT * FROM Users ORDER BY ID";
            
            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            var usersData = new List<User>();

            while (reader.Read())
            {
                if((bool)reader[3])
                    usersData.Add(new Admin()
                    {
                        Id = (int)reader[0],
                        NickName = reader[1].ToString(),
                        Password = reader[2].ToString()
                    });
                else
                    usersData.Add(new User()
                    {
                        Id = (int)reader[0],
                        NickName = reader[1].ToString(),
                        Password = reader[2].ToString()
                    });
            }

            reader.Close();

            myConnection.Close();

            return usersData;
        }

        public static void LoadItemsData()
        {
            myConnection.Open();

            string query = "SELECT * FROM Items ORDER BY ID";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            ListForm.TableData = new List<InventoryItem>();

            while (reader.Read())
            {
                ListForm.TableData.Add(new InventoryItem() {
                    Id = (int)reader[0],
                    Name = reader[1].ToString(),
                    Count = (int)reader[2]
                });
            }

            reader.Close();

            myConnection.Close();
        }

        public static void DeleteRow(string id)
        {
           
        }

        public static void AddRow(string values)
        {
           
        }

        public static void AddUser(string values)
        {
            
        }
    }
}
