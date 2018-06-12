using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace scs1
{
    public partial class CheckBalanceForm : Form
    {

        public string cbusername { get; set; }

        public CheckBalanceForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RequestBalanceButton_Click(object sender, EventArgs e)
        {
            balancelabeltext.Visible = true;
            string balancecheck = "select balance from bank where accno = (select accno from signup where username='" + cbusername + "')";
            int ownbalance = 0;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
            connection.Open();
            OleDbCommand command3 = new OleDbCommand(balancecheck, connection);
            OleDbDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
                ownbalance = Convert.ToInt32(reader3.GetValue(0));

            balancelabeltext.Text = "₹ "+ownbalance.ToString();

            connection.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
