using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sarasavi_library
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        class DBConnection
        {
            public static SqlConnection con =
                new SqlConnection(
                    @"Data Source = localhost\SQLEXPRESS; Initial Catalog = LibraryDB; 
                    Integrated Security = True");
        }
        private void btnBooks_Click(object sender, EventArgs e)
        {
            BookRegistration b = new BookRegistration();
            b.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserRegistration b = new UserRegistration();
            b.Show();
            this.Hide();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            Loan b = new Loan();
            b.Show();
            this.Hide();
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            Return b = new Return();
            b.Show();
            this.Hide();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            Reservation b = new Reservation();
            b.Show();
            this.Hide();
        }

        private void btnInquiry_Click(object sender, EventArgs e)
        {
            Inquiry b = new Inquiry();
            b.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LoadCounts()
        {
            DBConnection.con.Open();

            // Total Books
            SqlCommand cmdBooks = new SqlCommand(
                "SELECT COUNT(*) FROM Books",
                DBConnection.con);

            int totalBooks = Convert.ToInt32(cmdBooks.ExecuteScalar());

            // Total Users
            SqlCommand cmdUsers = new SqlCommand(
                "SELECT COUNT(*) FROM Users",
                DBConnection.con);

            int totalUsers = Convert.ToInt32(cmdUsers.ExecuteScalar());

            // Loan Books
            SqlCommand cmdLoans = new SqlCommand(
                "SELECT COUNT(*) FROM Loans",
                DBConnection.con);

            int loanBooks = Convert.ToInt32(cmdLoans.ExecuteScalar());

            // Available Books
            int availableBooks = totalBooks - loanBooks;

            // Show on Dashboard
            lblTotalBooks.Text = totalBooks.ToString();
            lblTotalUsers.Text = totalUsers.ToString();
            lblAvailableBooks.Text = availableBooks.ToString();
            lblLoanBooks.Text = loanBooks.ToString();

            DBConnection.con.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadCounts();
        }   
    }
}
