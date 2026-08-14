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
    public partial class Return : Form
    {
        public Return()
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
            txtLoanID.Clear();
            txtBookNo.Clear();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DBConnection.con.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Returns(LoanID,BookNo,ReturnDate) VALUES(@LoanID,@BookNo,@ReturnDate)",
            DBConnection.con);

            cmd.Parameters.AddWithValue("@LoanID", txtLoanID.Text);
            cmd.Parameters.AddWithValue("@BookNo", txtBookNo.Text);
            cmd.Parameters.AddWithValue("@ReturnDate", dtReturn.Value);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Book Returned");
            clearAll();
            DBConnection.con.Close();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
