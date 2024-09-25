using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BookShopManagementSystem
{
    public partial class Login : Form
    {

        public string LoggedInUsername { get; private set; }
        public int LoggedInUserId { get; private set; }

        private string adminConString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection = True; ";
        private string userConString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection = True; ";
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




       // public bool IsAdmin { get; private set; } // Add this to your Login form

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                // Admin check
                if (CheckAdmin(username, password))
                {
                  //  IsAdmin = true; // Set IsAdmin to true
                    AdminDashboard home = new AdminDashboard();
                    home.Show();
                    this.Hide();
                }
                else if (CheckUser(username, password, out string name, out int userId))
                {
                   // IsAdmin = false; // Set IsAdmin to false
                    LoggedInUsername = name;
                    LoggedInUserId = userId;
                    Console.WriteLine($"Login successful for user: {username} (User ID: {userId})");
                    UserDashboard userDashboard = new UserDashboard(name, userId);
                    userDashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                    textBox1.Text = "";
                    textBox2.Text = "";

                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private bool CheckAdmin(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(adminConString))
                {
                    string query = "SELECT COUNT(*) FROM [admin] WHERE username = @username AND password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        con.Open();

                        int result = (int)cmd.ExecuteScalar();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CheckAdmin: {ex.Message}");
                return false;
            }
        }

        private bool CheckUser(string username, string password, out string name, out int userId)
        {
            name = string.Empty;
            userId = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(userConString))
                {
                    string query = "SELECT userId, name FROM [User] WHERE username = @username AND password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@password", textBox2.Text);

                        //MessageBox.Show($"Executing Admin Query: {query} with Username: {username} and Password: {password}");
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            userId = (int)reader["userId"];
                            name = reader["name"].ToString(); // Retrieve the full name
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CheckUser: {ex.Message}");
                return false;
            }
        }





        private int GetUserId(string username)
        {
            using (SqlConnection connection = new SqlConnection(userConString))
            {
                connection.Open();
                string query = "SELECT userId FROM [User] WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup userForm = new Signup();
            userForm.ShowDialog();
            //this.Close();
            this.Hide();
        }

        

    }
}
