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
    public partial class BookRegistration : Form
    {
        public BookRegistration()
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
        private void clearAll()
        {
            txtBookNo.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtCopyNo.Clear();

            rbReference.Checked = false;
            rbBorrowable.Checked = false;
        }
        private void LoadBooks()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Books",
                DBConnection.con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            string classification = "";

            if (rbReference.Checked)
            {
                classification = "Reference";
            }

            if (rbBorrowable.Checked)
            {
                classification = "Borrowable";
            }

            DBConnection.con.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Books VALUES(@BookNo,@Title,@Author,@Publisher,@CopyNo,@Classification)",
            DBConnection.con);

            cmd.Parameters.AddWithValue("@BookNo", txtBookNo.Text);
            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
            cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
            cmd.Parameters.AddWithValue("@CopyNo", txtCopyNo.Text);
            cmd.Parameters.AddWithValue("@Classification", classification);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Book Saved Successfully");
            clearAll();
            DBConnection.con.Close();
            LoadBooks();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void BookRegistration_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBConnection.con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE BookNo = @BookNo", DBConnection.con);
            cmd.Parameters.AddWithValue("@BookNo", txtBookNo.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Book Deleted Successfully");
            clearAll();
            DBConnection.con.Close();
            LoadBooks();
        }
    }
}
