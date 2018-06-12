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
    public partial class AccountDecactivateForm : Form


    {

        private string username;
        private Boolean flag;

        public AccountDecactivateForm()
        {
            InitializeComponent();
        }

        public AccountDecactivateForm(string u, string a)
        {

            InitializeComponent();
            username = u;
            if (a.Equals("yes"))
            {
                flag = true;

            }
            else
            {
                flag = false;
                usernamelabel.Enabled = false;
                usernamelabel.Visible = false;
                usernametext.Enabled = false;
                usernametext.Visible = false;
            }

           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AccountDecactivateForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag && (!string.IsNullOrWhiteSpace(usernametext.Text)))
            {

               

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";


                string query = "select * from signup where username='" + usernametext.Text + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("Username does not exist");
                    return;
                }
                else
                    username = usernametext.Text;



            }


            if (string.IsNullOrWhiteSpace(passtext.Text) || string.IsNullOrWhiteSpace(repasstext.Text))
            {
                MessageBox.Show("Both fields need to be filled");
                return;
            }

            else
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";


                string query = "select * from signup where password='" + passtext.Text + "' and username='" + username + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("Please check password");
                    return;

                }
                else if (!passtext.Text.Trim().Equals(repasstext.Text.Trim()))
                {
                    MessageBox.Show("Password fields do not match");
                    return;
                }
                else if(!checkBox1.Checked)
                {
                    MessageBox.Show("Please make sure you want to proceed");
                    return;

                }
                else
                {
                    connection.Open();
                    string text = "delete from signup where [username]='" + username + "'";
                    OleDbCommand command = new OleDbCommand(text, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Login lf = new Login(true);
                    lf.Show();
                    this.Close();
                    MessageBox.Show("Account Deleted!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
