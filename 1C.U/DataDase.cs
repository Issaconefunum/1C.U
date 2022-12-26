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

            string query = "SELECT * FROM Items ORDER BY id";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            ListForm.TableData = new List<InventoryItem>();

            while (reader.Read())
            {
                ListForm.TableData.Add(new InventoryItem() {
                    Id = (int)reader[0],
                    Status = reader[1].ToString(),
                    Type = reader[2].ToString(),
                    Model = reader[3].ToString(),
                    SerialNumber = (int)reader[4],
                    Employee = reader[5].ToString(),
                    JobTitle = reader[6].ToString(),
                    EmployeeEmail = reader[7].ToString(),
                    Branch = reader[8].ToString(),
                    Location = reader[9].ToString(),
                    Comment = reader[10].ToString()
                });
            }

            reader.Close();

            myConnection.Close();
        }

        public static List<string> LoadBranchesData()
        {
            myConnection.Open();

            string query = "SELECT * FROM Branches ORDER BY id";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            var branchesData = new List<string>();

            while (reader.Read())
            {
                branchesData.Add(reader[1].ToString());
            }

            reader.Close();

            myConnection.Close();
            return branchesData;
        }

        public static void DeleteRow(string id)
        {
            myConnection.Open();

            string query = $"DELETE FROM Items WHERE ID={id}";

            SqlCommand command = new SqlCommand(query, myConnection);

            command.ExecuteNonQuery();

            myConnection.Close();
        }

        public static void AddRow(string values)
        {
            myConnection.Open();

            string query = $"INSERT INTO Items (status, type, model, serialNumber, employee, jobTitle, employeeEmail, branch, location, comment) VALUES ({values})";

            SqlCommand command = new SqlCommand(query, myConnection);

            command.ExecuteNonQuery();

            myConnection.Close();
        }

        public static void AddUser(string values)
        {
            myConnection.Open();

            string query = $"INSERT INTO Users (nick, password, adminRoots) VALUES ({values})";

            SqlCommand command = new SqlCommand(query, myConnection);

            command.ExecuteNonQuery();

            myConnection.Close();
        }
    }
}
