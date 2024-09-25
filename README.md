Book Management System 📚
Welcome to the Book Management System! This project is developed using .NET and is designed to streamline book management, user interaction, and order handling with comprehensive admin controls. Below is a detailed description of the system's functionality and features.

Features and Functionality
1. User Signup and Authentication
User Signup: Users can register by filling out their details such as name, email, and password.
Login: After registration, users can log in using their email and password to access their account and interact with the system.
2. View User Details
Once logged in, users can view their personal profile, including name, email, and any associated orders.
This section helps users keep track of their account information and allows the system to provide personalized services.
3. Book Details Display
Users can browse a list of available books.
Each book has detailed information including:
Title
Author
Genre
Price
Description
Availability status
4. Order Management
Add Books to Cart: Users can add books to their cart, preparing them for purchase.
Confirm Order: Once the user is ready to complete the purchase, they confirm the order. At this point:
The system generates a PDF invoice containing:
User details (name, email)
List of books ordered (title, author, price)
Total cost of the order
Order confirmation number
Date and time of order
PDF Download: The user can download the PDF for their records. This serves as an official receipt of the transaction.
5. Admin Functionality
The admin has full control over managing users and books in the system. The admin panel allows for the following actions:

Add Book:

The admin can add new books to the system by filling out the details such as title, author, genre, price, and description.
Once added, the book will be available for users to view and order.
Edit Book Details:

The admin can modify the details of any existing book in the system, including updating the title, price, availability, etc.
This ensures that the system stays up-to-date with the latest information about the books.
Delete Book:

If a book is no longer available, the admin can remove it from the system, ensuring that only active books are shown to users.
User Management:

The admin can view all registered users and their order histories.
Admins can edit user details if necessary or delete users who are no longer active.
6. Responsive Design
The system is designed with a responsive layout to provide an optimal viewing experience across various devices (desktop, tablet, mobile).
Users and admins can easily navigate the system on any device.
7. Security
Password Encryption: User passwords are stored securely using encryption to ensure data privacy.
Access Control: The system differentiates between regular users and admins, ensuring that only authorized personnel can perform admin-specific actions.
Technology Stack
Backend: .NET 
Frontend: Razor Pages / Blazor (or another front-end technology you used)
Database: SQL Server (or another DB used)
PDF Generation: PDF generation functionality is used to create invoices for user orders.
