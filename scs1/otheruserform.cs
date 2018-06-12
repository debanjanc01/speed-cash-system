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
    public partial class otheruserform : Form
    {
        public otheruserform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(username.Text))
            {
                MessageBox.Show("Username cannot be empty");
            }
            else
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";

                OleDbDataAdapter ad2 = new OleDbDataAdapter("select * from signup where username='" + username.Text.Trim() + "';", connection);
                DataTable dtb2 = new DataTable();
                ad2.Fill(dtb2);

               
                if(dtb2.Rows.Count<=0)
                {
                    MessageBox.Show("Username does not exist!");
                    return;
                }

                else
                {
                    int accno=0;
                    string text = "select accno from signup where [username]='" + username.Text.Trim()+"'";
                    connection.Open();

                    OleDbCommand command = new OleDbCommand(text, connection);

                    OleDbDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        accno = Convert.ToInt32(reader.GetValue(0));
                    }
                    connection.Close();
                    TransactionDetailsForm tdf = new TransactionDetailsForm(accno.ToString());
                    tdf.Show();
                    this.Close();
                }
            }
        }
    }
}
