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
    public partial class addStudent : Form
    {
        public addStudent()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            textsname.Clear();
            textsid.Clear();
            textdepartment.Clear();
            textsemester.Clear();
            textcontact.Clear();
            textemail.Clear();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if(textsname.Text!="" && textsid.Text!=""&& textdepartment.Text!=""&& textsemester.Text!=""&& textcontact.Text!=""&& textemail.Text!="")
            {
                string sname = textsname.Text;
                string enroll = textsid.Text;
                string depart = textdepartment.Text;
                string semester = textsemester.Text;
                string contact = textcontact.Text;
                string email = textemail.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-FI65JP3\\SQLEXPRESS;database=Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into addstudent(student_name,enroll,department,semester,contact,email)values('" + sname + "','" + enroll + "','" + depart + "','" + semester + "','" + contact + "','" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saves Success", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Saved Data successfully");
                textsname.Clear();
                textsid.Clear();
                textdepartment.Clear();
                textsemester.Clear();
                textcontact.Clear();
                textemail.Clear();
                MessageBox.Show("Saved Data successfully");
            }
            else
            {
                MessageBox.Show("Empty field not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textsname.Clear();
                textsid.Clear();
                textdepartment.Clear();
                textsemester.Clear();
                textcontact.Clear();
                textemail.Clear();
            }
        }

        private void addStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
