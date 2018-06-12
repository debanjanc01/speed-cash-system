using System;

using System.Data;

using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace scs1
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            
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

        private bool isValidUsername(string user)
        {
            Regex r=new Regex (@"^[a-zA-Z0-9]+$");
            return r.IsMatch(user);
        }





        private void submitButton_Click(object sender, EventArgs e)
        {
            
            if ((string.IsNullOrWhiteSpace(firstnameText.Text)) || (string.IsNullOrWhiteSpace(lastnameText.Text)) || (string.IsNullOrWhiteSpace(phnoText.Text))
                || (countryDropdown.SelectedIndex==-1) || (string.IsNullOrWhiteSpace(emailText.Text)) || (string.IsNullOrWhiteSpace(passwordText.Text)) || (string.IsNullOrWhiteSpace(accountText.Text)))
            {
                // Show message?
                MessageBox.Show("Please fill all the fields");

                return; // Don't process
            }

            else if (!(isValidPhno(phnoText.Text)))
            {
                MessageBox.Show("Please check phone number");
                return;
            }


            else if(!(IsValidEmail(emailText.Text)))
            {
                MessageBox.Show("Enter a valid email");
                return;
            }

            else if (!(isValidUsername(usernameText.Text.Trim())))
            {
                MessageBox.Show("Enter a valid username");
                return;
            }



            else
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
                
                string ad = "no";
                if (adminradio.Checked)
                    ad = "yes";

                string add = "Insert into signup values (" + accountText.Text + ",'" + usernameText.Text + "','" + firstnameText.Text + "','" + lastnameText.Text + "','" + phnoText.Text + "','" + countryDropdown.SelectedItem.ToString() + "','" + emailText.Text + "','" + passwordText.Text + "','"+ad+"')";




                string check = "select * from signup where phno='" + phnoText.Text + "';";
                OleDbDataAdapter adapter = new OleDbDataAdapter(check,connection);
                OleDbDataAdapter ad2 = new OleDbDataAdapter("select * from signup where username='" + usernameText.Text + "';", connection);
                DataTable dtb2 = new DataTable();
                ad2.Fill(dtb2);
              
                DataTable dtb1 = new DataTable();
                adapter.Fill(dtb1);

                OleDbDataAdapter ad3 = new OleDbDataAdapter("select * from bank where accno =" + accountText.Text,connection);
                DataTable dt3 = new DataTable();
                ad3.Fill(dt3);

                OleDbDataAdapter ad4 = new OleDbDataAdapter("select * from signup where accno=" + accountText.Text, connection);
                DataTable dt4 = new DataTable();
                ad4.Fill(dt4);

                if(dt3.Rows.Count<1)
                {
                    MessageBox.Show("Please enter valid account number");
                    return;
                }
                else if(dt4.Rows.Count>=1)
                {
                    MessageBox.Show("Account already exists with given account number!");
                    return;
                }


               else  if (dtb1.Rows.Count == 1)
                {
                MessageBox.Show("Phone number already in use");
                return;
                }
                else if(dtb2.Rows.Count>=1)
                {
                    MessageBox.Show("Username already in use");
                    return;
                }
                
                else

                {


                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = add;
                    int i=command.ExecuteNonQuery();
                    if(i>=1)
                        MessageBox.Show("Account Creation Successful!");



                    connection.Close();

                    usernameText.Text = "";
                    firstnameText.Text = "";
                    lastnameText.Text = "";
                    phnoText.Text = "";
                    countryDropdown.SelectedIndex = -1;
                    emailText.Text = "";
                    passwordText.Text = "";
                    accountText.Text = "";
                    adminradio.Checked=false;



                }
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
           
            this.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
