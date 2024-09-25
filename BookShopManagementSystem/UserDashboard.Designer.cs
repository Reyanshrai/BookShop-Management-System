namespace BookShopManagementSystem
{
    partial class UserDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.Orders = new System.Windows.Forms.Button();
            this.Cart = new System.Windows.Forms.Button();
            this.Books = new System.Windows.Forms.Button();
            this.User = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanelBooks = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.Transparent;
            this.leftPanel.Controls.Add(this.label2);
            this.leftPanel.Controls.Add(this.Logout);
            this.leftPanel.Controls.Add(this.Orders);
            this.leftPanel.Controls.Add(this.Cart);
            this.leftPanel.Controls.Add(this.Books);
            this.leftPanel.Controls.Add(this.User);
            this.leftPanel.Controls.Add(this.pictureBox2);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Controls.Add(this.pictureBox1);
            this.leftPanel.Location = new System.Drawing.Point(1, 1);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(318, 842);
            this.leftPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(28, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 26);
            this.label2.TabIndex = 9;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Logout
            // 
            this.Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout.ForeColor = System.Drawing.Color.OrangeRed;
            this.Logout.Location = new System.Drawing.Point(48, 731);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(185, 62);
            this.Logout.TabIndex = 8;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Orders
            // 
            this.Orders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Orders.ForeColor = System.Drawing.Color.OrangeRed;
            this.Orders.Location = new System.Drawing.Point(48, 636);
            this.Orders.Name = "Orders";
            this.Orders.Size = new System.Drawing.Size(185, 62);
            this.Orders.TabIndex = 7;
            this.Orders.Text = "Orders";
            this.Orders.UseVisualStyleBackColor = true;
            this.Orders.Click += new System.EventHandler(this.Orders_Click);
            // 
            // Cart
            // 
            this.Cart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cart.ForeColor = System.Drawing.Color.OrangeRed;
            this.Cart.Location = new System.Drawing.Point(48, 535);
            this.Cart.Name = "Cart";
            this.Cart.Size = new System.Drawing.Size(185, 62);
            this.Cart.TabIndex = 6;
            this.Cart.Text = "Cart";
            this.Cart.UseVisualStyleBackColor = true;
            this.Cart.Click += new System.EventHandler(this.BtnAddToCart_Click);
            // 
            // Books
            // 
            this.Books.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Books.ForeColor = System.Drawing.Color.OrangeRed;
            this.Books.Location = new System.Drawing.Point(48, 438);
            this.Books.Name = "Books";
            this.Books.Size = new System.Drawing.Size(185, 62);
            this.Books.TabIndex = 5;
            this.Books.Text = "Books";
            this.Books.UseVisualStyleBackColor = true;
            this.Books.Click += new System.EventHandler(this.Books_Click);
            // 
            // User
            // 
            this.User.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.ForeColor = System.Drawing.Color.OrangeRed;
            this.User.Location = new System.Drawing.Point(48, 337);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(185, 62);
            this.User.TabIndex = 4;
            this.User.Text = "User Details";
            this.User.UseVisualStyleBackColor = true;
            this.User.Click += new System.EventHandler(this.User_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BookShopManagementSystem.Properties.Resources.user__1_;
            this.pictureBox2.Location = new System.Drawing.Point(78, 192);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(27, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Dashboard";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BookShopManagementSystem.Properties.Resources.Your_paragraph_text;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rightPanel
            // 
            this.rightPanel.AutoSize = true;
            this.rightPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightPanel.Controls.Add(this.tableLayoutPanelBooks);
            this.rightPanel.Location = new System.Drawing.Point(319, 1);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(1471, 852);
            this.rightPanel.TabIndex = 1;
            // 
            // tableLayoutPanelBooks
            // 
            this.tableLayoutPanelBooks.AutoSize = true;
            this.tableLayoutPanelBooks.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanelBooks.ColumnCount = 9;
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBooks.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tableLayoutPanelBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelBooks.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanelBooks.Location = new System.Drawing.Point(0, 144);
            this.tableLayoutPanelBooks.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanelBooks.Name = "tableLayoutPanelBooks";
            this.tableLayoutPanelBooks.RowCount = 10;
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBooks.Size = new System.Drawing.Size(909, 698);
            this.tableLayoutPanelBooks.TabIndex = 0;
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::BookShopManagementSystem.Properties.Resources.f0af4840c5704569b1bd7daeeb2589a9_jpg_srz_980_651_85_22_0_50_1_20_0_00_jpg_srz;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1787, 844);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Name = "UserDashboard";
            this.Text = "UserDashboard";
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button User;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Books;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button Orders;
        private System.Windows.Forms.Button Cart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBooks;
    }
}