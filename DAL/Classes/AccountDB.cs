using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pkcs;
using System.Drawing.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ClassLib.Interfaces;
using ClassLib.Classes;
using System.Data;


namespace DAL.Classes
{
    public class AccountDB : IAccountHandler
    {
        public MySqlConnection MakeConnection()
        {
            
            string connectionString =
                "Server=secretServer;" +
                "Database=database_name;" +
                "User ID=username;" +
                "Password=password;" +
                "Connection Timeout=2;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            if (TestConnection(connection))
            {
                return connection;
            }
            else
            {
                Console.WriteLine("Connection test failed.");
                return null;
            }

        }
        public bool TestConnection(MySqlConnection conn)
        {
            try
            {
                conn.Open();
                return conn.State == ConnectionState.Open;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MYSQL Exception: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool PublicRegister(object[] registerData)
        {
            return PushNewAcc(registerData, MakeConnection());
        }

        public User PublicLogin(string email, string password)
        {
            return FetchLogin(email, password, MakeConnection());
        }

        public List<User> GetUsers()
        {
            return PrivateGetUsers(MakeConnection());
        }

        public User GetLoggedinUserr(int id)
        {
            return FetchLoggedin(id, MakeConnection());
        }

        private User FetchLogin(string email, string password, MySqlConnection connection)
        {
            User user = null;
            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                    string query = "SELECT * FROM users WHERE email = @email";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string name = reader["name"].ToString();
                                string accType = reader["type"].ToString();
                                int phoneNum = Convert.ToInt32(reader["phonenumber"]);
                                string storedHashedPass = reader["password"].ToString();
                                byte[] salt = (byte[])reader["salt"];

                                string hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                    password: password,
                                    salt: salt,
                                    prf: KeyDerivationPrf.HMACSHA256,
                                    iterationCount: 100000,
                                    numBytesRequested: 256 / 8));

                                if (hashedPass == storedHashedPass)
                                {
                                    if (accType == "Private")
                                    {
                                        user = new PrivateSeller(id, accType, name, email, phoneNum);
                                    }
                                    else if (accType == "Admin")
                                    {
                                        user = new Admin(id, accType, name, email, phoneNum);
                                    }
                                    else
                                    {
                                        user = new Broker(id, accType, name, email, phoneNum);
                                    }

                                    return user;
                                }
                            }
                        }
                    }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }

            return user;
        }
    

        private bool PushNewAcc(object[] registerData, MySqlConnection connection)
        {
            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();

                        string query =
                            "INSERT INTO users (type, name, email, phonenumber, password, salt) VALUES (@type, @name, @email, @phonenumber, @password, @salt)";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@type", registerData[0]);
                            cmd.Parameters.AddWithValue("@name", registerData[1]);
                            cmd.Parameters.AddWithValue("@email", registerData[2]);
                            cmd.Parameters.AddWithValue("@phonenumber", registerData[3]);
                            cmd.Parameters.AddWithValue("@password", registerData[4]);
                            cmd.Parameters.AddWithValue("@salt", registerData[5]);

                            cmd.ExecuteNonQuery();

                        }

                        Console.WriteLine("succesfully created account");
                        return true;
                    }

                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }

        private List<User> PrivateGetUsers(MySqlConnection connection)
        {
            List<User> users = new List<User>();

            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                        string query = "SELECT * FROM users";

                        using (MySqlCommand cmd = new(query, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int userId = Convert.ToInt32(reader["id"]);
                                    string accountType = reader["type"].ToString();
                                    string name = reader["name"].ToString();
                                    string email = reader["email"].ToString();
                                    int phonenum = Convert.ToInt32(reader["phonenumber"]);


                                    if (accountType == "Private")
                                    {
                                        users.Add(new PrivateSeller(userId, accountType, name, email, phonenum));
                                    }
                                    else if (accountType == "Admin")
                                    {
                                        users.Add(new Admin(userId, accountType, name, email, phonenum));
                                    }
                                    else
                                    {
                                        users.Add(new Broker(userId, accountType, name, email, phonenum));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Retrieving users went wrong:", ex);
                }
            }
            return users;
        }


        private User FetchLoggedin(int id, MySqlConnection connection)
        {
            User user = null;

            using (connection)
            {
                try
                {
                    if (connection != null)
                    {
                        connection.Open();
                    string query = "SELECT * FROM users WHERE id = @ownerId";

                    using (MySqlCommand cmd = new(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ownerId", id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["id"]);
                                string accountType = reader["type"].ToString();
                                string name = reader["name"].ToString();
                                string email = reader["email"].ToString();
                                int phonenum = Convert.ToInt32(reader["phonenumber"]);


                                if (accountType == "Private")
                                {
                                    user = new PrivateSeller(userId, accountType, name, email, phonenum);
                                }
                                else if (accountType == "Admin")
                                {
                                    user = new Admin(userId, accountType, name, email, phonenum);
                                }
                                else
                                {
                                    user = new Broker(userId, accountType, name, email, phonenum);
                                }
                            }
                        }
                    }
                    }
                    else
                    {
                        Console.WriteLine("Connection Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Retrieving users went wrong:", ex);
                }
            }

            return user;
        }
    }
}
