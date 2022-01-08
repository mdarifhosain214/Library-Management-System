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
    public partial class Viewstudent : Form
    {
        public Viewstudent()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textenrollment.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select * from addstudent where enroll like '" + textenrollment.Text + "%'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select * from addstudent";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void Viewstudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;


            cmd.CommandText = "select * from addstudent";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int student_ID;
        Int64 rowid;


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                student_ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                panel2.Visible = true;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select * from addstudent where student_id= " + student_ID + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                textsname.Text = ds.Tables[0].Rows[0][1].ToString();
                textenroll.Text = ds.Tables[0].Rows[0][2].ToString();
                textdepart.Text = ds.Tables[0].Rows[0][3].ToString();
                textsemester.Text = ds.Tables[0].Rows[0][4].ToString();
                textcontact.Text = ds.Tables[0].Rows[0][5].ToString();
                textemail.Text = ds.Tables[0].Rows[0][6].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textenrollment.Text = "";
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (textsname.Text != "" && textenroll.Text != "" && textdepart.Text != "" && textsemester.Text != "" && textcontact.Text != "" && textemail.Text != "")
            {
                if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string name = textsname.Text;
                    string enrollment = textenroll.Text;
                    string department = textdepart.Text;
                    string semester = textsemester.Text;
                    string contact = textcontact.Text;
                    string email = textemail.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;


                    cmd.CommandText = "Update addstudent set student_name='" + name + "',enroll='" + enrollment + "',department='" + department + "',semester='" + semester + "',contact='" + contact + "',email='" + email + "' where student_id ='" + rowid + "'";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DA.Fill(ds);
                }

            }
            else
            {
                MessageBox.Show("Empty field not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data will be Deleted.Confirm?", "Confirmermation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "delete addstudent where student_id='" + rowid + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
