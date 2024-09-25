using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookShopManagementSystem
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection = True; ");
            
            SqlCommand cmd = new SqlCommand("INSERT INTO [Books] VALUES(@book_id,@title,@edition,@author,@ISBN,@publisher,@category,@price,@stock)",con);
            cmd.Parameters.AddWithValue("@book_id",textBox1.Text);
            cmd.Parameters.AddWithValue("@title", textBox2.Text);
            cmd.Parameters.AddWithValue("@edition", textBox3.Text);
            cmd.Parameters.AddWithValue("@author", textBox4.Text);
            cmd.Parameters.AddWithValue("@ISBN", textBox5.Text);
            cmd.Parameters.AddWithValue("@publisher", textBox6.Text);
            cmd.Parameters.AddWithValue("@category", textBox7.Text);
            cmd.Parameters.AddWithValue("@price", textBox8.Text);
            cmd.Parameters.AddWithValue("@stock", textBox9.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Book added Successfully in Books Database");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
    }
}
