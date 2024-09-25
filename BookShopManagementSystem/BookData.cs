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
    public partial class BookData : Form
    {
        public BookData()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;");

            // Clear labels if the text box is empty
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label11.Text = "";
                label12.Text = "";
                label13.Text = "";
                label14.Text = "";
                label15.Text = "";
                label16.Text = "";
                label17.Text = "";
                label18.Text = "";
                return; // Exit the method if the text box is empty
            }

            // Check if the input is a valid integer
            if (!int.TryParse(textBox1.Text, out int bookId))
            {
                MessageBox.Show("Please enter a valid numeric Book ID.");
                return;
            }

            con.Open();
            try
            {
                string getCust = "select title, edition, author, ISBN, publisher, category, price, stock from Books where book_id = @bookId";
                SqlCommand cmd = new SqlCommand(getCust, con);
                cmd.Parameters.AddWithValue("@bookId", bookId);
                SqlDataReader dr = cmd.ExecuteReader();

                // Clear labels initially
                label11.Text = "";
                label12.Text = "";
                label13.Text = "";
                label14.Text = "";
                label15.Text = "";
                label16.Text = "";
                label17.Text = "";
                label18.Text = "";

                if (dr.Read())
                {
                    label11.Text = dr.GetValue(0).ToString();
                    label12.Text = dr.GetValue(1).ToString();
                    label13.Text = dr.GetValue(2).ToString();
                    label14.Text = dr.GetValue(3).ToString();
                    label15.Text = dr.GetValue(4).ToString();
                    label16.Text = dr.GetValue(5).ToString();
                    label17.Text = dr.GetValue(6).ToString();
                    label18.Text = dr.GetValue(7).ToString();
                }
                else
                {
                    MessageBox.Show(" *** Sorry !! This ID, " + textBox1.Text + " is INVALID. Please Check Book Id..  ***  ");
                    textBox1.Text = "";
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
