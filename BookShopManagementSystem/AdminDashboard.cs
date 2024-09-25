using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookShopManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void newBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks obj1 = new AddBooks();
            obj1.ShowDialog();
        }

        private void saleBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleBook obj2 = new SaleBook();
            obj2.ShowDialog();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookData obj3 = new BookData();
            obj3.ShowDialog();
        }

        private void viewRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleviewRecords obj4 = new SaleviewRecords();
            obj4.ShowDialog();
        }

        private void deleteBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBook obj5 = new DeleteBook();
            obj5.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBook obj6 = new SearchBook();
            obj6.ShowDialog();
        }
    }
}
