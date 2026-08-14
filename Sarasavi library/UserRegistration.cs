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
    public partial class UserRegistration : Form
    {
        public UserRegistration()
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
            txtUserNo.Clear();
            txtName.Clear();
            txtNIC.Clear();
            txtAddress.Clear();
            cmbSex.SelectedIndex = -1;
        }

        private void LoadUsers()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Users",
                DBConnection.con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBConnection.con.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Users VALUES(@UserNo,@Name,@Sex,@NIC,@Address)",
            DBConnection.con);

            cmd.Parameters.AddWithValue("@UserNo", txtUserNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Sex", cmbSex.Text);
            cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("User Saved Successfully");
            LoadUsers();
            clearAll();
            DBConnection.con.Close();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBConnection.con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserNo = @UserNo", DBConnection.con);
            cmd.Parameters.AddWithValue("@UserNo", txtUserNo.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("User Deleted Successfully");
            LoadUsers();
            clearAll();
            DBConnection.con.Close();
        }
    }
}