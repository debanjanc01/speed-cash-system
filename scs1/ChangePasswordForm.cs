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
    public partial class ChangePasswordForm : Form
    {

        private string admin;
        private string username;
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        public ChangePasswordForm(string u,string a)
        {
            InitializeComponent();
            this.admin = a;
            this.username = u;

            if(!a.Equals("yes"))
            {
                usernamelabel.Enabled = false;
                usernamelabel.Visible = false;
                usernametext.Enabled = false;
                usernametext.Visible = false;

            }
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(admin.Equals("yes") && (!string.IsNullOrWhiteSpace(usernametext.Text)))
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

            if(string.IsNullOrWhiteSpace(oldpasswordtext.Text) || string.IsNullOrWhiteSpace(newpasswordtext.Text) || string.IsNullOrWhiteSpace(renewpasstext.Text))
            {
                MessageBox.Show("Please fill in all the fields");
                return;
            }
            else
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";

                string query = "select * from signup where username='" + username + "' and password='"+oldpasswordtext.Text+"'";
                
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                connection.Close();

                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("Please check old password");
                    return;
                }
                else
                {
                    if(!newpasswordtext.Text.Trim().Equals(renewpasstext.Text.Trim()))
                    {
                        MessageBox.Show("Password fields do not match");
                        return;

                    }
                    else
                    {
                        OleDbConnection conn = new OleDbConnection();
                        conn.ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
                        conn.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.CommandText = "update signup set [password]='" + newpasswordtext.Text.Trim() + "' where username='" + username + "'";
                        //command.CommandText = "update signup set [password]='123' where username='akashr'";
                        command.Connection = conn; ;
                        
                        command.ExecuteNonQuery();
                        MessageBox.Show("Password changed successfully!");

                        
                        
                    }
                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
