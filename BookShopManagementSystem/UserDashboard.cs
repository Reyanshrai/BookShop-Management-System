//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
//using System.IO; // For FileStream
using iText.Kernel.Pdf; // For PdfWriter, PdfDocument
using iText.Layout; // For Document, Paragraph
using iText.Layout.Properties; // For SetFont
using iText.Kernel.Font; // For PdfFontFactory
using iText.Layout.Element;
using System.Linq;
//using iText.Kernel.Font.Colors; // If you need color support

namespace BookShopManagementSystem
{
    public partial class UserDashboard : Form
    {
        private int loggedInUserId;
        private string loggedInUsername;
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public UserDashboard(string name, int userId)
        {
            InitializeComponent();
            
            this.loggedInUsername = name;  // Set the logged-in user's ID
            this.loggedInUserId = userId;
            //this.loggedInUsername = username;
            this.Load += UserDashboard_Load;
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            LoadUserDetails(); // Load user details on form load
        }

        private void LoadUserDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [User] WHERE userId = @userId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userId", loggedInUserId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Display the user details in the left panel
                    string name = reader["name"].ToString();
                    string CapName = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                    label2.Text = "Welcome, " + CapName;

                    
                    string username = reader["username"].ToString();


                    tableLayoutPanelBooks.Controls.Add(new Label { Text = "Name :",Font = new Font("Arial",20,FontStyle.Bold),ForeColor = Color.OrangeRed,Margin = new Padding(50,170,0,0), Size = new Size(130, 100) });
                    tableLayoutPanelBooks.Controls.Add(new Label { Text = name, Font = new Font("Arial", 18, FontStyle.Bold), ForeColor = Color.Black , Margin = new Padding(0, 170, 0, 0), Size = new Size(130, 150) });
                    tableLayoutPanelBooks.Controls.Add(new Label { Text = "Username :", Font = new Font("Arial", 20, FontStyle.Bold), ForeColor = Color.OrangeRed , Margin = new Padding(30, 170, 0, 0), Size = new Size(200,30) });
                    tableLayoutPanelBooks.Controls.Add(new Label { Text = username, Font = new Font("Arial", 18, FontStyle.Bold), ForeColor = Color.Black , Margin = new Padding(0, 170, 0, 0), Size = new Size(130, 150) });


                    // Create Edit Button
                    Button btnEdit = new Button();
                    btnEdit.Text = "Edit";
                    btnEdit.Font = new Font("Arial", 14, FontStyle.Bold);
                    btnEdit.BackColor = Color.LightGreen;
                    btnEdit.Size = new Size(100, 40);
                    //btnEdit.Margin = new Padding(0,300,0,0);
                    btnEdit.Click += (s, e) =>
                    {
                        // Enable editing of the labels for name and username
                        var nameLabel = tableLayoutPanelBooks.Controls.OfType<Label>().FirstOrDefault(l => l.Text == name);
                        var usernameLabel = tableLayoutPanelBooks.Controls.OfType<Label>().FirstOrDefault(l => l.Text == username);

                        if (nameLabel != null && usernameLabel != null)
                        {
                            TextBox txtName = new TextBox { Text = name, Font = new Font("Arial", 15, FontStyle.Regular), ForeColor = Color.Black };
                            TextBox txtUsername = new TextBox { Text = username, Font = new Font("Arial", 15, FontStyle.Regular), ForeColor = Color.Black };

                            // Replace labels with textboxes
                            tableLayoutPanelBooks.Controls.Remove(nameLabel);
                            tableLayoutPanelBooks.Controls.Remove(usernameLabel);
                            tableLayoutPanelBooks.Controls.Add(txtName,0,0);  // Add TextBox in place of Name Label
                            tableLayoutPanelBooks.Controls.Add(txtUsername,1,0);  // Add TextBox in place of Username Label

                            // Update button click event
                            btnEdit.Text = "Save";
                            btnEdit.Click += (sender, args) =>
                            {
                                // Save new values
                                name = txtName.Text;
                                username = txtUsername.Text;

                                // Update database (SQL command below)
                                UpdateUserDetails(name, username);

                                // Replace textboxes back with labels
                                tableLayoutPanelBooks.Controls.Remove(txtName);
                                tableLayoutPanelBooks.Controls.Remove(txtUsername);
                                tableLayoutPanelBooks.Controls.Add(new Label { Text = name, Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.Black, Margin = new Padding(0, 170, 0, 0) });
                                tableLayoutPanelBooks.Controls.Add(new Label { Text = username, Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.Black , Margin = new Padding(0, 170, 0, 0) });

                                btnEdit.Text = "Edit";  // Reset button text
                            };
                        }
                    };

