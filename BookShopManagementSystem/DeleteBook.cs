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
    public partial class DeleteBook : Form
    {
        public DeleteBook()
        {
            InitializeComponent();
        }

        private void DeleteBook_Load(object sender, EventArgs e)
        {
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;"))
                {
                    con.Open();

                    // Use parameterized query to prevent SQL injection
                    string deleteQuery = "DELETE FROM [Books] WHERE book_id = @book_id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@book_id", textBox1.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book record deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No book found with the given ID.");
                    }

                    // Refresh the DataGridView to show updated data
                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            textBox1.Text = ""; // Clear the input after deletion
        }
    }
    
}
