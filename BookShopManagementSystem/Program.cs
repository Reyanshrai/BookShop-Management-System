using System;
using System.Windows.Forms;

namespace BookShopManagementSystem
{
    static class Program
    {
        // Entry point for the application
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new Login());
        }
    }
}