                    // Create Delete Button
                    Button btnDelete = new Button();
                    btnDelete.Text = "Delete";
                    btnDelete.Size = new Size(100, 40);
                    btnDelete.Font = new Font("Arial", 14, FontStyle.Bold);
                    btnDelete.BackColor = Color.IndianRed;
                    //btnDelete.Margin = new Padding(0, 300, 0, 0);
                    btnDelete.Click += (s, e) =>
                    {
                        // Show confirmation dialog
                        DialogResult result = MessageBox.Show("Are you sure you want to delete your profile?", "Delete Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            // Delete user profile from database (SQL command below)
                            DeleteUserProfile(username);

                            // Redirect to signup form
                            Signup signupForm = new Signup();
                            signupForm.Show();
                            this.Hide();  // Hide current form
                        }
                    };

                    // Add buttons to TableLayoutPanel
                    tableLayoutPanelBooks.Controls.Add(btnEdit,1,2);
                    tableLayoutPanelBooks.Controls.Add(btnDelete,2,2);

                    Button btnPassword = new Button();
                    btnPassword.Text = "Password Change";
                    btnPassword.Font = new Font("Arial", 14, FontStyle.Bold);
                    btnPassword.BackColor = Color.LightGreen;
                    btnPassword.Size = new Size(200, 40);
                    //btnPassword.Margin = new Padding(0, 300, 0, 0);
                    //btnPassword.Location = new Point(100, 100);
                    btnPassword.Click += (s, e) =>
                    {
                        PasswordChanger passwordChanger = new PasswordChanger();
                        passwordChanger.Show();
                        this.Hide();
                    };

