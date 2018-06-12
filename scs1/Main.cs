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
    public partial class Main : Form
    {

        public string username;
        public string accno;
        private string admin;

        private Boolean flag;
        public Main()
        {
            InitializeComponent();
            
        }
        public Main(string user, string acc, string a)
        {
            InitializeComponent();
            this.username = user;
            this.accno = acc;
            this.admin = a;

            //disable or enable options based on admin rights

            if (!admin.Equals("yes"))
            {
                otherusermenu.Visible = false;
                otherusermenu.Enabled = false;
                addusermenu.Enabled = false;
                addusermenu.Visible = false;
               
            }


            ///////////////////////////////
            flag = true;
            menuStrip1.Size = new Size(977, 0);
            pictureBox1.Location = new Point(455, 23);
            pictureBox1.Image = Image.FromFile(@"F:\DesignLab\Final Project\images\imageedit_5_6548876356.png");

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
            string ntext = "select firstname, lastname from signup where username='" + username+"'";
            connection.Open();
            OleDbCommand commandname = new OleDbCommand(ntext, connection);
            OleDbDataReader rd = commandname.ExecuteReader();

            string fname = "";
            string lname = "";

            while (rd.Read())
            {

                fname = rd.GetString(0);
                lname = rd.GetString(1);

            }

            welcomelabel.Text = "Welcome " + fname + " "+lname+"!";

            connection.Close();
        }

    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void updateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateForm up = new UpdateForm(admin);
            up.upfuname = username;
            up.Show();
            
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBalanceForm ch = new CheckBalanceForm();
            ch.cbusername = username;
            ch.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepositForm dp = new DepositForm();
            
            dp.Show();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferForm tf = new TransferForm();
            tf.tfusername = username;
       
            tf.Show();
        }

        private void transactionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionDetailsForm td = new TransactionDetailsForm(accno);
            

           
            
           td.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cf = new ChangePasswordForm(username,admin);
            
            cf.Show();
        }

        private void deactivateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountDecactivateForm ad = new AccountDecactivateForm(username,admin);
            
            ad.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login l = new Login(true);
            l.Show();
            this.Close();
            MessageBox.Show("Logout Successful");
           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            flag = !flag;
            if(flag)
            {
                menuStrip1.Size = new Size(977, 10);
                pictureBox1.Location = new Point(455, 23);
                pictureBox1.Image = Image.FromFile(@"F:\DesignLab\Final Project\images\imageedit_5_6548876356.png");
            }
            else
            {
                menuStrip1.Size = new Size(977, 130);
                pictureBox1.Location = new Point(455, 110);
                pictureBox1.Image = Image.FromFile(@"F:\DesignLab\Final Project\images\imageedit_7_5994521692.png");
            }
        }

        private void addusermenu_Click(object sender, EventArgs e)
        {
            SignUpForm sf = new SignUpForm();
            sf.Show();
            //this.Hide();
        }

        private void adminRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminRights ar = new adminRights();
            ar.Show();

        }

        private void otherusermenu_Click(object sender, EventArgs e)
        {
            otheruserform otf = new otheruserform();
            otf.Show();
        }
    }
}
