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
    public partial class SaleBook : Form
    {
        public SaleBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection = True; ");
            con.Open();
            try
            {
                string str = " INSERT INTO Sale(name,mobile,address,book_id,title,price,total) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select max(id) from Sale;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Customer Name " + textBox1.Text + "'s Details is Inserted Successfully.. ", "Important Message");
                    this.Hide();
                }
                this.Close();
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
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
            
        }
    }
}
