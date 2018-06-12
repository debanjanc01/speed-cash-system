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
using System.Data.OleDb;

namespace scs1
{
    public partial class Login : Form
    {
        private Boolean flag;
        public Login()
        {
            InitializeComponent();
        }

        public Login(Boolean f)
        {

            InitializeComponent();
            flag = f;
            if (flag)
            {
                loginButton.Location = new Point(328, 444);
                signupButton.Enabled = false;
                signupButton.Visible = false;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(usernameText.Text)) || (string.IsNullOrWhiteSpace(passwordText.Text)))
            {
                MessageBox.Show("Username/Password cannot be blank");
                return;
            }

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
            connection.Open();

            string query = "select * from signup where username='" + usernameText.Text.Trim() + "' and password='" + passwordText.Text.Trim() + "'";
            OleDbDataAdapter sda = new OleDbDataAdapter(query, connection);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if(dtb1.Rows.Count==1)
            {

               

                //select accno from username 

                string user = "select accno,adminr from signup where username='" + usernameText.Text.Trim() + "'";
                int accnofromdb = 0;
                string admin="";
                OleDbCommand commanduser = new OleDbCommand(user, connection);

                OleDbDataReader readeruser = commanduser.ExecuteReader();
                while (readeruser.Read())
                {
                    accnofromdb = Convert.ToInt32(readeruser.GetValue(0));
                    admin = readeruser.GetString(1);
                }
               

                connection.Close();

                Main objmain = new Main(usernameText.Text.Trim(),accnofromdb.ToString(),admin);
                

                
                objmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username/Password incorrect");
            }
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            //SignUpForm sf = new SignUpForm();
            //sf.Show();
            //this.Hide();
        }
    }
}
