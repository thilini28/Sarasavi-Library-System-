# 📚 Sarasavi Library Management System

A desktop-based **Library Management System** developed using **C# Windows Forms** and **Microsoft SQL Server**. The system is designed to simplify and manage common library operations such as book registration, user management, book loans, returns, reservations, and book inquiries through a user-friendly graphical interface.

## ✨ Features

* 🔐 **Admin Login**

  * Secure login interface for system access
  * Administrator authentication

* 📊 **Dashboard**

  * Displays total number of books
  * Displays total registered users
  * Displays available books
  * Displays currently loaned books
  * Provides quick access to major library management functions

* 📖 **Book Registration**

  * Add new books
  * Store book number, title, author, publisher, and copy number
  * Classify books as Reference or Borrowable
  * View registered books
  * Delete book records

* 👤 **User Registration**

  * Register library users
  * Store user number, name, gender, NIC, and address
  * View registered users
  * Delete user records

* 📕 **Book Loan Management**

  * Record book loans
  * Store user and book details
  * Record loan and expected return dates

* 🔄 **Book Return Management**

  * Record returned books
  * Store loan ID, book number, and return date

* 📅 **Book Reservation**

  * Reserve books for registered users
  * Store reservation date
  * Search reservation records by user

* 🔎 **Book Inquiry**

  * Search books by book number
  * Search books by title
  * Search books by author

## 🛠️ Technologies Used

| Technology               | Purpose                  |
| ------------------------ | ------------------------ |
| **C#**                   | Application development  |
| **Windows Forms**        | Graphical User Interface |
| **.NET Framework 4.7.2** | Application framework    |
| **Microsoft SQL Server** | Database management      |
| **ADO.NET / SqlClient**  | Database connectivity    |
| **Visual Studio**        | Development environment  |

## 🗂️ Project Structure

```text
Sarasavi Library System/
│
├── Sarasavi library/
│   ├── BookRegistration.cs
│   ├── Dashboard.cs
│   ├── Inquiry.cs
│   ├── Loan.cs
│   ├── Login.cs
│   ├── Reservation.cs
│   ├── Return.cs
│   ├── UserRegistration.cs
│   │
│   ├── BookRegistration.Designer.cs
│   ├── Dashboard.Designer.cs
│   ├── Inquiry.Designer.cs
│   ├── Loan.Designer.cs
│   ├── Login.Designer.cs
│   ├── Reservation.Designer.cs
│   ├── Return.Designer.cs
│   ├── UserRegistration.Designer.cs
│   │
│   ├── Program.cs
│   ├── App.config
│   └── Sarasavi library.sln
│
├── images/
│
└── SQLQuery1.sql
```

## 🗄️ Database

The application uses a SQL Server database named:

```text
LibraryDB
```

The database contains tables for managing:

* Users
* Books
* Loans
* Returns
* Reservations

The SQL script included in the project can be used to create the required database structure.

### Database Connection

The application is configured to connect to a local SQL Server Express instance:

```text
Data Source=localhost\SQLEXPRESS
Initial Catalog=LibraryDB
Integrated Security=True
```

> **Note:** Update the connection string if your SQL Server instance uses a different server name or authentication method.

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/sarasavi-library-system.git
```

### 2. Open the Project

Open the solution file:

```text
Sarasavi library.sln
```

using **Visual Studio**.

### 3. Configure SQL Server

Make sure **Microsoft SQL Server / SQL Server Express** is installed and running.

Create the database:

```sql
CREATE DATABASE LibraryDB;
```

Then select the `LibraryDB` database and execute:

```text
SQLQuery1.sql
```

### 4. Configure the Connection

If necessary, update the SQL Server connection string:

```csharp
@"Data Source=localhost\SQLEXPRESS;
  Initial Catalog=LibraryDB;
  Integrated Security=True"
```

### 5. Build and Run

Open the project in Visual Studio and select:

```text
Build → Build Solution
```

Then run the application using:

```text
F5
```

## 🔑 Login

The current application uses the following administrator credentials:

```text
Username: admin
Password: 1234
```

## 📌 Purpose

This project was developed as a practical desktop application to demonstrate the use of **C#, Windows Forms, and Microsoft SQL Server** for managing library operations.

It provides hands-on experience with:

* C# programming
* Windows Forms application development
* SQL Server database management
* ADO.NET database connectivity
* CRUD operations
* Database-driven desktop applications
* User interface design
* Library record management

## 👩‍💻 Author

**Thilini**

Developed using **C#, Windows Forms, .NET Framework, and Microsoft SQL Server**.

---

⭐ If you find this project useful, consider giving the repository a **star**.
