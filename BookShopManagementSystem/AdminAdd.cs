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
    public partial class AdminAdd : Form
    {
        public AdminAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("INSERT INTO [admin] (username,password) VALUES(@username,@password)",con);
            cmd.Parameters.AddWithValue("@username",textBox1.Text);
            cmd.Parameters.AddWithValue("password", textBox2.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Admin addedd successfully");
        }
    }
}