                    tableLayoutPanelBooks.Controls.Add(btnPassword, 3, 2);

                }
                reader.Close();
            }
        }

        private void UpdateUserDetails(string name, string username )
        {
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE [User] SET name = @name, username = @username WHERE userId = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@userId",loggedInUserId);  // Assume userID is known

                    command.ExecuteNonQuery();
                }
            }
        }

        private void DeleteUserProfile(string username)
        {
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=BookMang;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM [User] WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    command.ExecuteNonQuery();
                }
            }
        }



        private int GetLoggedInUserID()
        {
            return loggedInUserId; // Use the stored user ID
        }

        private void User_Click(object sender, EventArgs e)
        {
            ClearTableLayout(); // Clear any book data
            LoadUserDetails(); // Load user details
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.Show();
            this.Hide();
        }

        private void LoadBookData()
        {
            ClearTableLayout(); // Clear user data

            // Create header row
            AddHeaderRow();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT book_id, title, edition, author, ISBN, publisher, category, price FROM [Books]";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                int rowIndex = 1; // Start adding from the second row (first row is the header)
                while (reader.Read())
                {
                    // Add book details in each column for a new row
                    AddBookRow(reader, rowIndex);
                    rowIndex++; // Move to the next row for each book
                }

                reader.Close();
            }
        }

        private void AddHeaderRow()
        {
            tableLayoutPanelBooks.Controls.Clear(); // Clear previous controls
            tableLayoutPanelBooks.RowCount = 1; // Set row count for header
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Book ID", Font = new Font("Arial", 15, FontStyle.Bold), Margin = new Padding(0, 0, 0, 20), ForeColor = Color.OrangeRed }, 0, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Title", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 1, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Edition", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 2, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Author", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 3, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "ISBN", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 4, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Publisher", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 5, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Category", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 6, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Price", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 7, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Action", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 8, 0); // Action column for buttons
        }

        private void AddBookRow(SqlDataReader reader, int rowIndex)
        {
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["book_id"].ToString() }, 0, rowIndex);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["title"].ToString() }, 1, rowIndex);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["edition"].ToString() }, 2, rowIndex);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["author"].ToString() }, 3, rowIndex);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["ISBN"].ToString() }, 4, rowIndex);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["publisher"].ToString() }, 5, rowIndex);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["category"].ToString() }, 6, rowIndex);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["price"].ToString() }, 7, rowIndex);

            // Add "Add to Cart" button
            Button btnAddToCart = new Button
            {
                Text = "Add to Cart",
                Tag = new CartItem
                {
                    BookID = reader["book_id"].ToString(),
                    Title = reader["title"].ToString(),
                    Author = reader["author"].ToString(),
                    Edition = reader["edition"].ToString(),
                    Price = reader["price"].ToString()
                }, // Store book data in the button's tag
                AutoSize = true

            };
            btnAddToCart.Click += BtnAddToCart;
            tableLayoutPanelBooks.Controls.Add(btnAddToCart, 8, rowIndex);
        }


        private void BtnAddToCart(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CartItem item = (CartItem)btn.Tag;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Cart (UserID, BookID, Title, Author, Edition, Price) " +
                               "VALUES (@UserID, @BookID, @Title, @Author, @Edition, @Price)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", GetLoggedInUserID());
                cmd.Parameters.AddWithValue("@BookID", item.BookID);
                cmd.Parameters.AddWithValue("@Title", item.Title);
                cmd.Parameters.AddWithValue("@Author", item.Author);
                cmd.Parameters.AddWithValue("@Edition", item.Edition);
                cmd.Parameters.AddWithValue("@Price", item.Price);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Book added to cart successfully!");
            }
        }


        private void Books_Click(object sender, EventArgs e)
        {
            LoadBookData(); // Load book data when "Books" button is clicked
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            LoadCartData();
        }

      

        private void LoadCartData()
        {
            ClearTableLayout();

            // Create header row for the cart section
            tableLayoutPanelBooks.Controls.Clear();
            tableLayoutPanelBooks.RowCount = 1;
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "BookID", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 0, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Title", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 1, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Author", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 2, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Edition", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 3, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Price", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 4, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Action ", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 5, 0);


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT BookID,Title,Author,Edition,Price FROM Cart WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", GetLoggedInUserID());

                SqlDataReader reader = cmd.ExecuteReader();
                int rowIndex = 1;
                while (reader.Read())
                {
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["BookID"].ToString() },0,rowIndex);
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["Title"].ToString() }, 1, rowIndex);
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["Author"].ToString() }, 2, rowIndex);
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["Edition"].ToString() }, 3, rowIndex);
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["Price"].ToString() }, 4, rowIndex);

                    rowIndex++;
                    Button btnConfirmOrder = new Button
                    {
                        Text = "Confirm Order",
                        AutoSize = true
                    };

                    btnConfirmOrder.Click += BtnConfirmOrder_Click;
                    tableLayoutPanelBooks.Controls.Add(btnConfirmOrder, 5, 1);


                }
                reader.Close();
               
            }

           
        }


        private void BtnConfirmOrder_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch all items from the Cart for the logged-in user
                string fetchCartQuery = "SELECT BookID, Title, Author, Edition, Price FROM [Cart] WHERE UserID = @UserID";
                SqlCommand fetchCartCmd = new SqlCommand(fetchCartQuery, connection);
                fetchCartCmd.Parameters.AddWithValue("@UserID", GetLoggedInUserID());

                using (SqlDataReader reader = fetchCartCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Insert each cart item into the Orders table
                        string insertOrderQuery = "INSERT INTO [Orders] (UserID, BookID, Title, Author, Edition, Price) " +
                                                  "VALUES(@UserID, @BookID, @Title, @Author, @Edition, @Price)";
                        SqlCommand insertOrderCmd = new SqlCommand(insertOrderQuery, connection);
                        insertOrderCmd.Parameters.AddWithValue("@UserID", GetLoggedInUserID());
                        insertOrderCmd.Parameters.AddWithValue("@BookID", reader["BookID"]);
                        insertOrderCmd.Parameters.AddWithValue("@Title", reader["Title"]);
                        insertOrderCmd.Parameters.AddWithValue("@Author", reader["Author"]);
                        insertOrderCmd.Parameters.AddWithValue("@Edition", reader["Edition"]);
                        insertOrderCmd.Parameters.AddWithValue("@Price", reader["Price"]);

                        insertOrderCmd.ExecuteNonQuery();
                    }
                }

                // Clear the cart after order confirmation
                string deleteQuery = "DELETE FROM Cart WHERE UserID = @UserID";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                deleteCmd.Parameters.AddWithValue("@UserID", GetLoggedInUserID());
                deleteCmd.ExecuteNonQuery();

                MessageBox.Show("Order confirmed successfully!");
            }
        }


        private class CartItem
        {
            public string BookID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Edition { get; set; }
            public string Price { get; set; }
        }

        private void ClearTableLayout()
        {
            tableLayoutPanelBooks.Controls.Clear(); // Clear all controls from the TableLayoutPanel
            tableLayoutPanelBooks.RowCount = 0; // Reset row count
        }


        private void LoadConfirmedOrders()
        {
            ClearTableLayout();

            tableLayoutPanelBooks.Controls.Clear();
            tableLayoutPanelBooks.RowCount = 1;
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "OrderID", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed },0,0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "BookID",Font = new Font("Arial", 15, FontStyle.Bold),ForeColor = Color.OrangeRed },1,0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Title", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 2, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Author", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 3, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Edition", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 4, 0);
            tableLayoutPanelBooks.Controls.Add(new Label() { Text = "Price", Font = new Font("Arial", 15, FontStyle.Bold), ForeColor = Color.OrangeRed }, 5, 0);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT OrderID,BookID, Title, Author, Edition, Price  FROM [Orders] WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", GetLoggedInUserID());

                SqlDataReader reader = cmd.ExecuteReader();
                int rowIndex = 1;
                while (reader.Read())
                {
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["OrderID"].ToString() },0,rowIndex);
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["BookID"].ToString() }, 1, rowIndex );
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["Title"].ToString() }, 2, rowIndex);
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["Author"].ToString() }, 3, rowIndex);
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["Edition"].ToString() }, 4, rowIndex);
                    tableLayoutPanelBooks.Controls.Add(new Label() { Text = reader["Price"].ToString() }, 5, rowIndex);

                    rowIndex++;
                }
                reader.Close();
            }

            // Add Print button for exporting order details to PDF
            Button btnPrintOrderDetails = new Button
            {
                Text = "Print my order details",
                AutoSize = true
            };
            btnPrintOrderDetails.Click += BtnPrintOrderDetails_Click;
            tableLayoutPanelBooks.Controls.Add(btnPrintOrderDetails, 6,  2);
        }


        private void BtnPrintOrderDetails_Click(object sender, EventArgs e)
        {
            string filePath = "OrderDetails.pdf"; // Specify the path where the PDF will be saved

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                // Create a PDF writer
                PdfWriter writer = new PdfWriter(stream);
                // Create a PDF document
                PdfDocument pdf = new PdfDocument(writer);
                // Add a new page
                Document document = new Document(pdf);

                // Define font
                PdfFont font = PdfFontFactory.CreateFont("Helvetica-Bold");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT OrderID, Title, Author, Edition, Price FROM [Orders] WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserID", GetLoggedInUserID());

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Create order details string
                        string orderDetails = $"OrderID: {reader["OrderID"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Edition: {reader["Edition"]}, Price: {reader["Price"]}";
                        // Add it to the document
                        document.Add(new Paragraph(orderDetails).SetFont(font));
                    }
                    reader.Close();
                }

                // Close the document
                document.Close();
            }

            // Open the PDF after creation (optional)
            System.Diagnostics.Process.Start("explorer.exe", filePath);

        }




        private void Orders_Click(object sender, EventArgs e)
        {
            LoadConfirmedOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
        }
    }
}
