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
    public partial class SearchBook : Form
    {
        public SearchBook()
        {
            InitializeComponent();
        }

        private void SearchBook_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection = True; "))
            {

                string query = "SELECT * FROM Books WHERE book_id = @book_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@book_id", textBox1.Text);  

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0) 
                {
                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
                else
                {
                    MessageBox.Show("No book found with the given ID.");  
                }
            }

            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;"))
            {
                string query = "SELECT * FROM Books"; // Query to get all books
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt; // Show all books in DataGridView
                }
                else
                {
                    MessageBox.Show("No books found.");
                }
            }


        }
    }
}
