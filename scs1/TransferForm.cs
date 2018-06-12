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
    public partial class TransferForm : Form
    {
        private const string cons = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
        private Boolean flag;
        public string tfusername { get; set; }

        public TransferForm()
        {
            InitializeComponent();
            flag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if((string.IsNullOrWhiteSpace(accnoText.Text)) || (string.IsNullOrWhiteSpace(amountText.Text)) || flag)
            {
                MessageBox.Show("Please check the fields");
                return;
            }
            else
            {
                string text = "select balance from bank where accno=" + accnoText.Text.Trim();
                int amount = 0;
                int ownbalance = 0;
                int value = Convert.ToInt32(amountText.Text.Trim());

                if (value<0)
                {
                    MessageBox.Show("Amount cannot be negative!");
                    return;

                }
                if (value==0)
                {
                    MessageBox.Show("Amount cannot be zero!");
                    return;
                }
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = cons;

                OleDbCommand command2 = new OleDbCommand(text, connection);
                connection.Open();
                OleDbDataReader reader2 = command2.ExecuteReader();

                while (reader2.Read())
                    amount= Convert.ToInt32(reader2.GetValue(0));

                //MessageBox.Show(amount.ToString());
                

                string balancecheck = "select balance from bank where accno = (select accno from signup where username='" + tfusername + "')";
                OleDbCommand command3 = new OleDbCommand(balancecheck, connection);
                OleDbDataReader reader3 = command3.ExecuteReader();

                while (reader3.Read())
                    ownbalance = Convert.ToInt32(reader3.GetValue(0));

                if ((ownbalance-value) <0)
                {
                    MessageBox.Show("You have insufficient balance");
                    return;
                }
                else
                {
                    string deductbalance = "UPDATE bank set balance=balance - " + value + " where accno = (select accno from signup where username='" + tfusername + "')";
                    string increasebalance = "update bank set balance=balance + " + value + " where accno=" + accnoText.Text.Trim();

                    OleDbCommand dcommand = new OleDbCommand(deductbalance,connection);
                    dcommand.ExecuteNonQuery();

                    OleDbCommand icommand = new OleDbCommand(increasebalance, connection);
                    icommand.ExecuteNonQuery();

                    

                    //insert value into transaction table
                    string user = "select accno from signup where username='" + tfusername + "'";
                    int accnofromdb = 0;

                    OleDbConnection connection2 = new OleDbConnection();
                    connection2.ConnectionString = cons;
                    connection2.Open();
                    OleDbCommand commanduser = new OleDbCommand(user, connection2);

                    OleDbDataReader readeruser = commanduser.ExecuteReader();

                    while (readeruser.Read())
                    {
                        accnofromdb = Convert.ToInt32(readeruser.GetValue(0));
                    }


                    string time = DateTime.Now.ToString("h:mm:ss tt");
                    string date= DateTime.Today.ToString("dd-MM-yyyy");
                    string itransaction = "insert into transactiondetails(accfrom, accto, amount,cdate, ctime) values ("+ accnofromdb +","+ accnoText.Text.Trim() +","+ value+ ",'"+date+"','"+time+"')";
                    OleDbCommand comm = new OleDbCommand(itransaction, connection2);
                    comm.ExecuteNonQuery();

                    MessageBox.Show("Transfer successful");
                    accnoText.Text = "";
                    namelabelText.Text = "";
                    ifsclabelText.Text = "";
                    amountText.Text = "";

                    connection2.Close();
                    connection.Close();
                    

                }

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void filldetailsButton_Click(object sender, EventArgs e)
        {
            OleDbConnection connection= new OleDbConnection();
            connection.ConnectionString = cons;
            connection.Open();
            int accnofromdb = 0;
            string text = "select * from bank where accno=" + accnoText.Text.Trim();
            string user = "select accno from signup where username='" + tfusername + "'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(text, connection);

            OleDbCommand commanduser = new OleDbCommand(user, connection);

            OleDbDataReader readeruser = commanduser.ExecuteReader();

            while (readeruser.Read())
            {
                accnofromdb = Convert.ToInt32(readeruser.GetValue(0));
             }
            DataTable dtb1 = new DataTable();
            adapter.Fill(dtb1);

            if (dtb1.Rows.Count < 1)
            {
                MessageBox.Show("Account number does not exist");
                flag = true;
                return;
            }
            else if(accnofromdb==Convert.ToInt32(accnoText.Text.Trim()))
            {
                MessageBox.Show("Cannot input your own account number");
                flag = true;
                return;
            }
            else
            {
                flag = false;
                OleDbCommand command = new OleDbCommand(text, connection);

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    namelabelText.Text=(reader.GetString(3));
                    ifsclabelText.Text = reader.GetString(1);
                }
                
                reader.Close();

                

                connection.Close();

            }

        }
    }
}
