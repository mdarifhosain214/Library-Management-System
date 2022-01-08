using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class Issuebook : Form
    {
        public Issuebook()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Issuebook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();


            cmd = new SqlCommand("select book_name from addbook",con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                for(int i =0;i<sdr.FieldCount; i++)
                {
                    combobookname.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }
        int count;
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(textenrollment.Text!="")
            {
                string enrl = textenrollment.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select * from addstudent where enroll='" + enrl + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);




                //isuue book counut code
                cmd.CommandText = "select count(std_enroll) from IR_book where std_enroll='" + enrl + "' and book_return_date is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);
                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());









                if (DS.Tables[0].Rows.Count !=0)
                {
                    textname.Text = DS.Tables[0].Rows[0][1].ToString();
                    textdepartment.Text = DS.Tables[0].Rows[0][3].ToString();
                    textsemester.Text = DS.Tables[0].Rows[0][4].ToString();
                    textcontact.Text = DS.Tables[0].Rows[0][5].ToString();
                    textemail.Text = DS.Tables[0].Rows[0][6].ToString();
                   // dateTimePicker1.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    textname.Clear();
                    textdepartment.Text = "";
                    textsemester.Text = "";
                    textsemester.Text = "";
                    textcontact.Text = "";
                    textemail.Text = "";
                    MessageBox.Show("Invalid Enrollment No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void btnbookissue_Click(object sender, EventArgs e)
        {
             if(textname.Text!="")
            {
                if(count<=2)
                {
                    if (combobookname.SelectedIndex != -1)
                    {
                        string enroll = textenrollment.Text;
                        string sname = textname.Text;
                        string sdep = textdepartment.Text;
                        string sem = textsemester.Text;
                        string contact = textcontact.Text;
                        string email = textemail.Text;
                        string book = combobookname.Text;
                        string issue = dateTimePicker1.Text;



                        string eid = textenrollment.Text;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        con.Open();
                        cmd.CommandText = cmd.CommandText = "insert into IR_book  (std_enroll,std_name,std_dep,std_sem,std_contact,std_email,book_name,book_issue_date)values('" + enroll + "','" + sname + "','" + sdep + "','" + sem + "','" + contact + "','" + email + "','" + book + "','" + issue + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textname.Clear();
                        textdepartment.Clear();
                        textsemester.Clear();
                        textcontact.Clear();
                        textemail.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Book Is Not Selected.", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                

                }
                else
                {
                    MessageBox.Show("Maximum Book Is Issued", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textname.Clear();
                    textdepartment.Clear();
                    textsemester.Clear();
                    textcontact.Clear();
                    textemail.Clear();
                    textenrollment.Clear();

                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            textenrollment.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

