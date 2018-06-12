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
    public partial class TransactionDetailsForm : Form
    {


        public string tdaccno;
        private Label[] label1 = new Label[5];
        private Label[] label2 = new Label[5];
        private Label[] label3 = new Label[5];
        private Label[] label4 = new Label[5];
        private Label[] labelname = new Label[5];

        private PictureBox[] pb = new PictureBox[5];
        

        public TransactionDetailsForm()
        {
            InitializeComponent();

        }

        public TransactionDetailsForm(string acc)
        {
            InitializeComponent();
            this.tdaccno = acc;

            label1[0] = this.rs1;
            label1[1] = this.rs2;
            label1[2] = this.rs3;
            label1[3] = this.rs4;
            label1[4] = this.rs5;

            label2[0] = this.a1;
            label2[1] = this.a2;
            label2[2] = this.a3;
            label2[3] = this.a4;
            label2[4] = this.a5;

            label3[0] = this.d1;
            label3[1] = this.d2;
            label3[2] = this.d3;
            label3[3] = this.d4;
            label3[4] = this.d5;

            label4[0] = this.t1;
            label4[1] = this.t2;
            label4[2] = this.t3;
            label4[3] = this.t4;
            label4[4] = this.t5;

            pb[0] = this.pictureBox1;
            pb[1] = this.pictureBox2;
            pb[2] = this.pictureBox3;
            pb[3] = this.pictureBox4;
            pb[4] = this.pictureBox5;

            labelname[0] = this.an1;
            labelname[1] = this.an2;
            labelname[2] = this.an3;
            labelname[3] = this.an4;
            labelname[4] = this.an5;

            label6.Text = tdaccno;
            
            

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\DesignLab\Final Project\database new\databasenew.accdb";
            connection.Open();

            string text = "select top 5 * from transactiondetails where accfrom = " + tdaccno + " or accto=" + tdaccno + " order by ID desc";
            OleDbCommand command = new OleDbCommand(text, connection);

            OleDbDataReader reader = command.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                int accfrom = Convert.ToInt32(reader.GetValue(1));
                int accto = Convert.ToInt32(reader.GetValue(2));
                int amt = Convert.ToInt32(reader.GetValue(3));
                string cdate = reader.GetString(4);
                string ctime = reader.GetString(5);
                string accname = "";
                
                

                if (accfrom==Convert.ToInt32(tdaccno))
                {
                    label1[i].Text = accto.ToString();
                    pb[i].Image = Image.FromFile(@"F:\DesignLab\Final Project\images\red arrow.png");

                    string ntext = "select accname from bank where accno=" + accto.ToString();
                    OleDbCommand commandname = new OleDbCommand(ntext, connection);
                    OleDbDataReader rd = commandname.ExecuteReader();
                    while (rd.Read())
                        accname = rd.GetString(0);

                }
                else
                {
                    label1[i].Text = accfrom.ToString();
                    pb[i].Image = Image.FromFile(@"F:\DesignLab\Final Project\images\green left.jpg");

                    string ntext = "select accname from bank where accno=" + accfrom.ToString();
                    OleDbCommand commandname = new OleDbCommand(ntext, connection);
                    OleDbDataReader rd = commandname.ExecuteReader();
                    while (rd.Read())
                        accname = rd.GetString(0);
                }

                label2[i].Text = "₹ "+amt.ToString();
                label3[i].Text = cdate;
                label4[i].Text = ctime;
                labelname[i].Text = accname;

                i = i + 1;
            }







        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
