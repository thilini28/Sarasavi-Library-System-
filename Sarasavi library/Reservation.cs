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
    public partial class Reservation : Form
    {
        public Reservation()
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

        private void btnReserve_Click(object sender, EventArgs e)
        {
            DBConnection.con.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Reservations(UserNo,BookNo,ReservationDate) VALUES(@UserNo,@BookNo,@ReservationDate)",
            DBConnection.con);

            cmd.Parameters.AddWithValue("@UserNo", txtUserNo.Text);
            cmd.Parameters.AddWithValue("@BookNo", txtBookNo.Text);
            cmd.Parameters.AddWithValue("@ReservationDate", dtReservation.Value);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Book Reserved Successfully");

            DBConnection.con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReservationID.Clear();
            txtUserNo.Clear();
            txtBookNo.Clear();

            dtReservation.Value = DateTime.Now;

            txtReservationID.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(
             "SELECT * FROM Reservations WHERE UserNo='" + txtUserNo.Text + "'",
              DBConnection.con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
