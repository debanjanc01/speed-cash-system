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
using System.Text.RegularExpressions;

namespace scs1
{
    public partial class UpdateForm : Form
    {
        public string upfuname { get; set; }

        private Boolean flag;
        
        public UpdateForm()
        {
            InitializeComponent();
        }

        public UpdateForm(string a)
        {
            InitializeComponent();
            
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
                adminbox.Enabled = false;
                adminbox.Visible = false;
                adminlabel.Enabled = false;
                adminlabel.Visible = false;
            }
        }

        /*to check validity of email id*/
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /*to check validity of phone number*/
        private bool isValidPhno(string phno)
        {
            Regex r = new Regex(@"^\d{10}$");

            return r.IsMatch(phno);


        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            

            if ((flag) && (!string.IsNullOrWhiteSpace(usernametext.Text)))
            {
                upfuname = usernametext.Text.Trim();
               
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
                string check = "select * from signup where username='" + upfuname + "';";
                OleDbDataAdapter adapter = new OleDbDataAdapter(check, connection);



                DataTable dtb1 = new DataTable();
                adapter.Fill(dtb1);
                if (dtb1.Rows.Count < 1)
                {
                    MessageBox.Show("Given Username Does Not Exist!");
                    return;
                }



                
            }
            
            if ((string.IsNullOrWhiteSpace(firstnameText.Text)) || (string.IsNullOrWhiteSpace(lastnameText.Text)) || (string.IsNullOrWhiteSpace(phnotext.Text))
                || (countrydropdown.SelectedIndex == -1) || (string.IsNullOrWhiteSpace(emailtext.Text)))
            {
                // Show message?
                MessageBox.Show("Please fill all the fields");

                return; // Don't process
            }

            else if (!(isValidPhno(phnotext.Text)))
            {
                MessageBox.Show("Please check phone number");
                return;
            }


            else if (!(IsValidEmail(emailtext.Text)))
            {
                MessageBox.Show("Enter a valid email");
                return;
            }



            else
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
                string check = "select * from signup where phno='" + phnotext.Text + "' and username not like '" + upfuname+ "';";
                OleDbDataAdapter adapter = new OleDbDataAdapter(check, connection);
                
               

                DataTable dtb1 = new DataTable();
                adapter.Fill(dtb1);
                if (dtb1.Rows.Count == 1)
                {
                    MessageBox.Show("Phone number already in use");
                    return;
                }
                

                else

                {
                    string rights = "";
                    if ((flag) && (adminbox.SelectedIndex >= 0))
                    {
                       
                        rights = adminbox.SelectedItem.ToString();
                        
                    }

                    string query = "update signup set firstname='" + firstnameText.Text.Trim() + "', lastname='" + lastnameText.Text.Trim() + "', phno='" + phnotext.Text.Trim() + "', country='" + countrydropdown.SelectedItem + "', email='" + emailtext.Text.Trim() + "',adminr='"+rights+"' where username='" + upfuname + "'";

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    


                    


                    MessageBox.Show("Update complete");
                    usernametext.Text = "";
                    firstnameText.Text = "";
                    lastnameText.Text = "";
                    phnotext.Text = "";
                    countrydropdown.SelectedIndex = -1;
                    emailtext.Text = "";
                    adminbox.SelectedIndex = -1;


                   

                    connection.Close();


                }
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
