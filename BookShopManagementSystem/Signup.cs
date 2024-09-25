using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagementSystem
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        


        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;");

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") {
                MessageBox.Show("All Fields are Required");
            }

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text)) {
                
                SqlCommand cmd = new SqlCommand("INSERT INTO [User] (name,username,password) VALUES(@name,@username,@password)", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@username", textBox2.Text);
                cmd.Parameters.AddWithValue("@password", textBox3.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("User SignUp Successfully");
                Login loginForm = new Login();
                loginForm.ShowDialog();
                this.Hide();
            }
                
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
