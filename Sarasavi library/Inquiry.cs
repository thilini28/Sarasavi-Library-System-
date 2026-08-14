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
    public partial class Inquiry : Form
    {
        public Inquiry()
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
        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Books WHERE BookNo='" + txtBookNo.Text + "'",
                DBConnection.con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnSearchTitle_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Books WHERE Title LIKE '%" + txtTitle.Text + "%'",
                DBConnection.con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Books WHERE Author LIKE '%" + txtAuthor.Text + "%'",
                DBConnection.con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookNo.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();

            dataGridView1.DataSource = null;

            txtBookNo.Focus();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }    
    }
}
